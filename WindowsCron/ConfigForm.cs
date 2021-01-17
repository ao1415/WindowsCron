using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace WindowsCron
{
    public partial class ConfigForm : Form
    {
        private List<ConfigItem> configItems;

        private bool IsChange { get; set; } = false;
        private int SelectIndex { get; set; } = -1;

        public ConfigForm()
        {
            InitializeComponent();
            openFileDialog.InitialDirectory = System.Windows.Forms.Application.StartupPath;
        }

        private void enabledCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            foreach (Control control in configGroupBox.Controls)
            {
                control.Enabled = enabledCheckBox.Checked;
            }

            enabledCheckBox.Enabled = true;
            saveButton.Enabled = true;

            IsChange = true;
        }

        private void fileDialogButton_Click(object sender, EventArgs e)
        {
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                filepathTextBox.Text = openFileDialog.FileName;
            }
        }

        private void appendToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Log.Logger.Debug("設定項目追加");

            if (IsChange)
            {
                if (MessageBox.Show("変更内容を破棄して新規追加しますか？", "警告", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning) != DialogResult.OK)
                {
                    return;
                }
            }

            ConfigItem cron = new ConfigItem();
            configItems.Add(cron);
            configListView.Items.Add(new ListViewItem(new string[] {
                cron.Name,
                cron.GetTiming(),
                cron.GetCommand(),
                cron.Enable.ToString()
            }));
            IsChange = false;

            SelectIndex = configListView.Items.Count - 1;
            configListView.Items[SelectIndex].Selected = true;
            configGroupBox.Enabled = true;
        }

        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Log.Logger.Debug("設定項目削除");
            if (IsChange)
            {
                if (MessageBox.Show("変更内容を破棄して削除しますか？", "警告", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning) != DialogResult.OK)
                {
                    return;
                }
            }

            configListView.Items[SelectIndex].Remove();
            configItems.RemoveAt(SelectIndex);
            IsChange = false;

            SelectIndex = Math.Min(SelectIndex, configListView.Items.Count - 1);
            if (configListView.Items.Count > 0)
            {
                configListView.Items[SelectIndex].Selected = true;
            }
            else
            {
                configGroupBox.Enabled = false;
            }

            ConfigItem.Save(configItems);
        }

        private void saveButton_Click(object sender, EventArgs e)
        {
            Log.Logger.Debug("設定ファイル書き込み");

            configItems[SelectIndex].SetConfig(nameTextBox.Text, explainTextBox.Text, timingTextBox.Text, filepathTextBox.Text, paramTextBox.Text, enabledCheckBox.Checked);
            configListView.Items[SelectIndex].SubItems[0].Text = nameTextBox.Text;
            configListView.Items[SelectIndex].SubItems[1].Text = timingTextBox.Text;
            configListView.Items[SelectIndex].SubItems[2].Text = filepathTextBox.Text;
            configListView.Items[SelectIndex].SubItems[3].Text = enabledCheckBox.Checked.ToString();
            IsChange = false;

            ConfigItem.Save(configItems);
        }

        private void ConfigForm_Load(object sender, EventArgs e)
        {
            Log.Logger.Debug("設定画面読み込み");

            configItems = ConfigItem.Load();

            List<ListViewItem> configListItem = new List<ListViewItem>();

            if (configItems.Count > 0)
            {
                foreach (ConfigItem item in configItems)
                {
                    string[] data = new string[] {
                        item.Name,
                        item.GetTiming(),
                        item.GetCommand(),
                        item.Enable.ToString()
                    };

                    configListItem.Add(new ListViewItem(data));
                }

                configListView.Items.AddRange(configListItem.ToArray());
                SelectIndex = 0;
                configListView.Items[SelectIndex].Selected = true;
            }
        }

        private void configListView_SelectedIndexChanged(object sender, EventArgs e)
        {

            Log.Logger.Debug("設定項目変更");
            if (configListView.SelectedItems.Count > 0)
            {
                if (IsChange)
                {
                    if (SelectIndex != configListView.SelectedItems[0].Index)
                    {
                        if (MessageBox.Show("変更内容を破棄して表示しますか？", "警告", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning) != DialogResult.OK)
                        {
                            if (SelectIndex >= 0)
                            {
                                configListView.SelectedIndexChanged -= new System.EventHandler(this.configListView_SelectedIndexChanged);
                                configListView.Items[SelectIndex].Selected = true;
                                configListView.SelectedIndexChanged += new System.EventHandler(this.configListView_SelectedIndexChanged);
                            }
                            return;
                        }
                    }
                }

                Log.Logger.Debug("設定再展開");
                SelectIndex = configListView.SelectedItems[0].Index;
                ConfigItem cron = configItems[SelectIndex];


                enabledCheckBox.Checked = cron.Enable;
                nameTextBox.Text = cron.Name;
                explainTextBox.Text = cron.Explain;
                timingTextBox.Text = cron.GetTiming();
                filepathTextBox.Text = cron.Path;
                paramTextBox.Text = cron.Param;

                IsChange = false;
            }
        }

        private void testButton_Click(object sender, EventArgs e)
        {
            Log.Logger.Info("テスト実行開始");
            PowerShellExec.Exec(filepathTextBox.Text, paramTextBox.Text);

            _ = MessageBox.Show("実行が完了しました", "結果", MessageBoxButtons.OK, MessageBoxIcon.Information);
            Log.Logger.Info("テスト実行終了");
        }

        private void contextMenuStrip_Opening(object sender, CancelEventArgs e)
        {
            Point pnt = configListView.PointToClient(Cursor.Position);
            ListViewItem item = configListView.HitTest(pnt).Item;
            if (item == null)
            {
                appendToolStripMenuItem.Visible = true;
                deleteToolStripMenuItem.Visible = false;
            }
            else if (item.Bounds.Contains(pnt))
            {
                appendToolStripMenuItem.Visible = false;
                deleteToolStripMenuItem.Visible = true;
            }
            else
            {
                e.Cancel = true;
            }
        }

        private void configTextBox_TextChanged(object sender, EventArgs e)
        {
            Log.Logger.Debug("設定変更（未保存）");
            IsChange = true;
        }

        private void ConfigForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            Log.Logger.Debug("設定画面終了");
            if (e.CloseReason == CloseReason.ApplicationExitCall)
            {
            }
            else
            {
                if (IsChange)
                {
                    if (MessageBox.Show("変更内容を破棄して終了しますか？", "警告", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning) != DialogResult.OK)
                    {
                        e.Cancel = true;
                        Log.Logger.Debug("設定画面終了キャンセル");
                    }
                }
            }

        }
    }

}
