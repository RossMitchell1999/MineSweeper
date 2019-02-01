namespace MineSweeper
{
    partial class MineSweeper
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
            this.components = new System.ComponentModel.Container();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.OptionsDropDown = new System.Windows.Forms.ToolStripMenuItem();
            this.NewGameDropDown = new System.Windows.Forms.ToolStripMenuItem();
            this.easyGameMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mediumGameMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.hardGameMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.RulesDropDown = new System.Windows.Forms.ToolStripMenuItem();
            this.ExitDropDown = new System.Windows.Forms.ToolStripMenuItem();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.OptionsDropDown});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Padding = new System.Windows.Forms.Padding(4, 2, 0, 2);
            this.menuStrip1.Size = new System.Drawing.Size(854, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // OptionsDropDown
            // 
            this.OptionsDropDown.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.NewGameDropDown,
            this.RulesDropDown,
            this.ExitDropDown});
            this.OptionsDropDown.Name = "OptionsDropDown";
            this.OptionsDropDown.Size = new System.Drawing.Size(61, 20);
            this.OptionsDropDown.Text = "Options";
            // 
            // NewGameDropDown
            // 
            this.NewGameDropDown.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.easyGameMenuItem,
            this.mediumGameMenuItem,
            this.hardGameMenuItem});
            this.NewGameDropDown.Name = "NewGameDropDown";
            this.NewGameDropDown.Size = new System.Drawing.Size(132, 22);
            this.NewGameDropDown.Text = "New Game";
            this.NewGameDropDown.Click += new System.EventHandler(this.NewGameDropDown_Click);
            // 
            // easyGameMenuItem
            // 
            this.easyGameMenuItem.Name = "easyGameMenuItem";
            this.easyGameMenuItem.Size = new System.Drawing.Size(265, 22);
            this.easyGameMenuItem.Text = "Easy (10x10 grid, few bombs)";
            this.easyGameMenuItem.Click += new System.EventHandler(this.easyGameMenuItem_Click);
            // 
            // mediumGameMenuItem
            // 
            this.mediumGameMenuItem.Name = "mediumGameMenuItem";
            this.mediumGameMenuItem.Size = new System.Drawing.Size(265, 22);
            this.mediumGameMenuItem.Text = "Medium (20x20 grid, several bombs)";
            this.mediumGameMenuItem.Click += new System.EventHandler(this.mediumGameMenuItem_Click);
            // 
            // hardGameMenuItem
            // 
            this.hardGameMenuItem.Name = "hardGameMenuItem";
            this.hardGameMenuItem.Size = new System.Drawing.Size(265, 22);
            this.hardGameMenuItem.Text = "Hard (32x32 grid, many bombs)";
            this.hardGameMenuItem.Click += new System.EventHandler(this.hardGameMenuItem_Click);
            // 
            // RulesDropDown
            // 
            this.RulesDropDown.Name = "RulesDropDown";
            this.RulesDropDown.Size = new System.Drawing.Size(132, 22);
            this.RulesDropDown.Text = "Rules";
            this.RulesDropDown.Click += new System.EventHandler(this.RulesDropDown_Click);
            // 
            // ExitDropDown
            // 
            this.ExitDropDown.Name = "ExitDropDown";
            this.ExitDropDown.Size = new System.Drawing.Size(132, 22);
            this.ExitDropDown.Text = "Exit";
            this.ExitDropDown.Click += new System.EventHandler(this.ExitDropDown_Click);
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Interval = 1000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // MineSweeper
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(854, 573);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "MineSweeper";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.Text = "Bomb Finder";
            this.Load += new System.EventHandler(this.MineSweeper_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem OptionsDropDown;
        private System.Windows.Forms.ToolStripMenuItem NewGameDropDown;
        private System.Windows.Forms.ToolStripMenuItem RulesDropDown;
        private System.Windows.Forms.ToolStripMenuItem ExitDropDown;
        private System.Windows.Forms.ToolStripMenuItem easyGameMenuItem;
        private System.Windows.Forms.ToolStripMenuItem mediumGameMenuItem;
        private System.Windows.Forms.ToolStripMenuItem hardGameMenuItem;
        private System.Windows.Forms.Timer timer1;
    }
}

