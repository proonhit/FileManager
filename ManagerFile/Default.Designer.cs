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
            this.smallIconToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.largeIconToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.listToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.detailToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.refreshToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.contextMenuOutside.SuspendLayout();
            this.SuspendLayout();
            // 
            // ddlDisk
            // 
            this.ddlDisk.FormattingEnabled = true;
            this.ddlDisk.Location = new System.Drawing.Point(12, 89);
            this.ddlDisk.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.ddlDisk.Name = "ddlDisk";
            this.ddlDisk.Size = new System.Drawing.Size(137, 24);
            this.ddlDisk.TabIndex = 2;
            this.ddlDisk.SelectedIndexChanged += new System.EventHandler(this.ddlDisk_SelectedIndexChanged);
            // 
            // txtFilepath
            // 
            this.txtFilepath.Enabled = false;
            this.txtFilepath.Location = new System.Drawing.Point(156, 89);
            this.txtFilepath.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtFilepath.Name = "txtFilepath";
            this.txtFilepath.Size = new System.Drawing.Size(337, 22);
            this.txtFilepath.TabIndex = 3;
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.Location = new System.Drawing.Point(475, 319);
            this.dateTimePicker1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(200, 22);
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
            this.lstDesktop.Location = new System.Drawing.Point(12, 132);
            this.lstDesktop.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.lstDesktop.Name = "lstDesktop";
            this.lstDesktop.Size = new System.Drawing.Size(736, 606);
            this.lstDesktop.TabIndex = 6;
            this.lstDesktop.UseCompatibleStateImageBehavior = false;
            this.lstDesktop.ItemDrag += new System.Windows.Forms.ItemDragEventHandler(this.listDesktop_ItemDrag);
            this.lstDesktop.KeyDown += new System.Windows.Forms.KeyEventHandler(this.LstDesktop_KeyDown);
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
            this.lstUsb.Location = new System.Drawing.Point(755, 132);
            this.lstUsb.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.lstUsb.Name = "lstUsb";
            this.lstUsb.Size = new System.Drawing.Size(736, 606);
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
            this.lbUSB.Location = new System.Drawing.Point(755, 95);
            this.lbUSB.Name = "lbUSB";
            this.lbUSB.Size = new System.Drawing.Size(35, 16);
            this.lbUSB.TabIndex = 8;
            this.lbUSB.Text = "USB";
            // 
            // txtUsb
            // 
            this.txtUsb.Location = new System.Drawing.Point(819, 90);
            this.txtUsb.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtUsb.Name = "txtUsb";
            this.txtUsb.Size = new System.Drawing.Size(388, 22);
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
            this.contextMenuOutside.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.contextMenuOutside.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.newToolStripMenuItem,
            this.pasteToolStripMenuItem,
            this.viewToolStripMenuItem,
            this.refreshToolStripMenuItem});
            this.contextMenuOutside.Name = "contextMenuOutside";
            this.contextMenuOutside.Size = new System.Drawing.Size(128, 100);
            // 
            // newToolStripMenuItem
            // 
            this.newToolStripMenuItem.Name = "newToolStripMenuItem";
            this.newToolStripMenuItem.Size = new System.Drawing.Size(127, 24);
            this.newToolStripMenuItem.Text = "New";
            this.newToolStripMenuItem.Click += new System.EventHandler(this.NewFolder_Click);
            // 
            // pasteToolStripMenuItem
            // 
            this.pasteToolStripMenuItem.Name = "pasteToolStripMenuItem";
            this.pasteToolStripMenuItem.Size = new System.Drawing.Size(127, 24);
            this.pasteToolStripMenuItem.Text = "Paste";
            this.pasteToolStripMenuItem.Click += new System.EventHandler(this.PasteToolStripMenuItem_Click);
            // 
            // viewToolStripMenuItem
            // 
            this.viewToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.smallIconToolStripMenuItem,
            this.largeIconToolStripMenuItem,
            this.listToolStripMenuItem,
            this.detailToolStripMenuItem});
            this.viewToolStripMenuItem.Name = "viewToolStripMenuItem";
            this.viewToolStripMenuItem.Size = new System.Drawing.Size(127, 24);
            this.viewToolStripMenuItem.Text = "View";
            // 
            // smallIconToolStripMenuItem
            // 
            this.smallIconToolStripMenuItem.Name = "smallIconToolStripMenuItem";
            this.smallIconToolStripMenuItem.Size = new System.Drawing.Size(161, 26);
            this.smallIconToolStripMenuItem.Text = "Small Icon";
            this.smallIconToolStripMenuItem.Click += new System.EventHandler(this.SmallIconToolStripMenuItem_Click);
            // 
            // largeIconToolStripMenuItem
            // 
            this.largeIconToolStripMenuItem.Name = "largeIconToolStripMenuItem";
            this.largeIconToolStripMenuItem.Size = new System.Drawing.Size(161, 26);
            this.largeIconToolStripMenuItem.Text = "Large Icon";
            this.largeIconToolStripMenuItem.Click += new System.EventHandler(this.LargeIconToolStripMenuItem_Click);
            // 
            // listToolStripMenuItem
            // 
            this.listToolStripMenuItem.Name = "listToolStripMenuItem";
            this.listToolStripMenuItem.Size = new System.Drawing.Size(161, 26);
            this.listToolStripMenuItem.Text = "List";
            this.listToolStripMenuItem.Click += new System.EventHandler(this.ListToolStripMenuItem_Click);
            // 
            // detailToolStripMenuItem
            // 
            this.detailToolStripMenuItem.Name = "detailToolStripMenuItem";
            this.detailToolStripMenuItem.Size = new System.Drawing.Size(161, 26);
            this.detailToolStripMenuItem.Text = "Detail";
            this.detailToolStripMenuItem.Click += new System.EventHandler(this.DetailToolStripMenuItem_Click);
            // 
            // refreshToolStripMenuItem
            // 
            this.refreshToolStripMenuItem.Name = "refreshToolStripMenuItem";
            this.refreshToolStripMenuItem.Size = new System.Drawing.Size(127, 24);
            this.refreshToolStripMenuItem.Text = "Refresh";
            this.refreshToolStripMenuItem.Click += new System.EventHandler(this.RefreshToolStripMenuItem_Click);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(211, 32);
            // 
            // Default
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1408, 750);
            this.Controls.Add(this.txtUsb);
            this.Controls.Add(this.lbUSB);
            this.Controls.Add(this.lstUsb);
            this.Controls.Add(this.lstDesktop);
            this.Controls.Add(this.dateTimePicker1);
            this.Controls.Add(this.txtFilepath);
            this.Controls.Add(this.ddlDisk);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
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
        private System.Windows.Forms.ToolStripMenuItem smallIconToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem largeIconToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem listToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem detailToolStripMenuItem;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
    }
}