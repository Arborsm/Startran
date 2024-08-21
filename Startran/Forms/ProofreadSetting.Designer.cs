
namespace Startran.Forms
{
    partial class ProofreadSetting
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region 组件设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            panel = new AntdUI.Panel();
            isVisibleHeader = new AntdUI.Checkbox();
            isEnableHeaderResizing = new AntdUI.Checkbox();
            isSetRowStyle = new AntdUI.Checkbox();
            isBordered = new AntdUI.Checkbox();
            isOrder = new AntdUI.Checkbox();
            isFilter = new AntdUI.Checkbox();
            panel.SuspendLayout();
            SuspendLayout();
            // 
            // panel
            // 
            panel.Controls.Add(isFilter);
            panel.Controls.Add(isVisibleHeader);
            panel.Controls.Add(isEnableHeaderResizing);
            panel.Controls.Add(isSetRowStyle);
            panel.Controls.Add(isBordered);
            panel.Controls.Add(isOrder);
            panel.Dock = DockStyle.Fill;
            panel.Name = "panel";
            panel.Size = new Size(840, 676);
            panel.TabIndex = 0;
            //
            // isFilter
            //
            isFilter.AutoSizeMode = AntdUI.TAutoSize.Width;
            isFilter.AutoCheck = true;
            isFilter.BackColor = Color.White;
            isFilter.Name = "isFilter";
            isFilter.Location = new Point(200, 0);
            isFilter.Size = new Size(180, 50);
            isFilter.TabIndex = 6;
            isFilter.Text = "只显示格式错误项";
            isFilter.CheckedChanged += IsFilterCheckedChanged;
            // 
            // isVisibleHeader
            // 
            isVisibleHeader.AutoSizeMode = AntdUI.TAutoSize.Width;
            isVisibleHeader.AutoCheck = true;
            isVisibleHeader.BackColor = Color.White;
            isVisibleHeader.Name = "isVisibleHeader";
            isVisibleHeader.Location = new Point(0, 0);
            isVisibleHeader.Size = new Size(120, 50);
            isVisibleHeader.TabIndex = 5;
            isVisibleHeader.Text = "显示表头";
            isVisibleHeader.CheckedChanged += IsVisibleHeaderCheckedChanged;
            // 
            // isEnableHeaderResizing
            // 
            isVisibleHeader.AutoSizeMode = AntdUI.TAutoSize.Width;
            isEnableHeaderResizing.AutoCheck = true;
            isEnableHeaderResizing.BackColor = Color.White;
            isEnableHeaderResizing.Name = "isEnableHeaderResizing";
            isEnableHeaderResizing.Location = new Point(0, 50);
            isEnableHeaderResizing.Size = new Size(180, 50);
            isEnableHeaderResizing.TabIndex = 4;
            isEnableHeaderResizing.Text = "手动调整列头宽度";
            isEnableHeaderResizing.CheckedChanged += IsEnableHeaderResizingCheckedChanged;
            // 
            // isSetRowStyle
            // 
            isVisibleHeader.AutoSizeMode = AntdUI.TAutoSize.Width;
            isSetRowStyle.AutoCheck = true;
            isSetRowStyle.BackColor = Color.White;
            isSetRowStyle.Name = "isSetRowStyle";
            isSetRowStyle.Location = new Point(0, 100);
            isSetRowStyle.Size = new Size(90, 50);
            isSetRowStyle.TabIndex = 3;
            isSetRowStyle.Text = "奇偶列";
            isSetRowStyle.CheckedChanged += IsSetRowStyleCheckedChanged;
            // 
            // isBordered
            // 
            isVisibleHeader.AutoSizeMode = AntdUI.TAutoSize.Width;
            isBordered.AutoCheck = true;
            isBordered.BackColor = Color.White;
            isBordered.Name = "isBordered";
            isBordered.Location = new Point(0, 150);
            isBordered.Size = new Size(150, 50);
            isBordered.TabIndex = 2;
            isBordered.Text = "显示列边框";
            isBordered.CheckedChanged += IsBorderedCheckedChanged;
            // 
            // isOrder
            // 
            isVisibleHeader.AutoSizeMode = AntdUI.TAutoSize.Width;
            isOrder.AutoCheck = true;
            isOrder.BackColor = Color.White;
            isOrder.Name = "isOrder";
            isOrder.Location = new Point(0, 200);
            isOrder.Size = new Size(120, 50);
            isOrder.TabIndex = 1;
            isOrder.Text = "启用排列";
            isOrder.CheckedChanged += IsOrderCheckedChanged;
            // 
            // ProofreadSetting
            // 
            Controls.Add(panel);
            Font = new Font("Microsoft YaHei UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            panel.ResumeLayout(false);
            panel.PerformLayout();
            ResumeLayout(false);
        }

        #endregion
        private AntdUI.Panel panel;
        private AntdUI.Checkbox isOrder;
        private AntdUI.Checkbox isEnableHeaderResizing;
        private AntdUI.Checkbox isSetRowStyle;
        private AntdUI.Checkbox isBordered;
        private AntdUI.Checkbox isVisibleHeader;
        private AntdUI.Checkbox isFilter;
    }
}
