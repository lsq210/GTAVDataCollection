using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;

namespace GTAVLogger
{

    public enum LoggerLevel
    {
        INFO = 0,
        WARNING = 1,
        ERROR = 2
    }

    public class LogItem
    {
        public LogItem(LoggerLevel level, string msg)
        {
            Level = level;
            Msg = msg;
        }

        public readonly LoggerLevel Level;
        public readonly string Msg;
    }

    public class Logger
    {
        public static Logger shared = new Logger();

        public static void Log(string msg)
        {
            Logger.shared.AddLoggerItem(LoggerLevel.INFO, msg);
        }
        public static void Warning(string msg)
        {
            Logger.shared.AddLoggerItem(LoggerLevel.WARNING, msg);
        }

        public static void Error(string msg)
        {
            Logger.shared.AddLoggerItem(LoggerLevel.ERROR, msg);
        }

        public static void Trigger()
        {
            Logger.shared._Trigger();
        }

        public static void Print()
        {
            Logger.shared._Print();
        }

        private readonly List<LogItem> Lines = new List<LogItem>();
        private bool Show = false;

        private readonly Point LoggerWindowStart = new Point(0, 0);
        private readonly Size LoggerWindowSize = new Size(500, 200);
        private readonly int MAX_LOG_LINE = 6;
        private readonly int LOG_LINE_HEIGHT = 30;
        private readonly int LOG_LINE_TOP = 10;
        private readonly int LOG_LINE_LEFT = 10;
        private readonly float LOG_TEXT_SCALE = .5f;
        private readonly float LOG_TITLE_SCALE = .2f;
        private readonly string FILE_NAME = "GTAVDataCollection";

        private static string FormatMsg(LoggerLevel level, string msg)
        {
            var time = $"{DateTime.Now.Hour}:{DateTime.Now.Minute}:{DateTime.Now.Second}";
            return $"[{GetTextPrefix(level)}] {time} {msg}";
        }

        private void WriteToFile(string msg)
        {
            File.AppendAllText($"./scripts/{FILE_NAME}.log", DateTime.Now + " " + msg + Environment.NewLine);
        }

        private void AddLoggerItem(LoggerLevel level, string msg)
        {
            string formatedMsg = FormatMsg(level, msg);
            Lines.Add(new LogItem(level, formatedMsg));
            if (Lines.Count > MAX_LOG_LINE)
            {
                Lines.RemoveAt(0);
            }
            WriteToFile(formatedMsg);
        }

        private static Color GetTextColor(LoggerLevel level)
        {
            switch(level)
            {
                case LoggerLevel.INFO:
                    {
                        return Color.White;
                    }
                case LoggerLevel.WARNING:
                    {
                        return Color.Yellow;
                    }
                case LoggerLevel.ERROR:
                    {
                        return Color.Red;
                    }
            }
            return  Color.White;
        }

        private static string GetTextPrefix(LoggerLevel level)
        {
            switch (level)
            {
                case LoggerLevel.INFO:
                    {
                        return "INFO";
                    }
                case LoggerLevel.WARNING:
                    {
                        return "WARNING";
                    }
                case LoggerLevel.ERROR:
                    {
                        return "ERROR";
                    }
            }
            return "INFO";
        }

        private void _Trigger()
        {
            this.Show = !this.Show;
        }

        private void _Print()
        {
            if (!this.Show) return;

            var console = new GTA.UI.ContainerElement(LoggerWindowStart, LoggerWindowSize, Color.Black);
            console.Items.Add(new GTA.UI.TextElement("GTAVDataCollection", new PointF(LOG_LINE_LEFT, 0), LOG_TITLE_SCALE, Color.White));
            for (int i = 0; i < Lines.Count; i++)
            {
                var line = Lines[i];
                console.Items.Add(new GTA.UI.TextElement(line.Msg, new PointF(LOG_LINE_LEFT, LOG_LINE_TOP + i * LOG_LINE_HEIGHT), LOG_TEXT_SCALE, GetTextColor(line.Level)));
            }
            console.Draw();
        }

    }
}
