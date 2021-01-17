using System;
using System.IO;
using System.Windows.Forms;

namespace WindowsCron
{
    public partial class TaskIcon : Form
    {
        private readonly Cron cron = new Cron();
        private ConfigForm configForm = null;

        public TaskIcon()
        {
            InitializeComponent();
            Log.Logger.Info("アプリ開始");
        }

        private void ConfigToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (configForm == null)
            {
                configForm = new ConfigForm();
                configForm.ShowDialog();
                configForm = null;
            }
            else
            {
                configForm.Activate();
            }
        }

        private void EndToolStripMenuItem_Click(object sender, EventArgs e)
        {
            cron.Close();

            Log.Logger.Info("アプリ終了");
            Application.Exit();
        }

        private void LogToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Loggerの生成
            var logger = Log.Logger;

            // RootのLoggerを取得
            var rootLogger = ((log4net.Repository.Hierarchy.Hierarchy)logger.Logger.Repository).Root;

            // RootのAppenderを取得
            var appender = rootLogger.GetAppender("MainLogAppender") as log4net.Appender.FileAppender;

            // ファイル名の取得
            var filepath = appender.File;

            System.Diagnostics.Process.Start(Path.GetDirectoryName(filepath));
        }
    }
}
