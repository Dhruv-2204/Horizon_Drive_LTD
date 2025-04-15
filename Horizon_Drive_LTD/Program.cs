using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using Horizon_Drive_LTD;
using Horizon_Drive_LTD.BusinessLogic;
using Horizon_Drive_LTD.BusinessLogic.Repositories;
using Horizon_Drive_LTD.BusinessLogic.Services;
using Horizon_Drive_LTD.DataStructure;
using Horizon_Drive_LTD.Domain.Entities;


namespace splashscreen
{
    public static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>//
        [STAThread]
        static void Main()
        {

            // Enable high-DPI awareness
            Application.SetHighDpiMode(HighDpiMode.SystemAware);
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            //Application.Run(new SPLASH_SCREEN());
            //Application.Run(new Options_Personal());
            //Application.Run(new ListCarForm());
            Application.Run(new BrowseListings());

        }
    }
}
