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
            this.components = new System.ComponentModel.Container();
            this.ddlDisk = new System.Windows.Forms.ComboBox();
            this.txtFilepath = new System.Windows.Forms.TextBox();
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.lstDesktop = new System.Windows.Forms.ListView();
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
            this.contextMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.contextMenuOutside = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.newToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pasteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.viewToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.refreshToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.contextMenuOutside.SuspendLayout();
            this.SuspendLayout();
            // 
            // ddlDisk
            // 
            this.ddlDisk.FormattingEnabled = true;
            this.ddlDisk.Location = new System.Drawing.Point(9, 72);
            this.ddlDisk.Margin = new System.Windows.Forms.Padding(2);
            this.ddlDisk.Name = "ddlDisk";
            this.ddlDisk.Size = new System.Drawing.Size(104, 21);
            this.ddlDisk.TabIndex = 2;
            this.ddlDisk.SelectedIndexChanged += new System.EventHandler(this.ddlDisk_SelectedIndexChanged);
            // 
            // txtFilepath
            // 
            this.txtFilepath.Enabled = false;
            this.txtFilepath.Location = new System.Drawing.Point(117, 72);
            this.txtFilepath.Margin = new System.Windows.Forms.Padding(2);
            this.txtFilepath.Name = "txtFilepath";
            this.txtFilepath.Size = new System.Drawing.Size(254, 20);
            this.txtFilepath.TabIndex = 3;
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.Location = new System.Drawing.Point(356, 259);
            this.dateTimePicker1.Margin = new System.Windows.Forms.Padding(2);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(151, 20);
            this.dateTimePicker1.TabIndex = 5;
            // 
            // lstDesktop
            // 
            this.lstDesktop.AllowDrop = true;
            this.lstDesktop.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.Name,
            this.Type,
            this.Size,
            this.DateModified});
            this.lstDesktop.HideSelection = false;
            this.lstDesktop.Location = new System.Drawing.Point(9, 107);
            this.lstDesktop.Margin = new System.Windows.Forms.Padding(2);
            this.lstDesktop.Name = "lstDesktop";
            this.lstDesktop.Size = new System.Drawing.Size(553, 493);
            this.lstDesktop.TabIndex = 6;
            this.lstDesktop.UseCompatibleStateImageBehavior = false;
            this.lstDesktop.ItemDrag += new System.Windows.Forms.ItemDragEventHandler(this.listDesktop_ItemDrag);
            this.lstDesktop.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.listDesktop_MouseDoubleClick);
            this.lstDesktop.MouseUp += new System.Windows.Forms.MouseEventHandler(this.ListView_MouseUp);
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
            this.lstUsb.Location = new System.Drawing.Point(566, 107);
            this.lstUsb.Margin = new System.Windows.Forms.Padding(2);
            this.lstUsb.Name = "lstUsb";
            this.lstUsb.Size = new System.Drawing.Size(553, 493);
            this.lstUsb.TabIndex = 7;
            this.lstUsb.UseCompatibleStateImageBehavior = false;
            this.lstUsb.DragDrop += new System.Windows.Forms.DragEventHandler(this.lstUsb_DragDrop);
            this.lstUsb.DragEnter += new System.Windows.Forms.DragEventHandler(this.lstUsb_DragEnter);
            this.lstUsb.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.lstUsb_MouseDoubleClick);
            // 
            // NameUsb
            // 
            this.NameUsb.Text = "Name";
            this.NameUsb.Width = 150;
            // 
            // TypeUsb
            // 
            this.TypeUsb.Text = "Type";
            this.TypeUsb.Width = 80;
            // 
            // SizeUsb
            // 
            this.SizeUsb.Text = "Size";
            this.SizeUsb.Width = 100;
            // 
            // DateModifiedUsb
            // 
            this.DateModifiedUsb.Text = "Date Modified";
            this.DateModifiedUsb.Width = 120;
            // 
            // lbUSB
            // 
            this.lbUSB.AutoSize = true;
            this.lbUSB.Location = new System.Drawing.Point(566, 77);
            this.lbUSB.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lbUSB.Name = "lbUSB";
            this.lbUSB.Size = new System.Drawing.Size(29, 13);
            this.lbUSB.TabIndex = 8;
            this.lbUSB.Text = "USB";
            // 
            // txtUsb
            // 
            this.txtUsb.Location = new System.Drawing.Point(614, 73);
            this.txtUsb.Margin = new System.Windows.Forms.Padding(2);
            this.txtUsb.Name = "txtUsb";
            this.txtUsb.Size = new System.Drawing.Size(292, 20);
            this.txtUsb.TabIndex = 9;
            // 
            // contextMenu
            // 
            this.contextMenu.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.contextMenu.Name = "contextMenuStrip1";
            this.contextMenu.Size = new System.Drawing.Size(61, 4);
            // 
            // contextMenuOutside
            // 
            this.contextMenuOutside.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.newToolStripMenuItem,
            this.pasteToolStripMenuItem,
            this.viewToolStripMenuItem,
            this.refreshToolStripMenuItem});
            this.contextMenuOutside.Name = "contextMenuOutside";
            this.contextMenuOutside.Size = new System.Drawing.Size(181, 114);
            // 
            // newToolStripMenuItem
            // 
            this.newToolStripMenuItem.Name = "newToolStripMenuItem";
            this.newToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.newToolStripMenuItem.Text = "New";
            // 
            // pasteToolStripMenuItem
            // 
            this.pasteToolStripMenuItem.Name = "pasteToolStripMenuItem";
            this.pasteToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.pasteToolStripMenuItem.Text = "Paste";
            // 
            // viewToolStripMenuItem
            // 
            this.viewToolStripMenuItem.Name = "viewToolStripMenuItem";
            this.viewToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.viewToolStripMenuItem.Text = "View";
            // 
            // refreshToolStripMenuItem
            // 
            this.refreshToolStripMenuItem.Name = "refreshToolStripMenuItem";
            this.refreshToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.refreshToolStripMenuItem.Text = "Refresh";
            // 
            // Default
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1028, 609);
            this.Controls.Add(this.txtUsb);
            this.Controls.Add(this.lbUSB);
            this.Controls.Add(this.lstUsb);
            this.Controls.Add(this.lstDesktop);
            this.Controls.Add(this.dateTimePicker1);
            this.Controls.Add(this.txtFilepath);
            this.Controls.Add(this.ddlDisk);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "Default";
            this.Text = "USB - PPA";
            this.Load += new System.EventHandler(this.Default_Load);
            this.contextMenuOutside.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.ComboBox ddlDisk;
        private System.Windows.Forms.TextBox txtFilepath;
        private System.Windows.Forms.DateTimePicker dateTimePicker1;
        private System.Windows.Forms.ListView lstDesktop;
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
        private System.Windows.Forms.ContextMenuStrip contextMenu;
        private System.Windows.Forms.ContextMenuStrip contextMenuOutside;
        private System.Windows.Forms.ToolStripMenuItem newToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem pasteToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem viewToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem refreshToolStripMenuItem;
    }
}