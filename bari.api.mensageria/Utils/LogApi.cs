using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Serilog;

namespace bari.api.mensageria.Utils
{
    public static class LogApi
    {
        
        public static void WriteLog(string message)
        {
            Log.Logger = new LoggerConfiguration()
                   .WriteTo.Console()
                   .WriteTo.File(@"C:\logs\log-.txt", rollingInterval: RollingInterval.Day)
                   .CreateLogger();
            //Log.Information("Usando Serilog...");
            Log.Information(message);

            Log.CloseAndFlush();

        }
    }
}
