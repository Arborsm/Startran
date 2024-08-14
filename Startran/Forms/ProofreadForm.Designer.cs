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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            menuStrip1 = new MenuStrip();
            toolStripMenuItem1 = new ToolStripMenuItem();
            dataGridView1 = new DataGridView();
            Key = new DataGridViewTextBoxColumn();
            Defaut = new DataGridViewTextBoxColumn();
            Targetlang = new DataGridViewTextBoxColumn();
            menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            SuspendLayout();
            // 
            // menuStrip1
            // 
            menuStrip1.ImageScalingSize = new Size(20, 20);
            menuStrip1.Items.AddRange(new ToolStripItem[] { toolStripMenuItem1 });
            menuStrip1.Location = new Point(0, 0);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.Size = new Size(800, 28);
            menuStrip1.TabIndex = 0;
            menuStrip1.Text = "menuStrip1";
            // 
            // toolStripMenuItem1
            // 
            toolStripMenuItem1.Name = "toolStripMenuItem1";
            toolStripMenuItem1.Size = new Size(14, 24);
            // 
            // dataGridView1
            // 
            dataGridView1.AllowUserToAddRows = false;
            dataGridView1.AllowUserToDeleteRows = false;
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Columns.AddRange(new DataGridViewColumn[] { Key, Defaut, Targetlang });
            dataGridView1.Dock = DockStyle.Fill;
            dataGridView1.Location = new Point(0, 28);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.RowHeadersWidth = 51;
            dataGridView1.RowTemplate.Height = 29;
            dataGridView1.Size = new Size(800, 422);
            dataGridView1.TabIndex = 1;
            // 
            // Key
            // 
            Key.Frozen = true;
            Key.HeaderText = "Key";
            Key.MinimumWidth = 6;
            Key.Name = "Key";
            Key.ReadOnly = true;
            Key.Width = 125;
            // 
            // Defaut
            // 
            Defaut.Frozen = true;
            Defaut.HeaderText = "Defaut";
            Defaut.MinimumWidth = 6;
            Defaut.Name = "Defaut";
            Defaut.ReadOnly = true;
            Defaut.Width = 125;
            // 
            // Targetlang
            // 
            Targetlang.Frozen = true;
            Targetlang.HeaderText = "Targetlang";
            Targetlang.MinimumWidth = 6;
            Targetlang.Name = "Targetlang";
            Targetlang.ReadOnly = true;
            Targetlang.Width = 125;
            // 
            // ProofreadForm
            // 
            AutoScaleDimensions = new SizeF(9F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(dataGridView1);
            Controls.Add(menuStrip1);
            MainMenuStrip = menuStrip1;
            Name = "ProofreadForm";
            Text = "ProofreadForm";
            menuStrip1.ResumeLayout(false);
            menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private MenuStrip menuStrip1;
        private ToolStripMenuItem toolStripMenuItem1;
        private DataGridView dataGridView1;
        private DataGridViewTextBoxColumn Key;
        private DataGridViewTextBoxColumn Defaut;
        private DataGridViewTextBoxColumn Targetlang;
    }
}