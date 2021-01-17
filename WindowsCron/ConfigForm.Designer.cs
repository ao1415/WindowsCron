namespace WindowsCron
{
    partial class ConfigForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ConfigForm));
            this.configListView = new System.Windows.Forms.ListView();
            this.columnHeaderName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeaderTiming = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeaderCommand = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeaderEanbled = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.contextMenuStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.appendToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.deleteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.configGroupBox = new System.Windows.Forms.GroupBox();
            this.paramTextBox = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.explainTextBox = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.nameTextBox = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.testButton = new System.Windows.Forms.Button();
            this.saveButton = new System.Windows.Forms.Button();
            this.FileDialogButton = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.filepathTextBox = new System.Windows.Forms.TextBox();
            this.timingTextBox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.enabledCheckBox = new System.Windows.Forms.CheckBox();
            this.openFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.contextMenuStrip.SuspendLayout();
            this.configGroupBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // configListView
            // 
            this.configListView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.configListView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeaderName,
            this.columnHeaderTiming,
            this.columnHeaderCommand,
            this.columnHeaderEanbled});
            this.configListView.ContextMenuStrip = this.contextMenuStrip;
            this.configListView.FullRowSelect = true;
            this.configListView.GridLines = true;
            this.configListView.HideSelection = false;
            this.configListView.Location = new System.Drawing.Point(12, 12);
            this.configListView.MultiSelect = false;
            this.configListView.Name = "configListView";
            this.configListView.Size = new System.Drawing.Size(776, 191);
            this.configListView.TabIndex = 0;
            this.configListView.TabStop = false;
            this.configListView.UseCompatibleStateImageBehavior = false;
            this.configListView.View = System.Windows.Forms.View.Details;
            this.configListView.SelectedIndexChanged += new System.EventHandler(this.configListView_SelectedIndexChanged);
            // 
            // columnHeaderName
            // 
            this.columnHeaderName.Text = "名前";
            this.columnHeaderName.Width = 200;
            // 
            // columnHeaderTiming
            // 
            this.columnHeaderTiming.Text = "タイミング";
            this.columnHeaderTiming.Width = 150;
            // 
            // columnHeaderCommand
            // 
            this.columnHeaderCommand.Text = "コマンド";
            this.columnHeaderCommand.Width = 350;
            // 
            // columnHeaderEanbled
            // 
            this.columnHeaderEanbled.Text = "有効";
            this.columnHeaderEanbled.Width = 72;
            // 
            // contextMenuStrip
            // 
            this.contextMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.appendToolStripMenuItem,
            this.deleteToolStripMenuItem});
            this.contextMenuStrip.Name = "contextMenuStrip";
            this.contextMenuStrip.Size = new System.Drawing.Size(123, 48);
            this.contextMenuStrip.Opening += new System.ComponentModel.CancelEventHandler(this.contextMenuStrip_Opening);
            // 
            // appendToolStripMenuItem
            // 
            this.appendToolStripMenuItem.Name = "appendToolStripMenuItem";
            this.appendToolStripMenuItem.Size = new System.Drawing.Size(122, 22);
            this.appendToolStripMenuItem.Text = "新規追加";
            this.appendToolStripMenuItem.Click += new System.EventHandler(this.appendToolStripMenuItem_Click);
            // 
            // deleteToolStripMenuItem
            // 
            this.deleteToolStripMenuItem.Name = "deleteToolStripMenuItem";
            this.deleteToolStripMenuItem.Size = new System.Drawing.Size(122, 22);
            this.deleteToolStripMenuItem.Text = "削除";
            this.deleteToolStripMenuItem.Click += new System.EventHandler(this.deleteToolStripMenuItem_Click);
            // 
            // configGroupBox
            // 
            this.configGroupBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.configGroupBox.Controls.Add(this.paramTextBox);
            this.configGroupBox.Controls.Add(this.label5);
            this.configGroupBox.Controls.Add(this.explainTextBox);
            this.configGroupBox.Controls.Add(this.label4);
            this.configGroupBox.Controls.Add(this.nameTextBox);
            this.configGroupBox.Controls.Add(this.label3);
            this.configGroupBox.Controls.Add(this.testButton);
            this.configGroupBox.Controls.Add(this.saveButton);
            this.configGroupBox.Controls.Add(this.FileDialogButton);
            this.configGroupBox.Controls.Add(this.label2);
            this.configGroupBox.Controls.Add(this.filepathTextBox);
            this.configGroupBox.Controls.Add(this.timingTextBox);
            this.configGroupBox.Controls.Add(this.label1);
            this.configGroupBox.Controls.Add(this.enabledCheckBox);
            this.configGroupBox.Location = new System.Drawing.Point(12, 209);
            this.configGroupBox.Name = "configGroupBox";
            this.configGroupBox.Size = new System.Drawing.Size(776, 226);
            this.configGroupBox.TabIndex = 1;
            this.configGroupBox.TabStop = false;
            this.configGroupBox.Text = "設定";
            // 
            // paramTextBox
            // 
            this.paramTextBox.Location = new System.Drawing.Point(76, 143);
            this.paramTextBox.Name = "paramTextBox";
            this.paramTextBox.Size = new System.Drawing.Size(695, 19);
            this.paramTextBox.TabIndex = 11;
            this.paramTextBox.TextChanged += new System.EventHandler(this.configTextBox_TextChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(7, 146);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(49, 12);
            this.label5.TabIndex = 10;
            this.label5.Text = "パラメータ";
            // 
            // explainTextBox
            // 
            this.explainTextBox.Location = new System.Drawing.Point(76, 68);
            this.explainTextBox.Name = "explainTextBox";
            this.explainTextBox.Size = new System.Drawing.Size(695, 19);
            this.explainTextBox.TabIndex = 4;
            this.explainTextBox.TextChanged += new System.EventHandler(this.configTextBox_TextChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(7, 71);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(29, 12);
            this.label4.TabIndex = 3;
            this.label4.Text = "説明";
            // 
            // nameTextBox
            // 
            this.nameTextBox.Location = new System.Drawing.Point(76, 43);
            this.nameTextBox.Name = "nameTextBox";
            this.nameTextBox.Size = new System.Drawing.Size(695, 19);
            this.nameTextBox.TabIndex = 2;
            this.nameTextBox.TextChanged += new System.EventHandler(this.configTextBox_TextChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(7, 46);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(29, 12);
            this.label3.TabIndex = 1;
            this.label3.Text = "名前";
            // 
            // testButton
            // 
            this.testButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.testButton.Location = new System.Drawing.Point(6, 197);
            this.testButton.Name = "testButton";
            this.testButton.Size = new System.Drawing.Size(75, 23);
            this.testButton.TabIndex = 12;
            this.testButton.Text = "テスト";
            this.testButton.UseVisualStyleBackColor = true;
            this.testButton.Click += new System.EventHandler(this.testButton_Click);
            // 
            // saveButton
            // 
            this.saveButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.saveButton.Location = new System.Drawing.Point(695, 197);
            this.saveButton.Name = "saveButton";
            this.saveButton.Size = new System.Drawing.Size(75, 23);
            this.saveButton.TabIndex = 13;
            this.saveButton.Text = "保存";
            this.saveButton.UseVisualStyleBackColor = true;
            this.saveButton.Click += new System.EventHandler(this.saveButton_Click);
            // 
            // FileDialogButton
            // 
            this.FileDialogButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.FileDialogButton.Location = new System.Drawing.Point(711, 116);
            this.FileDialogButton.Name = "FileDialogButton";
            this.FileDialogButton.Size = new System.Drawing.Size(60, 23);
            this.FileDialogButton.TabIndex = 9;
            this.FileDialogButton.Text = "開く";
            this.FileDialogButton.UseVisualStyleBackColor = true;
            this.FileDialogButton.Click += new System.EventHandler(this.fileDialogButton_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(7, 121);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(63, 12);
            this.label2.TabIndex = 7;
            this.label2.Text = "実行ファイル";
            // 
            // filepathTextBox
            // 
            this.filepathTextBox.Location = new System.Drawing.Point(76, 118);
            this.filepathTextBox.Name = "filepathTextBox";
            this.filepathTextBox.Size = new System.Drawing.Size(629, 19);
            this.filepathTextBox.TabIndex = 8;
            this.filepathTextBox.TextChanged += new System.EventHandler(this.configTextBox_TextChanged);
            // 
            // timingTextBox
            // 
            this.timingTextBox.Location = new System.Drawing.Point(76, 93);
            this.timingTextBox.Name = "timingTextBox";
            this.timingTextBox.Size = new System.Drawing.Size(695, 19);
            this.timingTextBox.TabIndex = 6;
            this.timingTextBox.TextChanged += new System.EventHandler(this.configTextBox_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(7, 96);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 12);
            this.label1.TabIndex = 5;
            this.label1.Text = "実行間隔";
            // 
            // enabledCheckBox
            // 
            this.enabledCheckBox.AutoSize = true;
            this.enabledCheckBox.Checked = true;
            this.enabledCheckBox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.enabledCheckBox.Location = new System.Drawing.Point(6, 18);
            this.enabledCheckBox.Name = "enabledCheckBox";
            this.enabledCheckBox.Size = new System.Drawing.Size(60, 16);
            this.enabledCheckBox.TabIndex = 0;
            this.enabledCheckBox.Text = "有効化";
            this.enabledCheckBox.UseVisualStyleBackColor = true;
            this.enabledCheckBox.CheckedChanged += new System.EventHandler(this.enabledCheckBox_CheckedChanged);
            // 
            // openFileDialog
            // 
            this.openFileDialog.DefaultExt = "ps1";
            this.openFileDialog.Filter = "PowerShellファイル|*.ps1|すべてのファイル|*.*";
            this.openFileDialog.Title = "開く";
            // 
            // ConfigForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.configGroupBox);
            this.Controls.Add(this.configListView);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ConfigForm";
            this.Text = "Config";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.ConfigForm_FormClosing);
            this.Load += new System.EventHandler(this.ConfigForm_Load);
            this.contextMenuStrip.ResumeLayout(false);
            this.configGroupBox.ResumeLayout(false);
            this.configGroupBox.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListView configListView;
        private System.Windows.Forms.ColumnHeader columnHeaderName;
        private System.Windows.Forms.ColumnHeader columnHeaderCommand;
        private System.Windows.Forms.ColumnHeader columnHeaderEanbled;
        private System.Windows.Forms.GroupBox configGroupBox;
        private System.Windows.Forms.CheckBox enabledCheckBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox filepathTextBox;
        private System.Windows.Forms.TextBox timingTextBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button FileDialogButton;
        private System.Windows.Forms.Button saveButton;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip;
        private System.Windows.Forms.ToolStripMenuItem appendToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem deleteToolStripMenuItem;
        private System.Windows.Forms.OpenFileDialog openFileDialog;
        private System.Windows.Forms.ColumnHeader columnHeaderTiming;
        private System.Windows.Forms.Button testButton;
        private System.Windows.Forms.TextBox nameTextBox;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox paramTextBox;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox explainTextBox;
        private System.Windows.Forms.Label label4;
    }
}