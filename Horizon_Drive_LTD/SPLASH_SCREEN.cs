using Horizon_Drive_LTD;
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

                // Debugging - Print the path to verify correctness
                Console.WriteLine($"Sound Path: {soundPath}");

                // Check if the sound file exists before playing
                if (!File.Exists(soundPath))
                {
                    MessageBox.Show($"Error: Sound file not found!\nPath: {soundPath}", "File Not Found",
                                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // Create SoundPlayer instance and play the sound
                using (SoundPlayer player = new SoundPlayer(soundPath))
                {
                    player.Play(); // Play once 
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error playing sound: {ex.Message}", "Playback Error",
                                MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void label1_Click_1(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            panel2.Width += 3;
            if (panel2.Width >= 688)
            {
                timer1.Stop();
                OpensignUp();//Calls the procedure to open the sign up page

            }
        }

        private void OpensignUp()
        {
            Signup signup = new Signup();
            signup.Show();
            //Login login = new Login();
            //login.Show();
            this.Hide(); // Hide splash screen instead of closing
        }

        private void pictureBox1_Click_1(object sender, EventArgs e)
        {

        }
    }
}
