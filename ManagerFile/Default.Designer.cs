namespace ManagerFile
{
    partial class Default
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
            this.ddlDisk = new System.Windows.Forms.ComboBox();
            this.txtFilepath = new System.Windows.Forms.TextBox();
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.listDesktop = new System.Windows.Forms.ListView();
            this.Name = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Type = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Size = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.DateModified = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.lstUsb = new System.Windows.Forms.ListView();
            this.NameUsb = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.TypeUsb = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.SizeUsb = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.DateModifiedUsb = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.lbUSB = new System.Windows.Forms.Label();
            this.txtUsb = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // ddlDisk
            // 
            this.ddlDisk.FormattingEnabled = true;
            this.ddlDisk.Location = new System.Drawing.Point(12, 88);
            this.ddlDisk.Name = "ddlDisk";
            this.ddlDisk.Size = new System.Drawing.Size(137, 24);
            this.ddlDisk.TabIndex = 2;
            this.ddlDisk.SelectedIndexChanged += new System.EventHandler(this.ddlDisk_SelectedIndexChanged);
            // 
            // txtFilepath
            // 
            this.txtFilepath.Enabled = false;
            this.txtFilepath.Location = new System.Drawing.Point(156, 88);
            this.txtFilepath.Name = "txtFilepath";
            this.txtFilepath.Size = new System.Drawing.Size(338, 22);
            this.txtFilepath.TabIndex = 3;
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.Location = new System.Drawing.Point(475, 319);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(200, 22);
            this.dateTimePicker1.TabIndex = 5;
            // 
            // listDesktop
            // 
            this.listDesktop.AllowDrop = true;
            this.listDesktop.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.Name,
            this.Type,
            this.Size,
            this.DateModified});
            this.listDesktop.HideSelection = false;
            this.listDesktop.Location = new System.Drawing.Point(12, 132);
            this.listDesktop.Name = "listDesktop";
            this.listDesktop.Size = new System.Drawing.Size(736, 606);
            this.listDesktop.TabIndex = 6;
            this.listDesktop.UseCompatibleStateImageBehavior = false;
            this.listDesktop.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.listDesktop_MouseDoubleClick);
            // 
            // Name
            // 
            this.Name.Text = "Name";
            this.Name.Width = 150;
            // 
            // Type
            // 
            this.Type.Text = "Type";
            this.Type.Width = 80;
            // 
            // Size
            // 
            this.Size.Text = "Size";
            this.Size.Width = 100;
            // 
            // DateModified
            // 
            this.DateModified.Text = "Date Modified";
            this.DateModified.Width = 120;
            // 
            // lstUsb
            // 
            this.lstUsb.AllowDrop = true;
            this.lstUsb.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.NameUsb,
            this.TypeUsb,
            this.SizeUsb,
            this.DateModifiedUsb});
            this.lstUsb.HideSelection = false;
            this.lstUsb.Location = new System.Drawing.Point(755, 132);
            this.lstUsb.Name = "lstUsb";
            this.lstUsb.Size = new System.Drawing.Size(736, 606);
            this.lstUsb.TabIndex = 7;
            this.lstUsb.UseCompatibleStateImageBehavior = false;
            this.lstUsb.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.lstUsb_MouseDoubleClick);
            // 
            // NameUsb
            // 
            this.NameUsb.Text = "Name";
            // 
            // TypeUsb
            // 
            this.TypeUsb.Text = "Type";
            // 
            // SizeUsb
            // 
            this.SizeUsb.Text = "Size";
            // 
            // DateModifiedUsb
            // 
            this.DateModifiedUsb.Text = "Date Modified";
            // 
            // lbUSB
            // 
            this.lbUSB.AutoSize = true;
            this.lbUSB.Location = new System.Drawing.Point(755, 95);
            this.lbUSB.Name = "lbUSB";
            this.lbUSB.Size = new System.Drawing.Size(35, 16);
            this.lbUSB.TabIndex = 8;
            this.lbUSB.Text = "USB";
            // 
            // txtUsb
            // 
            this.txtUsb.Location = new System.Drawing.Point(818, 90);
            this.txtUsb.Name = "txtUsb";
            this.txtUsb.Size = new System.Drawing.Size(388, 22);
            this.txtUsb.TabIndex = 9;
            // 
            // Default
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1492, 773);
            this.Controls.Add(this.txtUsb);
            this.Controls.Add(this.lbUSB);
            this.Controls.Add(this.lstUsb);
            this.Controls.Add(this.listDesktop);
            this.Controls.Add(this.dateTimePicker1);
            this.Controls.Add(this.txtFilepath);
            this.Controls.Add(this.ddlDisk);
            this.Text = "USB - PPA";
            this.Load += new System.EventHandler(this.Default_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.ComboBox ddlDisk;
        private System.Windows.Forms.TextBox txtFilepath;
        private System.Windows.Forms.DateTimePicker dateTimePicker1;
        private System.Windows.Forms.ListView listDesktop;
        private System.Windows.Forms.ColumnHeader Name;
        private System.Windows.Forms.ColumnHeader Type;
        private System.Windows.Forms.ColumnHeader Size;
        private System.Windows.Forms.ColumnHeader DateModified;
        private System.Windows.Forms.ListView lstUsb;
        private System.Windows.Forms.Label lbUSB;
        private System.Windows.Forms.TextBox txtUsb;
        private System.Windows.Forms.ColumnHeader NameUsb;
        private System.Windows.Forms.ColumnHeader TypeUsb;
        private System.Windows.Forms.ColumnHeader SizeUsb;
        private System.Windows.Forms.ColumnHeader DateModifiedUsb;
    }
}