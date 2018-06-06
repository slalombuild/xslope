using System;
using XSlope.Core.Container;
using XSlope.Core.Providers.Interfaces;

namespace XSlope.Core.Helpers
{
    public static class Logger
    {
        static ILogProvider _logProvider;
        static ILogProvider LogProvider
        {
            get
            {
                if (_logProvider == null)
                {
                    _logProvider = DependencyContainer.Get<ILogProvider>();
                }

                return _logProvider;
            }
        }

        public static void Trace(string msg)
        {
            LogProvider.Trace(msg);
        }

        public static void Trace(string format, params object[] args)
        {
            LogProvider.Trace(string.Format(format, args));
        }

        public static void Trace(Exception ex, string msg = "")
        {
            LogProvider.Trace(ex, msg);
        }

        public static void Debug(string msg)
        {
            LogProvider.Debug(msg);
        }

        public static void Debug(string format, params object[] args)
        {
            LogProvider.Debug(string.Format(format, args));
        }

        public static void Debug(Exception ex, string msg = "")
        {
            LogProvider.Debug(ex, msg);
        }

        public static void Info(string msg)
        {
            LogProvider.Info(msg);
        }

        public static void Info(string format, params object[] args)
        {
            LogProvider.Info(string.Format(format, args));
        }

        public static void Info(Exception ex, string msg = "")
        {
            LogProvider.Info(ex, msg);
        }

        public static void Warn(string msg)
        {
            LogProvider.Warn(msg);
        }

        public static void Warn(string format, params object[] args)
        {
            LogProvider.Warn(string.Format(format, args));
        }

        public static void Warn(Exception ex, string msg = "")
        {
            LogProvider.Warn(ex, msg);
        }

        public static void Error(string msg)
        {
            LogProvider.Error(msg);
        }

        public static void Error(string format, params object[] args)
        {
            LogProvider.Error(string.Format(format, args));
        }

        public static void Error(Exception ex, string msg = "")
        {
            LogProvider.Error(ex, msg);
        }
    }
}
