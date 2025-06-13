using Swinford.Logging;

namespace custScheduler
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            //Configure Logging
            Logger.Instance.Configure(new LoggerConfig
            {
                LogFilePath = "latest.log",
                MinimumLevel = LogLevel.Debug,
                LogToConsole = true
            });

            Log.Info("Launching program");
            ApplicationConfiguration.Initialize();
            Application.Run(new AppContext());
        }
    }

    // Defining a custom appcontext to allow passing login event from Loginform to Appointment form.
    // At the same time, we change the main thread to the Appointment form so we can close the login form.
    public class AppContext : ApplicationContext
    {
        public AppContext()
        {
            ShowLoginForm();
        }
        private void ShowLoginForm()
        {
            var loginForm = new LoginForm();
            loginForm.LoginSuccess += OnLoginSuccess;
            loginForm.FormClosed += (s, e) =>
            {
                if (_mainForm == null)
                    ExitThread();
            };
            loginForm.Show();
        }
        private void OnLoginSuccess(object sender, EventArgs e)
        {
            var loginForm = sender as LoginForm;
            loginForm.LoginSuccess -= OnLoginSuccess;

            _mainForm = new AppointmentForm();
            _mainForm.FormClosed += (s2, e2) => ExitThread();

            _mainForm.Show();
            loginForm.Close();
        }

        private AppointmentForm _mainForm;
    }
}