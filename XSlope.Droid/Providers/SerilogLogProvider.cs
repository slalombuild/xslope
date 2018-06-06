using System;
using Serilog;
using Serilog.Core;
using XSlope.Core.Providers.Interfaces;

namespace XSlope.Droid.Providers
{
    public class SerilogLogProvider : ILogProvider
    {
        public SerilogLogProvider(IAppNameProvider appNameProvider)
        {
            Log.Logger = new LoggerConfiguration()
                .MinimumLevel.Verbose()
                .WriteTo.AndroidLog()
                .Enrich.WithProperty(Constants.SourceContextPropertyName, appNameProvider.AppName)
                .CreateLogger();
        }

        #region ILoggerProvider

        public void Trace(string msg)
        {
            Log.Verbose(msg);
        }

        public void Trace(Exception ex, string msg)
        {
            Log.Verbose(ex, msg);
        }

        public void Debug(string msg)
        {
            Log.Debug(msg);
        }

        public void Debug(Exception ex, string msg)
        {
            Log.Debug(ex, msg);
        }

        public void Info(string msg)
        {
            Log.Information(msg);
        }

        public void Info(Exception ex, string msg)
        {
            Log.Information(ex, msg);
        }

        public void Warn(string msg)
        {
            Log.Warning(msg);
        }

        public void Warn(Exception ex, string msg)
        {
            Log.Warning(ex, msg);
        }

        public void Error(string msg)
        {
            Log.Error(msg);
        }

        public void Error(Exception ex, string msg)
        {
            Log.Error(ex, msg);
        }

        #endregion
    }
}
