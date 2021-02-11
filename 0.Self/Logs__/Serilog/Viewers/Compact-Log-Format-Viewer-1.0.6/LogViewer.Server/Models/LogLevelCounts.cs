﻿namespace LogViewer.Server.Models
{
    public class LogLevelCounts
    {
        public int Verbose { get; set; }

        public int Information { get; set; }

        public int Debug { get; set; }

        public int Warning { get; set; }

        public int Error { get; set; }

        public int Fatal { get; set; }
    }
}
