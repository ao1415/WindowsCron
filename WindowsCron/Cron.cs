using System;
using System.Collections.Generic;
using System.IO;
using System.Threading;
using System.Threading.Tasks;

namespace WindowsCron
{
    class Cron
    {

        private readonly Task<bool> cronTask;

        private readonly CancellationTokenSource tokenSource;
        private CancellationToken cancelToken;

        private FileSystemWatcher fileWatcher;

        private List<ConfigItem> configItems;

        public Cron()
        {
            Log.Logger.Debug("監視スレッド起動準備");

            configItems = ConfigItem.Load();

            fileWatcher = new FileSystemWatcher();
            fileWatcher.NotifyFilter = NotifyFilters.LastWrite;
            fileWatcher.Path = Path.GetDirectoryName(Path.GetFullPath(Properties.Resources.CronFile));
            fileWatcher.Filter = Path.GetFileName(Properties.Resources.CronFile);
            fileWatcher.Changed += new FileSystemEventHandler(fileWatcher_Changed);
            fileWatcher.EnableRaisingEvents = true;

            tokenSource = new CancellationTokenSource();
            cancelToken = tokenSource.Token;

            cronTask = new Task<bool>(cronThread);

            cronTask.Start();

            Log.Logger.Debug("監視スレッド起動開始");
        }

        public void Close()
        {
            Log.Logger.Debug("監視スレッド終了開始");

            tokenSource.Cancel();
            _ = cronTask.Result;

            Log.Logger.Debug("監視スレッド終了完了");

        }

        private void fileWatcher_Changed(object sender, FileSystemEventArgs e)
        {
            Log.Logger.Info("設定ファイル更新検知");

            lock (configItems)
            {
                configItems = ConfigItem.Load();
            }
            Log.Logger.Info("設定ファイル反映完了");
        }

        private bool cronThread()
        {
            DateTime time = DateTime.Now;
            Log.Logger.Info("監視スレッド起動");

            while (!cancelToken.IsCancellationRequested)
            {
                DateTime now = DateTime.Now;

                if (time.Minute != now.Minute)
                {
                    time = now;

                    List<(string, string)> execList = new List<(string, string)>();

                    lock (configItems)
                    {
                        foreach (ConfigItem item in configItems)
                        {
                            if (item.Enable && CronPattern.IsMatch(item, time))
                            {
                                execList.Add((item.Path, item.Param));
                            }
                        }
                    }

                    foreach ((string, string) exec in execList)
                    {
                        PowerShellExec.Exec(exec.Item1, exec.Item2);
                    }
                }

                Thread.Yield();
                Thread.Sleep(100);
            }

            Log.Logger.Info("監視スレッド終了");
            return true;
        }

    }

    static class CronPattern
    {
        public static bool IsMatch(ConfigItem item, DateTime now)
        {
            try
            {
                if (!GetTarget(item.Minutes, 0, 59).Contains(now.Minute))
                    return false;

                if (!GetTarget(item.Hour, 0, 23).Contains(now.Hour))
                    return false;

                if (!GetTarget(item.Day, 1, 31).Contains(now.Day))
                    return false;

                if (!GetTarget(item.Month, 1, 12).Contains(now.Month))
                    return false;

                HashSet<int> week = GetTarget(item.Week, 0, 7);
                if (week.Contains(7)) week.Add(0);

                if (!week.Contains((int)now.DayOfWeek))
                    return false;
            }
            catch (FormatException e)
            {
                Log.Logger.Error("フォーマットエラー");
                Log.Logger.Error(e.Message);
                return false;
            }

            return true;
        }

        private static HashSet<int> GetTarget(string command, int min, int max)
        {
            // 8-20/3 -> 8,11,14,17,20
            // 1,8-20/3 -> 1,8,11,14,17,20
            // */3 -> 0-59/3 -> 1,8,11,14,17,20

            HashSet<int> target = new HashSet<int>();

            //ワイルドカードを[0-59]に変換
            command = command.Replace("*", $"{min}-{max}");

            string[] ranges = command.Split(',');

            foreach (string range in ranges)
            {
                string[] item = range.Split('/');
                string[] section = item[0].Split('-');

                if (section.Length == 1)
                {
                    //Log.Logger.Debug($"Parse:{section[0]}");
                    target.Add(int.Parse(section[0]));
                }
                else
                {
                    int d = 1;
                    if (item.Length == 2)
                    {
                        //Log.Logger.Debug($"Parse:{item[1]}");
                        d = int.Parse(item[1]);
                    }

                    //Log.Logger.Debug($"Parse:{section[0]}:{section[1]}");
                    int begin = int.Parse(section[0]);
                    int end = int.Parse(section[1]);

                    for (int t = begin; t <= end; t += d)
                    {
                        target.Add(t);
                    }
                }
            }

            //Log.Logger.Debug(string.Join(",", target));

            return target;
        }

    }

}
