using System.Collections.Immutable;
using System.IO;
using AntdUI;
using Newtonsoft.Json;
using Startran.Config;
using Startran.Lang;
using Startran.Misc;
using Startran.Mod;
using MouseEventArgs = System.Windows.Forms.MouseEventArgs;

namespace Startran.Forms;

public partial class ProofreadForm : Window
{
    private readonly MainConfig _config;
    private IMod _currentMod = null!;
    private Dictionary<string, string> _defaultLang = null!;
    private Dictionary<string, string> _targetLang = null!;
    private TooltipForm? _tooltipForm;
    private bool _isSave = true;
    private bool _isFinish;
    private bool _showToolTip;
    private bool _isFilter;

    public ProofreadForm(MainConfig config, bool isFilter = false)
    {
        StartPosition = FormStartPosition.CenterScreen;
        _config = config;
        InitMods();
        InitializeComponent();
        // Init bool things
        var proofreadSetting = new ProofreadSetting(this, isFilter) { Size = new Size(400, 300) };
        proofreadSetting.Dispose();
        table.ShowTip = false;
        table.Columns = new ColumnCollection
        {
            new(nameof(Mod.LangKey), "Lang Key", ColumnAlign.Center)
                { LineBreak = true, Width = (Width * 0.18).ToStringI() },
            new(nameof(Mod.DefaultLang), "Default Lang", ColumnAlign.Center)
                { LineBreak = true, Width = (Width * 0.37).ToStringI() },
            new(nameof(Mod.TargetLang), "Target Lang", ColumnAlign.Center)
                { LineBreak = true, Width = (Width * 0.37).ToStringI() },
            new(nameof(Mod.Symbol), "Symbol", ColumnAlign.Center) { Width = (Width * 0.08).ToStringI() }
        };
        InitPagination();
    }

    public class Mod : NotifyProperty
    {
        private string _defaultLang;

        private string _langKey;

        private CellBadge _symbol;

        private string _targetLang;

        public Mod(string langKey, string defaultLang, string? targetLang)
        {
            _langKey = langKey;
            _defaultLang = defaultLang;
            _targetLang = targetLang ?? string.Empty;
            _symbol = defaultLang.IsMismatchedTokens(targetLang)
                ? new CellBadge(TState.Error, " ")
                : new CellBadge(TState.Success);
        }

        public string LangKey
        {
            get => _langKey;
            set
            {
                if (_langKey == value) return;
                _langKey = value;
                OnPropertyChanged();
            }
        }

        public string DefaultLang
        {
            get => _defaultLang;
            set
            {
                if (_defaultLang == value) return;
                _defaultLang = value;
                OnPropertyChanged();
            }
        }

        public string TargetLang
        {
            get => _targetLang;
            set
            {
                if (_targetLang == value) return;
                _targetLang = value;
                OnPropertyChanged();
            }
        }

        public CellBadge Symbol
        {
            get => _symbol;
            set
            {
                _symbol = value;
                OnPropertyChanged();
            }
        }
    }

    #region 分页与数据

    private void InitMods()
    {
        var currentMod = ModData.Instance.Mods.FirstOrDefault();
        if (currentMod.Value != null)
        {
            _currentMod = currentMod.Value;
        }
        else
        {
            AntdUI.Modal.open(this, Strings.Error, "无法在目标文件夹找到符合要求的模组", TType.Error);
            Close();
        }

        var (defaultLang, targetLang) = _currentMod.ReadMap(_config.Language);
        _defaultLang = defaultLang;
        _targetLang = targetLang;
    }

    private void InitPagination(int pageSize = 10)
    {
        var modList = ModData.Instance.Mods.ToImmutableSortedDictionary().Select(it =>
        {
            var (defaultLang, targetLang) = it.Value.ReadMap(_config.Language);
            var isNotOnline = defaultLang.Keys.Any(key => !targetLang.ContainsKey(key));
            return defaultLang.IsMismatchedTokens(targetLang)
                ? new SelectItem(it.Key) { Online = 2, OnlineCustom = Color.MediumPurple }
                : new SelectItem(it.Key) { Online = isNotOnline ? 0 : 1 };
        }).ToList();
        dropdown.Items.Clear();
        dropdown.Items.AddRange(modList.ToArray<object>());
        dropdown.Text ??= modList.First().Text;

        if (_isFilter)
        {
            dropdown.Items.Clear();
            dropdown.Items.AddRange(modList.Where(it=> it.Online != 1).ToArray<object>());
            table.DataSource = GetPageData(1, int.MaxValue);
            pagination.PageSize = (table.DataSource as List<Mod>)!.Count;
        }
        else
        {
            table.DataSource = GetPageData(pagination.Current, pagination.PageSize);
            pagination.PageSize = pageSize;
        }
        pagination.PageSizeOptions = new[] { 10, 15, 20, 30, 50, 100, Math.Max(200, pagination.Total) };
        pagination.Current = 1;
    }

    private void SaveMap()
    {
        try
        {
            File.WriteAllText(_currentMod.PathS + "\\i18n\\" + $"{_config.Language}.json",
                JsonConvert.SerializeObject(_targetLang, Formatting.Indented));
        }
        catch (Exception ex)
        {
            AntdUI.Modal.open(this, Strings.Error, ex.Message, TType.Error);
        }
        finally
        {
            _isSave = true;
            InitPagination();
        }
    }

