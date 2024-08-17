using System.Collections.Immutable;
using System.IO;
using AntdUI;
using Newtonsoft.Json;
using Startran.Misc;
using Startran.Mod;

namespace Startran.Forms
{
    public partial class ProofreadForm : Window
    {
        private readonly AppConfig _config;
        private bool _showToolTip;
        private Dictionary<string, string> _defaultLang = null!;
        private Dictionary<string, string> _targetLang = null!;
        private IMod _currentMod = null!;
        private TooltipForm? _tooltipForm;
        private bool _isFinish;
        private bool _isSave = true;

        public ProofreadForm(AppConfig config)
        {
            _config = config;
            InitMods();
            StartPosition = FormStartPosition.CenterScreen;
            InitializeComponent();
            dropdown.Items.AddRange(ModData.Instance.Mods.ToImmutableSortedDictionary().Select(it =>
            {
                var (defaultLang, targetLang) = it.Value.ReadMap(config.Language);
                return new SelectItem(it.Key)
                {
                    Online = defaultLang.Keys.Any(key => !targetLang.ContainsKey(key)) ? 0 : 1
                };
            }).ToArray<object>());
            dropdown.Text = dropdown.Items[0]!.ToString();
            table.ShowTip = false;
            table.Columns = new ColumnCollection {
                new("Key","Key", ColumnAlign.Center) { LineBreak = true, Width = (Width * 1 / 7).ToString() },
                new("DefaultLang","DefaultLang", ColumnAlign.Center) { LineBreak = true, Width = (Width * 3 / 7).ToString() },
                new("TargetLang","TargetLang", ColumnAlign.Center) { LineBreak = true, Width = (Width * 3 / 7).ToString() }
            };
            table.DataSource = GetPageData(pagination.Current, pagination.PageSize);
            pagination.PageSizeOptions = new[] { 10, 15, 20, 30, 50, 100, 200 };
        }

        #region 分页与数据

        private void InitMods()
        {
            var currentMod = ModData.Instance.Mods.FirstOrDefault();
            if (currentMod.Value != null) _currentMod = currentMod.Value;
            else
            {
                MessageBox.Show("无法在目标文件夹找到符合要求的模组", Lang.Strings.Error, MessageBoxButtons.OK, MessageBoxIcon.Error);
                Close();
            }
            var (defaultLang, targetLang) = _currentMod.ReadMap(_config.Language);
            _defaultLang = defaultLang;
            _targetLang = targetLang;
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
                MessageBox.Show(ex.Message, Lang.Strings.Error, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                _isSave = true;
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
                .ToList();

            pagination.Total = _defaultLang.Keys.Count;

            return pagedList;
        }

        private void PaginationValueChanged(int current, int total, int pageSize, int pageTotal)
        {
            table.DataSource = GetPageData(current, pageSize);
        }

        private static string PaginationShowTotalChanged(int current, int total, int pageSize, int pageTotal) 
            => string.Format(Lang.Strings.Page, Math.Min(pageSize * current, total), total, pageTotal);

        #endregion

        #region 事件

        private void SaveButton_Click(object? sender, EventArgs e)
        {
            SaveMap();
        }

        private void DropdownOnSelectedValueChanged(object sender, object? value)
        {
            //var array = table.Columns!.Select(i => i.SortMode).ToArray();
            CheckSave();
            var mod = value!.ToString()!;
            dropdown.Text = mod;
            _currentMod = ModData.Instance.Mods[mod];
            var (defaultLang, targetLang) = _currentMod.ReadMap(_config.Language);
            _defaultLang = defaultLang;
            _targetLang = targetLang;
            table.DataSource = GetPageData(pagination.Current, pagination.PageSize);
            pagination.Current = 1;
        }

        private void CheckOrderCheckedChanged(object sender, bool value)
        {
            if (table.Columns != null) table.Columns[0].SortOrder = table.Columns[1].SortOrder = table.Columns[2].SortOrder = value;
        }

        private void CheckBordered_CheckedChanged(object sender, bool value)
        {
            table.Bordered = value;
        }

        private void CheckSetRowStyle_CheckedChanged(object sender, bool value)
        {
            if (value) table.SetRowStyle += Table_SetRowStyle;
            else table.SetRowStyle -= Table_SetRowStyle;
            table.Invalidate();
        }

        private static void TableOnCellBeginEditInputStyle(object sender, object? value, object? record, int rowIndex, int columnIndex, ref Input input)
        {
            var sizeHeight = input.Size.Height;
            var height = sizeHeight;
            height = (height <= 55) ? 55 : (height <= 80 ? 80 : height);
            if (height == sizeHeight) return;
            input.Location = input.Location with { Y = input.Location.Y + (sizeHeight - height) / 2 };
            input.Size = input.Size with { Height = height };
        }

        private void TableOnCellDoubleClick(object sender, MouseEventArgs args, object? record, int rowIndex, int columnIndex, Rectangle rect)
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
            var result = MessageBox.Show("没有进行保存，是否需要保存更改", "Warning", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
            if (result == DialogResult.OK)
            {
                SaveMap();
            }
            _isSave = true;
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
            var cel = table.CellContains(table.rows, e.X, e.Y, out _, out _, out _, out var offsetXi, out var offsetY, out _, out _, out _);
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
                if (g.MeasureString(text, Font).Width > 1200)
                {
                    text = text.BreakTextEn(g, Font, 1200);
                }
                g.Dispose();
                var rectangle = RectangleToScreen(table.ClientRectangle);
                var rect = cel.RECT with { X = rectangle.X + cel.RECT.X - offsetXi, Y = rectangle.Y + cel.RECT.Y + 54 - offsetY };
                if (table.tooltipForm == null)
                {
                    table.tooltipForm = new TooltipForm(this, rect, text, new TooltipConfig
                    {
                        Font = Font,
                        ArrowAlign = e.Y <= 160 ? TAlign.Bottom : TAlign.Top,
                    });
                    _tooltipForm = new TooltipForm(this, rect, text, new TooltipConfig
                    {
                        Font = Font,
                        ArrowAlign = e.Y <= 160 ? TAlign.Bottom : TAlign.Top,
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

        private Table.CellStyleInfo? Table_SetRowStyle(object? sender, object? record, int rowIndex)
        {
            if (rowIndex % 2 == 0)
            {
                return new Table.CellStyleInfo
                {
                    BackColor = Style.Db.ErrorBg,
                    ForeColor = Style.Db.Error
                };
            }
            return null;
        }

        private void DoToolTipCheckedChanged(object sender, bool value)
        {
            _showToolTip = value;
            table.Columns![1].Visible = !value;
        }

        private void CheckEnableHeaderResizing_CheckedChanged(object sender, bool value)
        {
            table.EnableHeaderResizing = value;
        }

        private void CheckVisibleHeader_CheckedChanged(object sender, bool value)
        {
            table.VisibleHeader = value;
        }

        #endregion

        public class Mod : NotifyProperty
        {
            public Mod(string key, string defaultLang, string? targetLang)
            {
                _key = key;
                _defaultLang = defaultLang;
                _targetLang = targetLang ?? string.Empty;
            }

            private string _key;
            public string Key
            {
                get => _key;
                set
                {
                    if (_key == value) return;
                    _key = value;
                    OnPropertyChanged();
                }
            }

            private string _defaultLang;
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

            private string _targetLang;
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
        }
    }
}
