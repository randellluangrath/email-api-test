﻿using System;
using log4net;

namespace email_api_test.Logging
{
    public class Logger
    {
        private static ILog Log { get; }

        static Logger()
        {
            Log = LogManager.GetLogger(typeof(Logger));
        }

        public static void Error(object msg)
        {
            Log.Error(msg);
        }

        public static void Warning(object msg)
        {
            Log.Warn(msg);
        }

        public static void Error(object msg, Exception ex)
        {
            Log.Error(msg, ex);
        }

        public static void Error(Exception ex)
        {
            Log.Error(ex.Message, ex);
        }

        public static void Info(object msg)
        {
            Log.Info(msg);
        }
    }
}
}