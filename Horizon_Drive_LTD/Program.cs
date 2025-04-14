

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
            Application.Run(new SPLASH_SCREEN());

        }
    }
}
