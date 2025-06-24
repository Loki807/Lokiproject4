using Lokiproject4.Controllers;
using Lokiproject4.DataConnect;
using Lokiproject4.Views;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lokiproject4
{
    internal static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Migration.CreateTableAsync().GetAwaiter().GetResult();
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            SetBrowserEmulationMode();
            Application.Run(new LoginForm());

            
        }
        public static void SetBrowserEmulationMode()
        {
            var appName = System.IO.Path.GetFileName(System.Diagnostics.Process.GetCurrentProcess().MainModule.FileName);

            using (var key = Registry.CurrentUser.CreateSubKey(
                @"Software\Microsoft\Internet Explorer\Main\FeatureControl\FEATURE_BROWSER_EMULATION"))
            {
                key.SetValue(appName, 11001, RegistryValueKind.DWord); // 11001 = IE11 mode
            }
        }
    }
}
