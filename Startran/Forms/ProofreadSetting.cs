using System.ComponentModel;
using AntdUI;
using Startran.Config;

namespace Startran.Forms
{
    public partial class ProofreadSetting : Control
    {
        private readonly ProofreadForm _form;
        public ProofreadSetting(ProofreadForm form, bool isFilterBool = false)
        {
            _form = form;
            InitializeComponent();
            var config = ConfigManager<ProofreadConfig>.Load();
            isVisibleHeader.Checked = config.IsVisibleHeader;
            isBordered.Checked = config.IsBordered;
            isSetRowStyle.Checked = config.IsSetRowStyle;
            isEnableHeaderResizing.Checked = config.IsEnableHeaderResizing;
            isFilter.Checked = isFilterBool ? isFilterBool : config.IsFilter;
            isOrder.Checked = config.IsOrder;
        }

        private class ProofreadConfig
        {
            public bool IsVisibleHeader { get; init; } = true;
            public bool IsOrder { get; init; }
            public bool IsBordered { get; init; }
            public bool IsSetRowStyle { get; init; }
            public bool IsEnableHeaderResizing { get; init; }
            public bool IsFilter { get; init; }
        }

        protected override void OnPaint(PaintEventArgs pe)
        {
            base.OnPaint(pe);
        }

        private void IsOrderCheckedChanged(object sender, bool value)
        {
            _form.table.Columns?.ForEach(it => it.SortOrder = value);
        }

        private void IsBorderedCheckedChanged(object sender, bool value)
        {
            _form.table.Bordered = value;
        }

        private void IsSetRowStyleCheckedChanged(object sender, bool value)
        {
            if (value) _form.table.SetRowStyle += Table_SetRowStyle;
            else _form.table.SetRowStyle -= Table_SetRowStyle;
            _form.table.Invalidate();
        }

        private Table.CellStyleInfo? Table_SetRowStyle(object? sender, object? record, int rowIndex)
        {
            if (rowIndex % 2 == 0)
                return new Table.CellStyleInfo
                {
                    BackColor = Style.Db.ErrorBg,
                    ForeColor = Style.Db.Error
                };
            return null;
        }

        private void IsEnableHeaderResizingCheckedChanged(object sender, bool value)
        {
            _form.table.EnableHeaderResizing = value;
        }

        private void IsVisibleHeaderCheckedChanged(object sender, bool value)
        {
            _form.table.VisibleHeader = value;
        }

        private void IsFilterCheckedChanged(object sender, bool value)
        {
            _form.SetFilter(value);
        }

        public void OnClosing(object? sender, CancelEventArgs e)
        {
            ConfigManager<ProofreadConfig>.Save(new ProofreadConfig
            {
                IsVisibleHeader = isVisibleHeader.Checked,
                IsBordered = isBordered.Checked,
                IsSetRowStyle = isSetRowStyle.Checked,
                IsEnableHeaderResizing = isEnableHeaderResizing.Checked,
                IsFilter = isFilter.Checked,
                IsOrder = isOrder.Checked
            });
        }
    }
}
