namespace ConfigEditor.Forms
{
    partial class MainForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.EntityTreeView = new System.Windows.Forms.TreeView();
            this.TreeViewContextMenuStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.AddModuleToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.AddChannelToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.AddByteChannelToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.AddWordChannelToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.AddDWordChannelToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.AddQWordChannelToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ToolStripMenuItem5 = new System.Windows.Forms.ToolStripSeparator();
            this.CutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.CopyToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.PasteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.DeleteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.DuplicateToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ToolStripMenuItem6 = new System.Windows.Forms.ToolStripSeparator();
            this.ExpandToggleSegmentToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ImageList = new System.Windows.Forms.ImageList(this.components);
            this.PropertyGrid = new System.Windows.Forms.PropertyGrid();
            this.SplitContainer = new System.Windows.Forms.SplitContainer();
            this.MenuStrip = new System.Windows.Forms.MenuStrip();
            this.FileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.FileOpenToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.FileSaveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.FileSaveAsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.FileToolStripMenuItem1 = new System.Windows.Forms.ToolStripSeparator();
            this.FileExportEBPMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.FileToolStripMenuItem2 = new System.Windows.Forms.ToolStripSeparator();
            this.FileExitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.EditToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.EditCutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.EditCopyToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.EditPasteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.EditDeleteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.EditToolStripMenuItem3 = new System.Windows.Forms.ToolStripSeparator();
            this.EditDuplicateToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.EditSelectAllToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.EditToolStripMenuItem4 = new System.Windows.Forms.ToolStripSeparator();
            this.EditExpandToggleSegmentToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.EditCollapseAllToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.EditExpandAllToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ToolsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ToolsExplorerInjectToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ToolsSelectSymbolNameToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.HelpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.HelpAboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.TreeViewContextMenuStrip.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.SplitContainer)).BeginInit();
            this.SplitContainer.Panel1.SuspendLayout();
            this.SplitContainer.Panel2.SuspendLayout();
            this.SplitContainer.SuspendLayout();
            this.MenuStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // EntityTreeView
            // 
            this.EntityTreeView.AllowDrop = true;
            this.EntityTreeView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.EntityTreeView.ContextMenuStrip = this.TreeViewContextMenuStrip;
            this.EntityTreeView.Font = new System.Drawing.Font("Consolas", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.EntityTreeView.FullRowSelect = true;
            this.EntityTreeView.HideSelection = false;
            this.EntityTreeView.ImageIndex = 0;
            this.EntityTreeView.ImageList = this.ImageList;
            this.EntityTreeView.Location = new System.Drawing.Point(12, 12);
            this.EntityTreeView.Name = "EntityTreeView";
            this.EntityTreeView.SelectedImageIndex = 0;
            this.EntityTreeView.Size = new System.Drawing.Size(457, 519);
            this.EntityTreeView.TabIndex = 0;
            this.EntityTreeView.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.EntityTreeView_AfterSelect);
            this.EntityTreeView.NodeMouseClick += new System.Windows.Forms.TreeNodeMouseClickEventHandler(this.EntityTreeView_NodeMouseClick);
            // 
            // TreeViewContextMenuStrip
            // 
            this.TreeViewContextMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.AddModuleToolStripMenuItem,
            this.AddChannelToolStripMenuItem,
            this.ToolStripMenuItem5,
            this.CutToolStripMenuItem,
            this.CopyToolStripMenuItem,
            this.PasteToolStripMenuItem,
            this.DeleteToolStripMenuItem,
            this.DuplicateToolStripMenuItem,
            this.ToolStripMenuItem6,
            this.ExpandToggleSegmentToolStripMenuItem});
            this.TreeViewContextMenuStrip.Name = "contextMenuStrip1";
            this.TreeViewContextMenuStrip.Size = new System.Drawing.Size(192, 192);
            // 
            // AddModuleToolStripMenuItem
            // 
            this.AddModuleToolStripMenuItem.Name = "AddModuleToolStripMenuItem";
            this.AddModuleToolStripMenuItem.Size = new System.Drawing.Size(191, 22);
            this.AddModuleToolStripMenuItem.Text = "Добавить модуль";
            this.AddModuleToolStripMenuItem.Click += new System.EventHandler(this.AddModuleToolStripMenuItem_Click);
            // 
            // AddChannelToolStripMenuItem
            // 
            this.AddChannelToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.AddByteChannelToolStripMenuItem,
            this.AddWordChannelToolStripMenuItem,
            this.AddDWordChannelToolStripMenuItem,
            this.AddQWordChannelToolStripMenuItem});
            this.AddChannelToolStripMenuItem.Name = "AddChannelToolStripMenuItem";
            this.AddChannelToolStripMenuItem.Size = new System.Drawing.Size(191, 22);
            this.AddChannelToolStripMenuItem.Text = "Добавить канал";
            // 
            // AddByteChannelToolStripMenuItem
            // 
            this.AddByteChannelToolStripMenuItem.Name = "AddByteChannelToolStripMenuItem";
            this.AddByteChannelToolStripMenuItem.Size = new System.Drawing.Size(118, 22);
            this.AddByteChannelToolStripMenuItem.Text = "BYTE";
            // 
            // AddWordChannelToolStripMenuItem
            // 
            this.AddWordChannelToolStripMenuItem.Name = "AddWordChannelToolStripMenuItem";
            this.AddWordChannelToolStripMenuItem.Size = new System.Drawing.Size(118, 22);
            this.AddWordChannelToolStripMenuItem.Text = "WORD";
            // 
            // AddDWordChannelToolStripMenuItem
            // 
            this.AddDWordChannelToolStripMenuItem.Name = "AddDWordChannelToolStripMenuItem";
            this.AddDWordChannelToolStripMenuItem.Size = new System.Drawing.Size(118, 22);
            this.AddDWordChannelToolStripMenuItem.Text = "DWORD";
            // 
            // AddQWordChannelToolStripMenuItem
            // 
            this.AddQWordChannelToolStripMenuItem.Name = "AddQWordChannelToolStripMenuItem";
            this.AddQWordChannelToolStripMenuItem.Size = new System.Drawing.Size(118, 22);
            this.AddQWordChannelToolStripMenuItem.Text = "QWORD";
            // 
            // ToolStripMenuItem5
            // 
            this.ToolStripMenuItem5.Name = "ToolStripMenuItem5";
            this.ToolStripMenuItem5.Size = new System.Drawing.Size(188, 6);
            // 
            // CutToolStripMenuItem
            // 
            this.CutToolStripMenuItem.Name = "CutToolStripMenuItem";
            this.CutToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.X)));
            this.CutToolStripMenuItem.Size = new System.Drawing.Size(191, 22);
            this.CutToolStripMenuItem.Text = "Вырезать";
            this.CutToolStripMenuItem.Click += new System.EventHandler(this.EditCutToolStripMenuItem_Click);
            // 
            // CopyToolStripMenuItem
            // 
            this.CopyToolStripMenuItem.Name = "CopyToolStripMenuItem";
            this.CopyToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.C)));
            this.CopyToolStripMenuItem.Size = new System.Drawing.Size(191, 22);
            this.CopyToolStripMenuItem.Text = "Копировать";
            this.CopyToolStripMenuItem.Click += new System.EventHandler(this.EditCopyToolStripMenuItem_Click);
            // 
            // PasteToolStripMenuItem
            // 
            this.PasteToolStripMenuItem.Name = "PasteToolStripMenuItem";
            this.PasteToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.V)));
            this.PasteToolStripMenuItem.Size = new System.Drawing.Size(191, 22);
            this.PasteToolStripMenuItem.Text = "Вставить";
            this.PasteToolStripMenuItem.Click += new System.EventHandler(this.EditPasteToolStripMenuItem_Click);
            // 
            // DeleteToolStripMenuItem
            // 
            this.DeleteToolStripMenuItem.Name = "DeleteToolStripMenuItem";
            this.DeleteToolStripMenuItem.ShortcutKeys = System.Windows.Forms.Keys.Delete;
            this.DeleteToolStripMenuItem.Size = new System.Drawing.Size(191, 22);
            this.DeleteToolStripMenuItem.Text = "Удалить";
            this.DeleteToolStripMenuItem.Click += new System.EventHandler(this.EditDeleteToolStripMenuItem_Click);
            // 
            // DuplicateToolStripMenuItem
            // 
            this.DuplicateToolStripMenuItem.Name = "DuplicateToolStripMenuItem";
            this.DuplicateToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.D)));
            this.DuplicateToolStripMenuItem.Size = new System.Drawing.Size(191, 22);
            this.DuplicateToolStripMenuItem.Text = "Дублировать";
            this.DuplicateToolStripMenuItem.Click += new System.EventHandler(this.EditDuplicateToolStripMenuItem_Click);
            // 
            // ToolStripMenuItem6
            // 
            this.ToolStripMenuItem6.Name = "ToolStripMenuItem6";
            this.ToolStripMenuItem6.Size = new System.Drawing.Size(188, 6);
            // 
            // ExpandToggleSegmentToolStripMenuItem
            // 
            this.ExpandToggleSegmentToolStripMenuItem.Name = "ExpandToggleSegmentToolStripMenuItem";
            this.ExpandToggleSegmentToolStripMenuItem.Size = new System.Drawing.Size(191, 22);
            this.ExpandToggleSegmentToolStripMenuItem.Text = "Свернуть/развернуть";
            this.ExpandToggleSegmentToolStripMenuItem.Click += new System.EventHandler(this.EditExpandToggleSegmentToolStripMenuItem_Click);
            // 
            // ImageList
            // 
            this.ImageList.ColorDepth = System.Windows.Forms.ColorDepth.Depth32Bit;
            this.ImageList.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("ImageList.ImageStream")));
            this.ImageList.TransparentColor = System.Drawing.Color.Transparent;
            this.ImageList.Images.SetKeyName(0, "icons8-ортогональная-проекция-16.png");
            this.ImageList.Images.SetKeyName(1, "icons8-фигурные-скобки-16.png");
            // 
            // PropertyGrid
            // 
            this.PropertyGrid.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.PropertyGrid.Font = new System.Drawing.Font("Consolas", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.PropertyGrid.Location = new System.Drawing.Point(3, 12);
            this.PropertyGrid.Name = "PropertyGrid";
            this.PropertyGrid.Size = new System.Drawing.Size(350, 519);
            this.PropertyGrid.TabIndex = 1;
            // 
            // SplitContainer
            // 
            this.SplitContainer.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.SplitContainer.Location = new System.Drawing.Point(0, 39);
            this.SplitContainer.Name = "SplitContainer";
            // 
            // SplitContainer.Panel1
            // 
            this.SplitContainer.Panel1.Controls.Add(this.EntityTreeView);
            // 
            // SplitContainer.Panel2
            // 
            this.SplitContainer.Panel2.Controls.Add(this.PropertyGrid);
            this.SplitContainer.Size = new System.Drawing.Size(841, 543);
            this.SplitContainer.SplitterDistance = 472;
            this.SplitContainer.TabIndex = 2;
            // 
            // MenuStrip
            // 
            this.MenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.FileToolStripMenuItem,
            this.EditToolStripMenuItem,
            this.ToolsToolStripMenuItem,
            this.HelpToolStripMenuItem});
            this.MenuStrip.Location = new System.Drawing.Point(0, 0);
            this.MenuStrip.Name = "MenuStrip";
            this.MenuStrip.Size = new System.Drawing.Size(841, 24);
            this.MenuStrip.TabIndex = 2;
            this.MenuStrip.Text = "menuStrip1";
            // 
            // FileToolStripMenuItem
            // 
            this.FileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.FileOpenToolStripMenuItem,
            this.FileSaveToolStripMenuItem,
            this.FileSaveAsToolStripMenuItem,
            this.FileToolStripMenuItem1,
            this.FileExportEBPMenuItem,
            this.FileToolStripMenuItem2,
            this.FileExitToolStripMenuItem});
            this.FileToolStripMenuItem.Name = "FileToolStripMenuItem";
            this.FileToolStripMenuItem.Size = new System.Drawing.Size(48, 20);
            this.FileToolStripMenuItem.Text = "Файл";
            // 
            // FileOpenToolStripMenuItem
            // 
            this.FileOpenToolStripMenuItem.Name = "FileOpenToolStripMenuItem";
            this.FileOpenToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.O)));
            this.FileOpenToolStripMenuItem.Size = new System.Drawing.Size(257, 22);
            this.FileOpenToolStripMenuItem.Text = "Открыть";
            // 
            // FileSaveToolStripMenuItem
            // 
            this.FileSaveToolStripMenuItem.Name = "FileSaveToolStripMenuItem";
            this.FileSaveToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.S)));
            this.FileSaveToolStripMenuItem.Size = new System.Drawing.Size(257, 22);
            this.FileSaveToolStripMenuItem.Text = "Сохранить";
            // 
            // FileSaveAsToolStripMenuItem
            // 
            this.FileSaveAsToolStripMenuItem.Name = "FileSaveAsToolStripMenuItem";
            this.FileSaveAsToolStripMenuItem.Size = new System.Drawing.Size(257, 22);
            this.FileSaveAsToolStripMenuItem.Text = "Сохранить как...";
            // 
            // FileToolStripMenuItem1
            // 
            this.FileToolStripMenuItem1.Name = "FileToolStripMenuItem1";
            this.FileToolStripMenuItem1.Size = new System.Drawing.Size(254, 6);
            // 
            // FileExportEBPMenuItem
            // 
            this.FileExportEBPMenuItem.Name = "FileExportEBPMenuItem";
            this.FileExportEBPMenuItem.Size = new System.Drawing.Size(257, 22);
            this.FileExportEBPMenuItem.Text = "Экспорт тегов для EasyBuilder Pro";
            // 
            // FileToolStripMenuItem2
            // 
            this.FileToolStripMenuItem2.Name = "FileToolStripMenuItem2";
            this.FileToolStripMenuItem2.Size = new System.Drawing.Size(254, 6);
            // 
            // FileExitToolStripMenuItem
            // 
            this.FileExitToolStripMenuItem.Name = "FileExitToolStripMenuItem";
            this.FileExitToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.F4)));
            this.FileExitToolStripMenuItem.Size = new System.Drawing.Size(257, 22);
            this.FileExitToolStripMenuItem.Text = "Выход";
            this.FileExitToolStripMenuItem.Click += new System.EventHandler(this.FileExitToolStripMenuItem_Click);
            // 
            // EditToolStripMenuItem
            // 
            this.EditToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.EditCutToolStripMenuItem,
            this.EditCopyToolStripMenuItem,
            this.EditPasteToolStripMenuItem,
            this.EditDeleteToolStripMenuItem,
            this.EditToolStripMenuItem3,
            this.EditDuplicateToolStripMenuItem,
            this.EditSelectAllToolStripMenuItem,
            this.EditToolStripMenuItem4,
            this.EditExpandToggleSegmentToolStripMenuItem,
            this.EditCollapseAllToolStripMenuItem,
            this.EditExpandAllToolStripMenuItem});
            this.EditToolStripMenuItem.Name = "EditToolStripMenuItem";
            this.EditToolStripMenuItem.Size = new System.Drawing.Size(59, 20);
            this.EditToolStripMenuItem.Text = "Правка";
            // 
            // EditCutToolStripMenuItem
            // 
            this.EditCutToolStripMenuItem.Name = "EditCutToolStripMenuItem";
            this.EditCutToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.X)));
            this.EditCutToolStripMenuItem.Size = new System.Drawing.Size(278, 22);
            this.EditCutToolStripMenuItem.Text = "Вырезать";
            this.EditCutToolStripMenuItem.Click += new System.EventHandler(this.EditCutToolStripMenuItem_Click);
            // 
            // EditCopyToolStripMenuItem
            // 
            this.EditCopyToolStripMenuItem.Name = "EditCopyToolStripMenuItem";
            this.EditCopyToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.C)));
            this.EditCopyToolStripMenuItem.Size = new System.Drawing.Size(278, 22);
            this.EditCopyToolStripMenuItem.Text = "Копировать";
            this.EditCopyToolStripMenuItem.Click += new System.EventHandler(this.EditCopyToolStripMenuItem_Click);
            // 
            // EditPasteToolStripMenuItem
            // 
            this.EditPasteToolStripMenuItem.Name = "EditPasteToolStripMenuItem";
            this.EditPasteToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.V)));
            this.EditPasteToolStripMenuItem.Size = new System.Drawing.Size(278, 22);
            this.EditPasteToolStripMenuItem.Text = "Вставить";
            this.EditPasteToolStripMenuItem.Click += new System.EventHandler(this.EditPasteToolStripMenuItem_Click);
            // 
            // EditDeleteToolStripMenuItem
            // 
            this.EditDeleteToolStripMenuItem.Name = "EditDeleteToolStripMenuItem";
            this.EditDeleteToolStripMenuItem.ShortcutKeys = System.Windows.Forms.Keys.Delete;
            this.EditDeleteToolStripMenuItem.Size = new System.Drawing.Size(278, 22);
            this.EditDeleteToolStripMenuItem.Text = "Удалить";
            this.EditDeleteToolStripMenuItem.Click += new System.EventHandler(this.EditDeleteToolStripMenuItem_Click);
            // 
            // EditToolStripMenuItem3
            // 
            this.EditToolStripMenuItem3.Name = "EditToolStripMenuItem3";
            this.EditToolStripMenuItem3.Size = new System.Drawing.Size(275, 6);
            // 
            // EditDuplicateToolStripMenuItem
            // 
            this.EditDuplicateToolStripMenuItem.Name = "EditDuplicateToolStripMenuItem";
            this.EditDuplicateToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.D)));
            this.EditDuplicateToolStripMenuItem.Size = new System.Drawing.Size(278, 22);
            this.EditDuplicateToolStripMenuItem.Text = "Дублировать";
            this.EditDuplicateToolStripMenuItem.Click += new System.EventHandler(this.EditDuplicateToolStripMenuItem_Click);
            // 
            // EditSelectAllToolStripMenuItem
            // 
            this.EditSelectAllToolStripMenuItem.Name = "EditSelectAllToolStripMenuItem";
            this.EditSelectAllToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.A)));
            this.EditSelectAllToolStripMenuItem.Size = new System.Drawing.Size(278, 22);
            this.EditSelectAllToolStripMenuItem.Text = "Выделить всё";
            this.EditSelectAllToolStripMenuItem.Click += new System.EventHandler(this.EditSelectAllToolStripMenuItem_Click);
            // 
            // EditToolStripMenuItem4
            // 
            this.EditToolStripMenuItem4.Name = "EditToolStripMenuItem4";
            this.EditToolStripMenuItem4.Size = new System.Drawing.Size(275, 6);
            // 
            // EditExpandToggleSegmentToolStripMenuItem
            // 
            this.EditExpandToggleSegmentToolStripMenuItem.Name = "EditExpandToggleSegmentToolStripMenuItem";
            this.EditExpandToggleSegmentToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.E)));
            this.EditExpandToggleSegmentToolStripMenuItem.Size = new System.Drawing.Size(278, 22);
            this.EditExpandToggleSegmentToolStripMenuItem.Text = "Свернуть/развернуть сегмент";
            this.EditExpandToggleSegmentToolStripMenuItem.Click += new System.EventHandler(this.EditExpandToggleSegmentToolStripMenuItem_Click);
            // 
            // EditCollapseAllToolStripMenuItem
            // 
            this.EditCollapseAllToolStripMenuItem.Name = "EditCollapseAllToolStripMenuItem";
            this.EditCollapseAllToolStripMenuItem.Size = new System.Drawing.Size(278, 22);
            this.EditCollapseAllToolStripMenuItem.Text = "Свернуть всё";
            this.EditCollapseAllToolStripMenuItem.Click += new System.EventHandler(this.EditCollapseAllToolStripMenuItem_Click);
            // 
            // EditExpandAllToolStripMenuItem
            // 
            this.EditExpandAllToolStripMenuItem.Name = "EditExpandAllToolStripMenuItem";
            this.EditExpandAllToolStripMenuItem.Size = new System.Drawing.Size(278, 22);
            this.EditExpandAllToolStripMenuItem.Text = "Развернуть всё";
            this.EditExpandAllToolStripMenuItem.Click += new System.EventHandler(this.EditExpandAllToolStripMenuItem_Click);
            // 
            // ToolsToolStripMenuItem
            // 
            this.ToolsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ToolsExplorerInjectToolStripMenuItem,
            this.ToolsSelectSymbolNameToolStripMenuItem});
            this.ToolsToolStripMenuItem.Name = "ToolsToolStripMenuItem";
            this.ToolsToolStripMenuItem.Size = new System.Drawing.Size(69, 20);
            this.ToolsToolStripMenuItem.Text = "Средства";
            // 
            // ToolsExplorerInjectToolStripMenuItem
            // 
            this.ToolsExplorerInjectToolStripMenuItem.Name = "ToolsExplorerInjectToolStripMenuItem";
            this.ToolsExplorerInjectToolStripMenuItem.Size = new System.Drawing.Size(231, 22);
            this.ToolsExplorerInjectToolStripMenuItem.Text = "Интегрировать в Проводник";
            // 
            // ToolsSelectSymbolNameToolStripMenuItem
            // 
            this.ToolsSelectSymbolNameToolStripMenuItem.Name = "ToolsSelectSymbolNameToolStripMenuItem";
            this.ToolsSelectSymbolNameToolStripMenuItem.Size = new System.Drawing.Size(231, 22);
            this.ToolsSelectSymbolNameToolStripMenuItem.Text = "Символы...";
            this.ToolsSelectSymbolNameToolStripMenuItem.Click += new System.EventHandler(this.ToolsSelectSymbolNameToolStripMenuItem_Click);
            // 
            // HelpToolStripMenuItem
            // 
            this.HelpToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.HelpAboutToolStripMenuItem});
            this.HelpToolStripMenuItem.Name = "HelpToolStripMenuItem";
            this.HelpToolStripMenuItem.Size = new System.Drawing.Size(65, 20);
            this.HelpToolStripMenuItem.Text = "Справка";
            // 
            // HelpAboutToolStripMenuItem
            // 
            this.HelpAboutToolStripMenuItem.Name = "HelpAboutToolStripMenuItem";
            this.HelpAboutToolStripMenuItem.Size = new System.Drawing.Size(149, 22);
            this.HelpAboutToolStripMenuItem.Text = "О программе";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(841, 594);
            this.Controls.Add(this.MenuStrip);
            this.Controls.Add(this.SplitContainer);
            this.MainMenuStrip = this.MenuStrip;
            this.Name = "MainForm";
            this.Text = "MainForm";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.TreeViewContextMenuStrip.ResumeLayout(false);
            this.SplitContainer.Panel1.ResumeLayout(false);
            this.SplitContainer.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.SplitContainer)).EndInit();
            this.SplitContainer.ResumeLayout(false);
            this.MenuStrip.ResumeLayout(false);
            this.MenuStrip.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private TreeView EntityTreeView;
        private PropertyGrid PropertyGrid;
        private SplitContainer SplitContainer;
        private MenuStrip MenuStrip;
        private ToolStripMenuItem FileToolStripMenuItem;
        private ToolStripMenuItem ToolsToolStripMenuItem;
        private ToolStripMenuItem ToolsExplorerInjectToolStripMenuItem;
        private ToolStripMenuItem EditToolStripMenuItem;
        private ToolStripMenuItem EditCutToolStripMenuItem;
        private ToolStripMenuItem EditCopyToolStripMenuItem;
        private ToolStripMenuItem EditPasteToolStripMenuItem;
        private ToolStripMenuItem EditDeleteToolStripMenuItem;
        private ToolStripSeparator EditToolStripMenuItem3;
        private ToolStripMenuItem EditDuplicateToolStripMenuItem;
        private ToolStripMenuItem EditSelectAllToolStripMenuItem;
        private ToolStripMenuItem FileOpenToolStripMenuItem;
        private ToolStripMenuItem FileSaveToolStripMenuItem;
        private ToolStripMenuItem FileSaveAsToolStripMenuItem;
        private ToolStripSeparator FileToolStripMenuItem2;
        private ToolStripMenuItem FileExitToolStripMenuItem;
        private ToolStripSeparator FileToolStripMenuItem1;
        private ToolStripMenuItem FileExportEBPMenuItem;
        private ContextMenuStrip TreeViewContextMenuStrip;
        private ToolStripSeparator EditToolStripMenuItem4;
        private ToolStripMenuItem EditExpandToggleSegmentToolStripMenuItem;
        private ToolStripMenuItem EditCollapseAllToolStripMenuItem;
        private ToolStripMenuItem EditExpandAllToolStripMenuItem;
        private ToolStripMenuItem HelpToolStripMenuItem;
        private ToolStripMenuItem HelpAboutToolStripMenuItem;
        private ImageList ImageList;
        private ToolStripMenuItem AddModuleToolStripMenuItem;
        private ToolStripMenuItem AddChannelToolStripMenuItem;
        private ToolStripMenuItem AddByteChannelToolStripMenuItem;
        private ToolStripMenuItem AddWordChannelToolStripMenuItem;
        private ToolStripMenuItem AddDWordChannelToolStripMenuItem;
        private ToolStripMenuItem AddQWordChannelToolStripMenuItem;
        private ToolStripSeparator ToolStripMenuItem5;
        private ToolStripMenuItem CutToolStripMenuItem;
        private ToolStripMenuItem CopyToolStripMenuItem;
        private ToolStripMenuItem PasteToolStripMenuItem;
        private ToolStripMenuItem DeleteToolStripMenuItem;
        private ToolStripMenuItem DuplicateToolStripMenuItem;
        private ToolStripSeparator ToolStripMenuItem6;
        private ToolStripMenuItem ExpandToggleSegmentToolStripMenuItem;
        private ToolStripMenuItem ToolsSelectSymbolNameToolStripMenuItem;
    }
}