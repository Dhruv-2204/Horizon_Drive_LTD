using Horizon_Drive_LTD;
using Horizon_Drive_LTD.BusinessLogic.Repositories;
using Horizon_Drive_LTD.BusinessLogic;
using Horizon_Drive_LTD.BusinessLogic.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Media; 
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace splashscreen
{
    public partial class SPLASH_SCREEN : Form
    {
       
        public  SPLASH_SCREEN()
        {
            InitializeComponent();
            PlaySound();

        }
        private void PlaySound()
        {
            try
            {
                // Locating the Horizon_Drive_LTD directory dynamically
                DirectoryInfo currentDir = new DirectoryInfo(AppDomain.CurrentDomain.BaseDirectory);

                while (currentDir != null && currentDir.Name != "Horizon_Drive_LTD")
                {
                    currentDir = currentDir.Parent;
                }

                if (currentDir == null)
                {
                    MessageBox.Show("Error: Could not locate Horizon_Drive_LTD directory.", "Directory Error",
                                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // Construct the path to the sound file directly inside Horizon_Drive_LTD
                string soundPath = Path.Combine(currentDir.FullName, "Sound\\fast-car-sound.wav");

                // Checking if the sound file exists before playing
                if (!File.Exists(soundPath))
                {
                    MessageBox.Show($"Error: Sound file not found!\nPath: {soundPath}", "File Not Found",
                                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // Creating SoundPlayer instance and play the sound
                using (SoundPlayer player = new SoundPlayer(soundPath))
                {
                    player.Play(); // Play sound once 
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error playing sound: {ex.Message}", "Playback Error",
                                MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
               
        private void timer1_Tick(object sender, EventArgs e)
        {
            panel2.Width += 3;
            if (panel2.Width >= 688)
            {
                timer1.Stop();
                OpenLoginUp();  //Calls the procedure to open the login up page

            }
        }

        private void OpenLoginUp()
        {

            var userRepo = new UserRepository(new DatabaseConnection());
            var userHashTable = userRepo.LoadUsersIntoHashTable();
            var authService = new AuthenticationService(userHashTable);

            // Create and show the Login form, passing the authService instance
            Login loginForm = new Login(authService);
            loginForm.Show();

          
            this.Hide();
        }

        private void pictureBox1_Click_1(object sender, EventArgs e)
        {

        }
    }
}
