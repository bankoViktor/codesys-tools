namespace ConfigEditor.Forms
{
    partial class SymbolForm
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
            this.SymbolListView = new System.Windows.Forms.ListView();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.SymbolColumnHeader = new System.Windows.Forms.ColumnHeader();
            this.SizeColumnHeader = new System.Windows.Forms.ColumnHeader();
            this.AddressColumnHeader = new System.Windows.Forms.ColumnHeader();
            this.WordOffsetColumnHeader = new System.Windows.Forms.ColumnHeader();
            this.BitOffsetColumnHeader = new System.Windows.Forms.ColumnHeader();
            this.SuspendLayout();
            // 
            // SymbolListView
            // 
            this.SymbolListView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.SymbolListView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.SymbolColumnHeader,
            this.SizeColumnHeader,
            this.AddressColumnHeader,
            this.WordOffsetColumnHeader,
            this.BitOffsetColumnHeader});
            this.SymbolListView.FullRowSelect = true;
            this.SymbolListView.GridLines = true;
            this.SymbolListView.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.SymbolListView.HideSelection = true;
            this.SymbolListView.Location = new System.Drawing.Point(12, 41);
            this.SymbolListView.MultiSelect = false;
            this.SymbolListView.Name = "SymbolListView";
            this.SymbolListView.ShowGroups = false;
            this.SymbolListView.Size = new System.Drawing.Size(776, 397);
            this.SymbolListView.TabIndex = 0;
            this.SymbolListView.UseCompatibleStateImageBehavior = false;
            this.SymbolListView.View = System.Windows.Forms.View.Details;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(12, 12);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 1;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Visible = false;
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(93, 12);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 2;
            this.button2.Text = "button2";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Visible = false;
            // 
            // SymbolColumnHeader
            // 
            this.SymbolColumnHeader.Text = "Символ";
            this.SymbolColumnHeader.Width = 150;
            // 
            // SizeColumnHeader
            // 
            this.SizeColumnHeader.Text = "Размер";
            this.SizeColumnHeader.Width = 80;
            // 
            // AddressColumnHeader
            // 
            this.AddressColumnHeader.Text = "IEC адрес";
            this.AddressColumnHeader.Width = 120;
            // 
            // WordOffsetColumnHeader
            // 
            this.WordOffsetColumnHeader.Text = "WORD-смещение";
            this.WordOffsetColumnHeader.Width = 120;
            // 
            // BitOffsetColumnHeader
            // 
            this.BitOffsetColumnHeader.Text = "BIT-смещение";
            this.BitOffsetColumnHeader.Width = 120;
            // 
            // SymbolForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.SymbolListView);
            this.Name = "SymbolForm";
            this.Text = "SymbolForm";
            this.ResumeLayout(false);

        }

        #endregion

        private ListView SymbolListView;
        private Button button1;
        private Button button2;
        private ColumnHeader SymbolColumnHeader;
        private ColumnHeader SizeColumnHeader;
        private ColumnHeader AddressColumnHeader;
        private ColumnHeader WordOffsetColumnHeader;
        private ColumnHeader BitOffsetColumnHeader;
    }
}