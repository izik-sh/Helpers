using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HelperClasses
{
    public class FramwrorkHelper
    {
        public static string GetFramwrork()
        {
            string results = string.Empty;

            // Check .NET Framework
            using (var key = Registry.LocalMachine.OpenSubKey(@"SOFTWARE\Microsoft\NET Framework Setup\NDP\v4\Full"))
            {
                results = "✅ .NET Framework: " + (key?.GetValue("Version") ?? "Not Installed");
            }

            // Check .NET Core / .NET 5+
            try
            {
                var process = Process.Start(new ProcessStartInfo("dotnet", "--list-runtimes")
                {
                    RedirectStandardOutput = true,
                    UseShellExecute = false,
                    CreateNoWindow = true
                });
                results += Environment.NewLine + "✅ .NET Core / .NET 5+: " + process?.StandardOutput.ReadToEnd().Trim();
            }
            catch
            {
                results = "❌ .NET Core / .NET 5+ not installed.";
            }
            return results;
        }
    }
}
