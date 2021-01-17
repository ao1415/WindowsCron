namespace WindowsCron
{
    static class Log
    {
        public static log4net.ILog Logger { get; private set; } = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
    }
}
