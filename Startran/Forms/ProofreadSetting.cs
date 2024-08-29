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

        private void IsOrderCheckedChanged(object sender, BoolEventArgs boolEventArgs)
        {
            _form.table.Columns?.ForEach(it => it.SortOrder = boolEventArgs.Value);
        }

        private void IsBorderedCheckedChanged(object sender, BoolEventArgs boolEventArgs)
        {
            var value = boolEventArgs.Value;
            _form.table.Bordered = value;
        }

        private void IsSetRowStyleCheckedChanged(object sender, BoolEventArgs boolEventArgs)
        {
            if (boolEventArgs.Value) _form.table.SetRowStyle += Table_SetRowStyle;
            else _form.table.SetRowStyle -= Table_SetRowStyle;
            _form.table.Invalidate();
        }

        private Table.CellStyleInfo? Table_SetRowStyle(object sender, TableSetRowStyleEventArgs tableSetRowStyleEventArgs)
        {
            if (tableSetRowStyleEventArgs.RowIndex % 2 == 0)
                return new Table.CellStyleInfo
                {
                    BackColor = Style.Db.ErrorBg,
                    ForeColor = Style.Db.Error
                };
            return null;
        }

        private void IsEnableHeaderResizingCheckedChanged(object sender, BoolEventArgs boolEventArgs)
        {
            _form.table.EnableHeaderResizing = boolEventArgs.Value;
        }

        private void IsVisibleHeaderCheckedChanged(object sender, BoolEventArgs boolEventArgs)
        {
            _form.table.VisibleHeader = boolEventArgs.Value;
        }

        private void IsFilterCheckedChanged(object sender, BoolEventArgs boolEventArgs)
        {
            _form.SetFilter(boolEventArgs.Value);
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
