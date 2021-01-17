using System;
using System.Collections.Generic;
using System.Xml.Linq;

namespace WindowsCron
{
    class ConfigItem
    {
        public string Name { get; private set; }
        public string Explain { get; private set; }
        public string Minutes { get; private set; }
        public string Hour { get; private set; }
        public string Day { get; private set; }
        public string Month { get; private set; }
        public string Week { get; private set; }
        public string Path { get; private set; }
        public string Param { get; private set; }
        public bool Enable { get; private set; }

        public void SetConfig(string name, string explain, string timing, string path, string param, bool enable)
        {
            Name = name;
            Explain = explain;

            string[] timings = timing.Split(' ');
            Minutes = timings[0];
            Hour = timings[1];
            Day = timings[2];
            Month = timings[3];
            Week = timings[4];

            Path = path;
            Param = param;
            Enable = enable;
        }

        public string GetTiming()
        {
            return $"{Minutes} {Hour} {Day} {Month} {Week}";
        }

        public string GetCommand()
        {
            return $"{Path} {Param}";
        }

        public static List<ConfigItem> Load()
        {
            Log.Logger.Debug("crontab.xmlの読み込み");

            XDocument xml = XDocument.Load(Properties.Resources.CronFile);
            List<ConfigItem> configItems = new List<ConfigItem>();

            IEnumerable<XElement> crons = xml.Descendants("cron");

            foreach (XElement cron in crons)
            {
                XElement timing = cron.Element("timing");

                ConfigItem configItem = new ConfigItem();
                configItem.Name = cron.Attribute("name")?.Value ?? "";
                configItem.Explain = cron.Element("explain")?.Attribute("value")?.Value ?? "";
                configItem.Minutes = timing?.Element("minutes")?.Attribute("value")?.Value ?? "";
                configItem.Hour = timing?.Element("hour")?.Attribute("value")?.Value ?? "";
                configItem.Day = timing?.Element("day")?.Attribute("value")?.Value ?? "";
                configItem.Month = timing?.Element("month")?.Attribute("value")?.Value ?? "";
                configItem.Week = timing?.Element("week")?.Attribute("value")?.Value ?? "";
                configItem.Path = cron.Element("command")?.Attribute("value")?.Value ?? "";
                configItem.Param = cron.Element("command")?.Attribute("param")?.Value ?? "";
                configItem.Enable = (0 == string.Compare(bool.TrueString, (cron.Element("enable")?.Attribute("value")?.Value ?? bool.FalseString), true));

                configItems.Add(configItem);

            }

            return configItems;
        }

        public static void Save(List<ConfigItem> configItems)
        {
            Log.Logger.Debug("crontab.xmlの書き込み");

            Action<XElement, ConfigItem> setCronElement = (XElement rootElement, ConfigItem item) =>
             {
                 rootElement.Add(new XElement("explain", new XAttribute("value", item.Explain)));
                 rootElement.Add(new XElement("timing",
                     new XElement("minutes", new XAttribute("value", item.Minutes)),
                     new XElement("hour", new XAttribute("value", item.Hour)),
                     new XElement("day", new XAttribute("value", item.Day)),
                     new XElement("month", new XAttribute("value", item.Month)),
                     new XElement("week", new XAttribute("value", item.Week))
                     ));
                 rootElement.Add(new XElement("command", new XAttribute("value", item.Path), new XAttribute("param", item.Param)));
                 rootElement.Add(new XElement("enable", new XAttribute("value", item.Enable)));

             };

            XDeclaration declaration = new XDeclaration("1.0", "utf-8", "true");
            XElement element = new XElement("setting");

            element.Add(new XElement("sample", new XAttribute("name", "サンプル")));
            {
                XElement sample = element.Element("sample");
                setCronElement(sample, new ConfigItem
                {
                    Explain = "書式サンプル",
                    Minutes = "*",
                    Hour = "*",
                    Day = "*",
                    Month = "*",
                    Week = "*",
                    Path = "コマンド",
                    Param = "パラメータ",
                    Enable = false,
                });
            }
            foreach (ConfigItem item in configItems)
            {
                XElement cron = new XElement("cron", new XAttribute("name", item.Name));
                setCronElement(cron, item);
                element.Add(cron);
            }

            XDocument xml = new XDocument(declaration, element);
            xml.Save(Properties.Resources.CronFile);
        }

    }
}
