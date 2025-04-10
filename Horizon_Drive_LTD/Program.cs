using System;
using System.Windows.Forms;

namespace Horizon_Drive_LTD
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            // Enable high-DPI awareness
            Application.SetHighDpiMode(HighDpiMode.SystemAware);
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            
             Application.Run(new Options_Personal());

            
        }
    }
}