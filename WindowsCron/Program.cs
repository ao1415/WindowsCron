using System;
using System.Windows.Forms;

namespace WindowsCron
{
    static class Program
    {
        /// <summary>
        /// アプリケーションのメイン エントリ ポイントです。
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Form taskIcon = new TaskIcon();
            Application.Run();
        }
    }
}
