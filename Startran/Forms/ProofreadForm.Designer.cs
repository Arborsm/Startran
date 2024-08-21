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
            dropdown = new AntdUI.Dropdown();
            windowBar1 = new AntdUI.WindowBar();
            popoverButton = new AntdUI.Button();
            SaveButton = new AntdUI.Button();
            doToolTip = new AntdUI.Switch();
            label = new Label();
            pagination = new AntdUI.Pagination();
            table = new AntdUI.Table();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.Controls.Add(dropdown);
            panel1.Controls.Add(windowBar1);
            panel1.Controls.Add(popoverButton);
            panel1.Controls.Add(SaveButton);
            panel1.Controls.Add(doToolTip);
            panel1.Controls.Add(label);
            panel1.Dock = DockStyle.Top;
            panel1.Font = new Font("Microsoft YaHei UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Padding = new Padding(10, 0, 0, 0);
            panel1.Size = new Size(1184, 43);
            panel1.TabIndex = 1;
            panel1.Text = "panel1";
            // 
            // dropdown
            // 
            dropdown.Dock = DockStyle.Right;
            dropdown.DropDownArrow = true;
            dropdown.Font = new Font("Microsoft YaHei UI", 10F, FontStyle.Bold, GraphicsUnit.Point);
            dropdown.IsLink = true;
            dropdown.Location = new Point(730, 0);
            dropdown.MaxCount = 12;
            dropdown.Name = "dropdown";
            dropdown.Radius = 0;
            dropdown.Size = new Size(300, 43);
            dropdown.TabIndex = 7;
            dropdown.SelectedValueChanged += DropdownOnSelectedValueChanged;
            // 
            // windowBar1
            // 
            windowBar1.BackColor = Color.White;
            windowBar1.Dock = DockStyle.Right;
            windowBar1.Location = new Point(1030, 0);
            windowBar1.Name = "windowBar1";
            windowBar1.ShowIcon = false;
            windowBar1.Size = new Size(154, 43);
            windowBar1.TabIndex = 2;
            windowBar1.Text = " ";
            // 
            // popoverButton
            // 
            popoverButton.Dock = DockStyle.Left;
            popoverButton.Font = new Font("Microsoft YaHei UI", 22.2F, FontStyle.Regular, GraphicsUnit.Point);
            popoverButton.Ghost = true;
            popoverButton.ImageSvg = Assets.Resource.Setting;
            popoverButton.Location = new Point(305, 0);
            popoverButton.Name = "popoverButton";
            popoverButton.Radius = 0;
            popoverButton.Size = new Size(50, 43);
            popoverButton.TabIndex = 5;
            popoverButton.WaveSize = 0;
            popoverButton.Click += PopoverButton_Click;
            // 
            // SaveButton
            // 
            SaveButton.Dock = DockStyle.Left;
            SaveButton.Font = new Font("Microsoft YaHei UI", 18F, FontStyle.Regular, GraphicsUnit.Point);
            SaveButton.Ghost = true;
            SaveButton.ImageSvg = Assets.Resource.Save;
            SaveButton.Location = new Point(255, 0);
            SaveButton.Name = "SaveButton";
            SaveButton.Radius = 0;
            SaveButton.Size = new Size(50, 43);
            SaveButton.TabIndex = 6;
            SaveButton.WaveSize = 0;
            SaveButton.Click += SaveButton_Click;
            // 
            // doToolTip
            // 
            doToolTip.AutoCheck = true;
            doToolTip.BackColor = Color.White;
            doToolTip.Dock = DockStyle.Left;
            doToolTip.Location = new Point(175, 0);
            doToolTip.Name = "doToolTip";
            doToolTip.Size = new Size(80, 43);
            doToolTip.TabIndex = 4;
            doToolTip.CheckedChanged += DoToolTipCheckedChanged;
            // 
            // label
            // 
            label.BackColor = Color.White;
            label.Dock = DockStyle.Left;
            label.Font = new Font("Microsoft YaHei UI", 11F, FontStyle.Bold, GraphicsUnit.Point);
            label.Location = new Point(10, 0);
            label.Name = "label";
            label.Size = new Size(165, 43);
            label.TabIndex = 3;
            label.Text = "Tooltip Mode";
            label.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // pagination
            // 
            pagination.BackColor = Color.White;
            pagination.Dock = DockStyle.Bottom;
            pagination.Font = new Font("Microsoft YaHei UI", 11F, FontStyle.Regular, GraphicsUnit.Point);
            pagination.Location = new Point(0, 727);
            pagination.Name = "pagination";
            pagination.RightToLeft = RightToLeft.Yes;
            pagination.ShowSizeChanger = true;
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
            ResumeLayout(false);
        }

        #endregion
        internal AntdUI.Table table;
        internal AntdUI.Pagination pagination;
        private AntdUI.Panel panel1;
        private AntdUI.Button popoverButton;
        private Label label;
        private AntdUI.Switch doToolTip;
        private AntdUI.Button SaveButton;
        private AntdUI.WindowBar windowBar1;
        private AntdUI.Dropdown dropdown;
    }
}