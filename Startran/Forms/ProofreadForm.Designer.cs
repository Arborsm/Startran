namespace Startran.Forms
{
    partial class ProofreadForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            panel1 = new AntdUI.Panel();
            windowBar1 = new AntdUI.WindowBar();
            SaveButton = new AntdUI.Button();
            dropdown = new AntdUI.Dropdown();
            checkVisibleHeader = new AntdUI.Checkbox();
            checkEnableHeaderResizing = new AntdUI.Checkbox();
            checkSetRowStyle = new AntdUI.Checkbox();
            checkBordered = new AntdUI.Checkbox();
            checkOrder = new AntdUI.Checkbox();
            doToolTip = new AntdUI.Switch();
            pagination = new AntdUI.Pagination();
            table = new AntdUI.Table();
            panel1.SuspendLayout();
            windowBar1.SuspendLayout();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.Controls.Add(dropdown);
            panel1.Controls.Add(windowBar1);
            panel1.Controls.Add(checkEnableHeaderResizing);
            panel1.Controls.Add(checkSetRowStyle);
            panel1.Controls.Add(checkOrder);
            panel1.Controls.Add(checkBordered);
            panel1.Controls.Add(checkVisibleHeader);
            panel1.Controls.Add(doToolTip);
            panel1.Dock = DockStyle.Top;
            panel1.Font = new Font("Microsoft YaHei UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Padding = new Padding(10, 0, 0, 0);
            panel1.Size = new Size(1184, 43);
            panel1.TabIndex = 1;
            panel1.Text = "panel1";
            // 
            // windowBar1
            // 
            windowBar1.BackColor = Color.White;
            windowBar1.Controls.Add(SaveButton);
            windowBar1.Dock = DockStyle.Right;
            windowBar1.Location = new Point(981, 0);
            windowBar1.Name = "windowBar1";
            windowBar1.ShowIcon = false;
            windowBar1.Size = new Size(203, 43);
            windowBar1.TabIndex = 2;
            windowBar1.Text = " ";
            // 
            // SaveButton
            // 
            SaveButton.Dock = DockStyle.Right;
            SaveButton.Font = new Font("Microsoft YaHei UI", 18F, FontStyle.Regular, GraphicsUnit.Point);
            SaveButton.Ghost = true;
            SaveButton.Location = new Point(-133, 0);
            SaveButton.Name = "SaveButton";
            SaveButton.Radius = 0;
            SaveButton.ImageSvg = Assets.Resource.Save;
            SaveButton.Size = new Size(50, 43);
            SaveButton.TabIndex = 6;
            SaveButton.WaveSize = 0;
            SaveButton.Click += SaveButton_Click;
            // 
            // dropdown
            // 
            dropdown.Dock = DockStyle.Right;
            dropdown.IsLink = true;
            dropdown.DropDownArrow = true;
            dropdown.Font = new Font("Microsoft YaHei UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            dropdown.Name = "dropdown";
            dropdown.MaxCount = 12;
            dropdown.Radius = 0;
            dropdown.Size = new Size(300, 43);
            dropdown.TabIndex = 7;
            dropdown.SelectedValueChanged += DropdownOnSelectedValueChanged;
            // 
            // checkVisibleHeader
            // 
            checkVisibleHeader.AutoCheck = true;
            checkVisibleHeader.BackColor = Color.White;
            checkVisibleHeader.Checked = true;
            checkVisibleHeader.Dock = DockStyle.Left;
            checkVisibleHeader.Location = new Point(741, 0);
            checkVisibleHeader.Name = "checkVisibleHeader";
            checkVisibleHeader.Size = new Size(110, 43);
            checkVisibleHeader.TabIndex = 6;
            checkVisibleHeader.Text = "显示表头";
            checkVisibleHeader.CheckedChanged += CheckVisibleHeader_CheckedChanged;
            // 
            // checkEnableHeaderResizing
            // 
            checkEnableHeaderResizing.AutoCheck = true;
            checkEnableHeaderResizing.BackColor = Color.White;
            checkEnableHeaderResizing.Dock = DockStyle.Left;
            checkEnableHeaderResizing.Location = new Point(563, 0);
            checkEnableHeaderResizing.Name = "checkEnableHeaderResizing";
            checkEnableHeaderResizing.Size = new Size(165, 43);
            checkEnableHeaderResizing.TabIndex = 5;
            checkEnableHeaderResizing.Text = "手动调整列头宽度";
            checkEnableHeaderResizing.CheckedChanged += CheckEnableHeaderResizing_CheckedChanged;
            // 
            // checkSetRowStyle
            // 
            checkSetRowStyle.AutoCheck = true;
            checkSetRowStyle.BackColor = Color.White;
            checkSetRowStyle.Dock = DockStyle.Left;
            checkSetRowStyle.Location = new Point(466, 0);
            checkSetRowStyle.Name = "checkSetRowStyle";
            checkSetRowStyle.Size = new Size(95, 43);
            checkSetRowStyle.TabIndex = 3;
            checkSetRowStyle.Text = "奇偶列";
            checkSetRowStyle.CheckedChanged += CheckSetRowStyle_CheckedChanged;
            // 
            // checkBordered
            // 
            checkBordered.AutoCheck = true;
            checkBordered.BackColor = Color.White;
            checkBordered.Dock = DockStyle.Left;
            checkBordered.Location = new Point(339, 0);
            checkBordered.Name = "checkBordered";
            checkBordered.Size = new Size(125, 43);
            checkBordered.TabIndex = 2;
            checkBordered.Text = "显示列边框";
            checkBordered.CheckedChanged += CheckBordered_CheckedChanged;
            // 
            // checkOrder
            // 
            checkOrder.AutoCheck = true;
            checkOrder.BackColor = Color.White;
            checkOrder.Checked = false;
            checkOrder.Dock = DockStyle.Left;
            checkOrder.Location = new Point(90, 0);
            checkOrder.Name = "checkOrder";
            checkOrder.Size = new Size(110, 43);
            checkOrder.TabIndex = 0;
            checkOrder.Text = "启用排列";
            checkOrder.CheckedChanged += CheckOrderCheckedChanged;
            // 
            // doToolTip
            // 
            doToolTip.AutoCheck = true;
            doToolTip.BackColor = Color.White;
            doToolTip.Dock = DockStyle.Left;
            doToolTip.Location = new Point(10, 0);
            doToolTip.Name = "doToolTip";
            doToolTip.Size = new Size(80, 43);
            doToolTip.TabIndex = 4;
            doToolTip.Text = "浮窗显示";
            doToolTip.CheckedChanged += DoToolTipCheckedChanged;
            // 
            // pagination
            // 
            pagination.BackColor = Color.White;
            pagination.Dock = DockStyle.Bottom;
            pagination.Font = new Font("Microsoft YaHei UI", 11F, FontStyle.Regular, GraphicsUnit.Point);
            pagination.Location = new Point(1184, 727);
            pagination.Name = "pagination";
            pagination.RightToLeft = RightToLeft.Yes;
            pagination.ShowSizeChanger = true;
            //pagination.MaximumSize = new Size(600, 34);
            pagination.Size = new Size(1184, 34);
            pagination.TabIndex = 1;
            pagination.ValueChanged += PaginationValueChanged;
            pagination.ShowTotalChanged += PaginationShowTotalChanged;
            // 
            // table
            // 
            table.AutoSizeColumnsMode = AntdUI.ColumnsMode.Fill;
            table.BackColor = Color.White;
            table.Dock = DockStyle.Fill;
            table.Font = new Font("Microsoft YaHei UI", 11F, FontStyle.Regular, GraphicsUnit.Point);
            table.Location = new Point(0, 43);
            table.Name = "table";
            table.Size = new Size(1184, 684);
            table.TabIndex = 0;
            table.Text = "table";
            table.CellDoubleClick += TableOnCellDoubleClick;
            table.CellBeginEditInputStyle += TableOnCellBeginEditInputStyle;
            table.CellEndEdit += TableOnCellEndEdit;
            table.MouseMove += TableMouseMove;
            // 
            // ProofreadForm
            // 
            ClientSize = new Size(1184, 761);
            Controls.Add(table);
            Controls.Add(pagination);
            Controls.Add(panel1);
            Font = new Font("Microsoft YaHei UI", 16F, FontStyle.Regular, GraphicsUnit.Point);
            Name = "ProofreadForm";
            Closed += CloseForm;
            panel1.ResumeLayout(false);
            windowBar1.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion
        private AntdUI.Table table;
        private AntdUI.Pagination pagination;
        private AntdUI.Panel panel1;
        private AntdUI.Checkbox checkOrder;
        private AntdUI.Checkbox checkEnableHeaderResizing;
        private AntdUI.Checkbox checkSetRowStyle;
        private AntdUI.Checkbox checkBordered;
        private AntdUI.Checkbox checkVisibleHeader;
        private AntdUI.Switch doToolTip;
        private AntdUI.Button SaveButton;
        private AntdUI.WindowBar windowBar1;
        private AntdUI.Dropdown dropdown;
    }
}