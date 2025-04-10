namespace Horizon_Drive_LTD
{
    using Horizon_Drive_LTD.BusinessLogic.Services;
    //Using the splashcreen namespace to summon the Login window
    using splashscreen;
    public partial class Signup : Form
    {
        private bool isClosing = false;
        private AuthenticationService _authService;
        public Signup(AuthenticationService authService)
        {
            InitializeComponent();
            _authService = authService;
        }

        public Signup()
        {
            InitializeComponent();
        }

        private void Closing_form(object sender, FormClosingEventArgs e)
        {
            if (isClosing) return; // Prevent duplicate message box
            isClosing = true;

            DialogResult result = MessageBox.Show("Do you want to close the Car Hire Application?", "Confirm Exit",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.No)
            {
                e.Cancel = true; // Prevent closing
                isClosing = false;
            }
            else
            {
                Application.Exit(); // Properly terminates the application without triggering FormClosing again
            }
        }

        private void Login_button(object sender, EventArgs e)
        {
            Login login = new Login(_authService); // Pass existing auth service to Login
            login.Show();
            this.Dispose();
        }



        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked == true)
            {
                Password.UseSystemPasswordChar = false;
            }
            else
            {
                Password.UseSystemPasswordChar = true;
            }
        }



        private void Signup_Load(object sender, EventArgs e)
        {
            this.FormClosing += new FormClosingEventHandler(Closing_form);
        }

        private void username(object sender, EventArgs e)
        {

        }

        private void email(object sender, EventArgs e)
        {

        }

        private void Phone_number(object sender, EventArgs e)
        {

        }

        private void address(object sender, EventArgs e)
        {

        }

        private void password(object sender, EventArgs e)
        {

        }

        private void panel4_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}

