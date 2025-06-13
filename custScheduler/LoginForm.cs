using System.Resources;
using Swinford.Logging;

namespace custScheduler
{
    public partial class LoginForm : Form
    {
        public event EventHandler LoginSuccess;
        private ResourceManager _rm = new ResourceManager(typeof(LoginForm));
        public LoginForm()
        {
            InitializeComponent();
        }

        private void LoginForm_Load(object sender, EventArgs e)
        {
            // Populate UI with Internationalized strings.
            lblPassword.Text = _rm.GetString("Password");
            lblUsername.Text = _rm.GetString("Username");
            btnCancel.Text = _rm.GetString("Cancel");
            btnLogin.Text = _rm.GetString("Login");
            this.Text = _rm.GetString("Login");

            // Clear status update.
            lblStatus.Text = string.Empty;
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            Log.Info("Attempting sign-in as " + txtUsername.Text);
            try
            {
                User user = new User(txtUsername.Text);
                if (user.userId == -1 || !user.Authenticated(txtPassword.Text))
                {
                    Log.Error("Failed signing attempt, Invalid Credentials");
                    MessageBox.Show(_rm.GetString("Message.InvalidCredentials"));
                    return;
                }
                Log.Info("Successful Signin");
                Log.ToFile(LogLevel.Info, txtUsername.Text, "Login_History.txt");
                Session.CurrentUser = user;
                LoginSuccess?.Invoke(this, EventArgs.Empty);
            }
            catch (Exception ex) 
            {
                MessageBox.Show(_rm.GetString("Message.SQLError") + " : " + ex.Message);
            }

        }
    }
}
