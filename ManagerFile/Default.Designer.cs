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
            this.txtUsb = new System.Windows.Forms.TextBox();
            this.contextMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.renameToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.deleteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.copyToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.viewToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.propertyToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.contextMenuOutside = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.newToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pasteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.viewToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.smallIconToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.largeIconToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.listToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.detailToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.refreshToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.contextMenuUsb = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.renameUsbStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.deleteUsbStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.copyUsbStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.viewUsbStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.propertyStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.refreshUsbToolStripMenuItem = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.newUsbStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pasteUsbStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.viewUsbToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.smallIconUsbToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.largeIconUsbToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.listUsbToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.detailUsbToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem8 = new System.Windows.Forms.ToolStripMenuItem();
            this.ddlUsb = new System.Windows.Forms.ComboBox();
            this.contextMenu.SuspendLayout();
            this.contextMenuOutside.SuspendLayout();
            this.contextMenuUsb.SuspendLayout();
            this.refreshUsbToolStripMenuItem.SuspendLayout();
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
            this.lstUsb.Location = new System.Drawing.Point(758, 132);
            this.lstUsb.Margin = new System.Windows.Forms.Padding(2);
            this.lstUsb.Name = "lstUsb";
            this.lstUsb.Size = new System.Drawing.Size(736, 606);
            this.lstUsb.TabIndex = 7;
            this.lstUsb.UseCompatibleStateImageBehavior = false;
            this.lstUsb.DragDrop += new System.Windows.Forms.DragEventHandler(this.lstUsb_DragDrop);
            this.lstUsb.DragEnter += new System.Windows.Forms.DragEventHandler(this.lstUsb_DragEnter);
            this.lstUsb.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.lstUsb_MouseDoubleClick);
            this.lstUsb.MouseUp += new System.Windows.Forms.MouseEventHandler(this.LstUsb_MouseUp);
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
            // txtUsb
            // 
            this.txtUsb.Enabled = false;
            this.txtUsb.Location = new System.Drawing.Point(903, 89);
            this.txtUsb.Margin = new System.Windows.Forms.Padding(2);
            this.txtUsb.Name = "txtUsb";
            this.txtUsb.Size = new System.Drawing.Size(388, 22);
            this.txtUsb.TabIndex = 9;
            // 
            // contextMenu
            // 
            this.contextMenu.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.contextMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.renameToolStripMenuItem,
            this.deleteToolStripMenuItem,
            this.copyToolStripMenuItem,
            this.viewToolStripMenuItem1,
            this.propertyToolStripMenuItem});
            this.contextMenu.Name = "contextMenuStrip1";
            this.contextMenu.Size = new System.Drawing.Size(135, 124);
            // 
            // renameToolStripMenuItem
            // 
            this.renameToolStripMenuItem.Name = "renameToolStripMenuItem";
            this.renameToolStripMenuItem.Size = new System.Drawing.Size(134, 24);
            this.renameToolStripMenuItem.Text = "Rename";
            this.renameToolStripMenuItem.Click += new System.EventHandler(this.RenameMenuItem_Click);
            // 
            // deleteToolStripMenuItem
            // 
            this.deleteToolStripMenuItem.Name = "deleteToolStripMenuItem";
            this.deleteToolStripMenuItem.Size = new System.Drawing.Size(134, 24);
            this.deleteToolStripMenuItem.Text = "Delete";
            this.deleteToolStripMenuItem.Click += new System.EventHandler(this.DeleteMenuItem_Click);
            // 
            // copyToolStripMenuItem
            // 
            this.copyToolStripMenuItem.Name = "copyToolStripMenuItem";
            this.copyToolStripMenuItem.Size = new System.Drawing.Size(134, 24);
            this.copyToolStripMenuItem.Text = "Copy";
            this.copyToolStripMenuItem.Click += new System.EventHandler(this.CopyMenuItem_Click);
            // 
            // viewToolStripMenuItem1
            // 
            this.viewToolStripMenuItem1.Name = "viewToolStripMenuItem1";
            this.viewToolStripMenuItem1.Size = new System.Drawing.Size(134, 24);
            this.viewToolStripMenuItem1.Text = "View";
            this.viewToolStripMenuItem1.Click += new System.EventHandler(this.ViewMenuItem_Click);
            // 
            // propertyToolStripMenuItem
            // 
            this.propertyToolStripMenuItem.Name = "propertyToolStripMenuItem";
            this.propertyToolStripMenuItem.Size = new System.Drawing.Size(134, 24);
            this.propertyToolStripMenuItem.Text = "Property";
            this.propertyToolStripMenuItem.Click += new System.EventHandler(this.PropertyMenuItem_Click);
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
            // contextMenuUsb
            // 
            this.contextMenuUsb.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.contextMenuUsb.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.renameUsbStripMenuItem,
            this.deleteUsbStripMenuItem,
            this.copyUsbStripMenuItem,
            this.viewUsbStripMenuItem,
            this.propertyStripMenuItem});
            this.contextMenuUsb.Name = "contextMenuStrip1";
            this.contextMenuUsb.Size = new System.Drawing.Size(135, 124);
            this.contextMenuUsb.Click += new System.EventHandler(this.ViewMenuItem_Click);
            // 
            // renameUsbStripMenuItem
            // 
            this.renameUsbStripMenuItem.Name = "renameUsbStripMenuItem";
            this.renameUsbStripMenuItem.Size = new System.Drawing.Size(134, 24);
            this.renameUsbStripMenuItem.Text = "Rename";
            this.renameUsbStripMenuItem.Click += new System.EventHandler(this.RenameUsbStripMenuItem_Click);
            // 
            // deleteUsbStripMenuItem
            // 
            this.deleteUsbStripMenuItem.Name = "deleteUsbStripMenuItem";
            this.deleteUsbStripMenuItem.Size = new System.Drawing.Size(134, 24);
            this.deleteUsbStripMenuItem.Text = "Delete";
            this.deleteUsbStripMenuItem.Click += new System.EventHandler(this.DeleteMenuItem_Click);
            // 
            // copyUsbStripMenuItem
            // 
            this.copyUsbStripMenuItem.Name = "copyUsbStripMenuItem";
            this.copyUsbStripMenuItem.Size = new System.Drawing.Size(134, 24);
            this.copyUsbStripMenuItem.Text = "Copy";
            this.copyUsbStripMenuItem.Click += new System.EventHandler(this.CopyUsbStripMenuItem_Click);
            // 
            // viewUsbStripMenuItem
            // 
            this.viewUsbStripMenuItem.Name = "viewUsbStripMenuItem";
            this.viewUsbStripMenuItem.Size = new System.Drawing.Size(134, 24);
            this.viewUsbStripMenuItem.Text = "View";
            // 
            // propertyStripMenuItem
            // 
            this.propertyStripMenuItem.Name = "propertyStripMenuItem";
            this.propertyStripMenuItem.Size = new System.Drawing.Size(134, 24);
            this.propertyStripMenuItem.Text = "Property";
            this.propertyStripMenuItem.Click += new System.EventHandler(this.PropertyMenuItem_Click);
            // 
            // refreshUsbToolStripMenuItem
            // 
            this.refreshUsbToolStripMenuItem.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.refreshUsbToolStripMenuItem.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.newUsbStripMenuItem,
            this.pasteUsbStripMenuItem,
            this.viewUsbToolStripMenuItem,
            this.toolStripMenuItem8});
            this.refreshUsbToolStripMenuItem.Name = "contextMenuOutside";
            this.refreshUsbToolStripMenuItem.Size = new System.Drawing.Size(128, 100);
            this.refreshUsbToolStripMenuItem.Click += new System.EventHandler(this.RenameUsbStripMenuItem_Click);
            // 
            // newUsbStripMenuItem
            // 
            this.newUsbStripMenuItem.Name = "newUsbStripMenuItem";
            this.newUsbStripMenuItem.Size = new System.Drawing.Size(127, 24);
            this.newUsbStripMenuItem.Text = "New";
            this.newUsbStripMenuItem.Click += new System.EventHandler(this.NewUsbStripMenuItem_Click);
            // 
            // pasteUsbStripMenuItem
            // 
            this.pasteUsbStripMenuItem.Name = "pasteUsbStripMenuItem";
            this.pasteUsbStripMenuItem.Size = new System.Drawing.Size(127, 24);
            this.pasteUsbStripMenuItem.Text = "Paste";
            this.pasteUsbStripMenuItem.Click += new System.EventHandler(this.PasteUsbStripMenuItem_Click);
            // 
            // viewUsbToolStripMenuItem
            // 
            this.viewUsbToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.smallIconUsbToolStripMenuItem,
            this.largeIconUsbToolStripMenuItem,
            this.listUsbToolStripMenuItem,
            this.detailUsbToolStripMenuItem});
            this.viewUsbToolStripMenuItem.Name = "viewUsbToolStripMenuItem";
            this.viewUsbToolStripMenuItem.Size = new System.Drawing.Size(127, 24);
            this.viewUsbToolStripMenuItem.Text = "View";
            // 
            // smallIconUsbToolStripMenuItem
            // 
            this.smallIconUsbToolStripMenuItem.Name = "smallIconUsbToolStripMenuItem";
            this.smallIconUsbToolStripMenuItem.Size = new System.Drawing.Size(161, 26);
            this.smallIconUsbToolStripMenuItem.Text = "Small Icon";
            this.smallIconUsbToolStripMenuItem.Click += new System.EventHandler(this.SmallIconUsbToolStripMenuItem_Click);
            // 
            // largeIconUsbToolStripMenuItem
            // 
            this.largeIconUsbToolStripMenuItem.Name = "largeIconUsbToolStripMenuItem";
            this.largeIconUsbToolStripMenuItem.Size = new System.Drawing.Size(161, 26);
            this.largeIconUsbToolStripMenuItem.Text = "Large Icon";
            this.largeIconUsbToolStripMenuItem.Click += new System.EventHandler(this.LargeIconUsbToolStripMenuItem_Click);
            // 
            // listUsbToolStripMenuItem
            // 
            this.listUsbToolStripMenuItem.Name = "listUsbToolStripMenuItem";
            this.listUsbToolStripMenuItem.Size = new System.Drawing.Size(161, 26);
            this.listUsbToolStripMenuItem.Text = "List";
            this.listUsbToolStripMenuItem.Click += new System.EventHandler(this.ListUsbToolStripMenuItem_Click);
            // 
            // detailUsbToolStripMenuItem
            // 
            this.detailUsbToolStripMenuItem.Name = "detailUsbToolStripMenuItem";
            this.detailUsbToolStripMenuItem.Size = new System.Drawing.Size(161, 26);
            this.detailUsbToolStripMenuItem.Text = "Detail";
            this.detailUsbToolStripMenuItem.Click += new System.EventHandler(this.DetailUsbToolStripMenuItem_Click);
            // 
            // toolStripMenuItem8
            // 
            this.toolStripMenuItem8.Name = "toolStripMenuItem8";
            this.toolStripMenuItem8.Size = new System.Drawing.Size(127, 24);
            this.toolStripMenuItem8.Text = "Refresh";
            this.toolStripMenuItem8.Click += new System.EventHandler(this.RefreshUsbToolStripMenuItem_Click);
            // 
            // ddlUsb
            // 
            this.ddlUsb.FormattingEnabled = true;
            this.ddlUsb.Location = new System.Drawing.Point(758, 89);
            this.ddlUsb.Name = "ddlUsb";
            this.ddlUsb.Size = new System.Drawing.Size(131, 24);
            this.ddlUsb.TabIndex = 10;
            this.ddlUsb.SelectedIndexChanged += new System.EventHandler(this.ddlUsb_SelectedIndexChanged);
            // 
            // Default
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1508, 750);
            this.Controls.Add(this.ddlUsb);
            this.Controls.Add(this.txtUsb);
            this.Controls.Add(this.lstUsb);
            this.Controls.Add(this.lstDesktop);
            this.Controls.Add(this.dateTimePicker1);
            this.Controls.Add(this.txtFilepath);
            this.Controls.Add(this.ddlDisk);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Text = "USB - PPA";
            this.Load += new System.EventHandler(this.Default_Load);
            this.contextMenu.ResumeLayout(false);
            this.contextMenuOutside.ResumeLayout(false);
            this.contextMenuUsb.ResumeLayout(false);
            this.refreshUsbToolStripMenuItem.ResumeLayout(false);
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
        private System.Windows.Forms.ToolStripMenuItem renameToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem deleteToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem copyToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem viewToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem propertyToolStripMenuItem;
        private System.Windows.Forms.ContextMenuStrip contextMenuUsb;
        private System.Windows.Forms.ToolStripMenuItem renameUsbStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem deleteUsbStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem copyUsbStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem viewUsbStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem propertyStripMenuItem;
        private System.Windows.Forms.ContextMenuStrip refreshUsbToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem newUsbStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem pasteUsbStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem viewUsbToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem smallIconUsbToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem largeIconUsbToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem listUsbToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem detailUsbToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem8;
        private System.Windows.Forms.ComboBox ddlUsb;
    }
}