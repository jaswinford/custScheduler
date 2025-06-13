using Microsoft.Data.SqlClient;
using System.Globalization;
using System.Resources;

namespace custScheduler
{
    public partial class LoginForm : Form
    {
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
            try
            {
                User user = new User(txtUsername.Text);
                //TODO: Add Authentication Check
                if (user.userId == -1)
                {
                    MessageBox.Show(_rm.GetString("Message.InvalidCredentials"));
                    return;
                }
            }
            catch (SqlException ex) 
            {
                MessageBox.Show(_rm.GetString("Message.SQLError") + " : " + ex.Message);
            }

        }
    }
}
