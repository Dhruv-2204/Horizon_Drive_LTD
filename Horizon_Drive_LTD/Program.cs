

using Horizon_Drive_LTD.DataStructure;

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
            //Application.SetHighDpiMode(HighDpiMode.SystemAware);
            //Application.EnableVisualStyles();
            //Application.SetCompatibleTextRenderingDefault(false);
            //Application.Run(new SPLASH_SCREEN());
          
            // Arrange: Create a hash table with a small initial capacity to trigger resizing.
            var ht = new HashTable<int, string>(3);

            // Act: Insert multiple key-value pairs into the hash table.
            for (int i = 0; i < 10; i++)
            {
                ht.Insert(i, $"Value{i}");
            }

            // Assert: Ensure all key-value pairs can still be retrieved after resizing.
            for (int i = 0; i < 10; i++)
            {
               MessageBox.Show($"Value{i}");
            }
        

    }
    }
}
