using System;
using System.IO;
using System.Linq;
using System.Management.Automation;
using System.Management.Automation.Runspaces;
using System.Windows.Forms;

namespace WindowsCron
{
    public static class PowerShellExec
    {
        public static bool Exec(string path, string param = "")
        {
            try
            {
                string workspace = Path.GetDirectoryName(Path.GetFullPath(path));
                string file = Path.GetFileName(path);

                using (Runspace rs = RunspaceFactory.CreateRunspace())
                {
                    rs.Open();

                    using (PowerShell ps = PowerShell.Create())
                    {
                        PSCommand pscmd = new PSCommand();
                        pscmd.AddScript($"cd {workspace}");
                        pscmd.AddScript($".\\{file} {param}");

                        ps.Commands = pscmd;
                        ps.Runspace = rs;

                        Log.Logger.Debug($"コマンド：{pscmd.Commands}");

                        try
                        {
                            var results = ps.Invoke();

                            if (results.Count() > 0)
                            {
                                Log.Logger.Info("実行スクリプト：" + file);
                                foreach (var res in results)
                                {
                                    Log.Logger.Info("実行結果：" + res);
                                }
                            }
                        }
                        catch (PSSecurityException)
                        {
                            Log.Logger.Error("スクリプト実行を許可してください");
                            Log.Logger.Error("Set-ExecutionPolicy RemoteSigned -Scope CurrentUser");
                            return false;
                        }
                    }
                }
            }
            catch (Exception e)
            {
                Log.Logger.Error("PowerShellの実行に失敗しました", e);
                return false;
            }

            return true;
        }
    }
}