    private object GetPageData(int current, int pageSize)
    {
        var start = Math.Max(0, (current - 1) * pageSize);
        var pagedList = _defaultLang
            .Skip(start)
            .Take(pageSize)
            .Select(kvp =>
            {
                _targetLang.TryGetValue(kvp.Key, out var targetValue);
                return new Mod(kvp.Key, kvp.Value, targetValue);
            })
            .Where(it => !_isFilter || it.DefaultLang.IsMismatchedTokens(it.TargetLang) || it.TargetLang == string.Empty)
            .ToList();

        pagination.Total = _isFilter ? pagedList.Count : _defaultLang.Count;

        return pagedList;
    }

    private void PaginationValueChanged(int current, int total, int pageSize, int pageTotal)
    {
        table.DataSource = GetPageData(current, pageSize);
        if (_isFilter) InitPagination();
    }

    private string PaginationShowTotalChanged(int current, int total, int pageSize, int pageTotal)
    {
        return string.Format(Strings.Page, Math.Min(pageSize * current, total), total, Math.Max(0, pageTotal));
    }

    #endregion

    #region 事件

    private void SaveButton_Click(object? sender, EventArgs e)
    {
        SaveMap();
    }

    private void DropdownOnSelectedValueChanged(object sender, object? value)
    {
        CheckSave();
        var mod = value!.ToString()!;
        dropdown.Text = mod;
        _currentMod = ModData.Instance.Mods[mod];
        var (defaultLang, targetLang) = _currentMod.ReadMap(_config.Language);
        _defaultLang = defaultLang;
        _targetLang = targetLang;
        InitPagination();
    }

    private void TableOnCellBeginEditInputStyle(object sender, object? value, object? record, int rowIndex,
        int columnIndex, ref Input input)
    {
        var sizeHeight = input.Size.Height;
        var height = sizeHeight;
        height = height <= 55 ? 55 : height <= 80 ? 80 : height;
        if (height == sizeHeight) return;
        input.Location = input.Location with { Y = input.Location.Y + (sizeHeight - height) / 2 };
        input.Size = input.Size with { Height = height };
    }

    private void TableOnCellDoubleClick(object sender, MouseEventArgs args, object? record, int rowIndex,
        int columnIndex, Rectangle rect)
    {
        _tooltipForm?.Show(this);
        table.EnterEditMode(rowIndex, columnIndex);
        _isFinish = true;
    }

    private bool TableOnCellEndEdit(object sender, string value, object? record, int rowIndex, int columnIndex)
    {
        var key = table.rows![rowIndex].cells[0].ToString()!;
        _targetLang[key] = value;
        _isSave = false;
        return true;
    }

    private void CloseForm(object? sender, EventArgs e)
    {
        CheckSave();
    }

    private void CheckSave()
    {
        if (_isSave) return;
        var result = AntdUI.Modal.open(this, "Warning", "没有进行保存，是否需要保存更改", TType.Warn);
        if (result == DialogResult.OK) SaveMap();
    }

    private void TableMouseMove(object? sender, MouseEventArgs e)
    {
        if (table.inEditMode) return;
        if (_isFinish)
        {
            _tooltipForm?.IClose();
            _isFinish = false;
        }

        if (table.rows == null || !_showToolTip) return;
        var cel = table.CellContains(table.rows, e.X, e.Y, out _, out _, out _, out var offsetXi, out var offsetY,
            out _, out _, out _);
        if (cel == null) return;
        var moveId = cel.INDEX + "_" + cel.ROW.INDEX;
        if (table.oldmove == moveId) return;
        table.CloseTip();
        table.oldmove = moveId;
        try
        {
            var key = table.rows[cel.ROW.INDEX].cells[cel.INDEX - 1].ToString();
            if (string.IsNullOrEmpty(key)) return;
            _defaultLang.TryGetValue(key, out var text);
            if (string.IsNullOrEmpty(text)) return;
            var g = CreateGraphics();
            if (g.MeasureString(text, Font).Width > 1200) text = text.BreakTextEn(g, Font, 1200);
            g.Dispose();
            var rectangle = RectangleToScreen(table.ClientRectangle);
            var rect = cel.RECT with
            {
                X = rectangle.X + cel.RECT.X - offsetXi, Y = rectangle.Y + cel.RECT.Y + 54 - offsetY
            };
            if (table.tooltipForm == null)
            {
                table.tooltipForm = new TooltipForm(this, rect, text, new TooltipConfig
                {
                    Font = Font,
                    ArrowAlign = e.Y <= 160 ? TAlign.Bottom : TAlign.Top
                });
                _tooltipForm = new TooltipForm(this, rect, text, new TooltipConfig
                {
                    Font = Font,
                    ArrowAlign = e.Y <= 160 ? TAlign.Bottom : TAlign.Top
                });
                table.tooltipForm.Show(this);
            }
            else
            {
                table.tooltipForm.SetText(rect, text);
                _tooltipForm!.SetText(rect, text);
            }
        }
        catch (Exception)
        {
            // ignored
        }
    }

    private void DoToolTipCheckedChanged(object sender, bool value)
    {
        _showToolTip = value;
        table.Columns![1].Visible = !value;
    }

    private void PopoverButton_Click(object? sender, EventArgs e)
    {
        var proofreadSetting = new ProofreadSetting(this) { Size = new Size(400, 300) };
        Popover.open(popoverButton, proofreadSetting, TAlign.BL)!.Closing += proofreadSetting.OnClosing;
    }

    public void SetFilter(bool value)
    {
        _isFilter = value;
        InitPagination();
    }

    #endregion
}