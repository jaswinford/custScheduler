using System.Data;
using Swinford.Logging;
using MySql.Data.MySqlClient;

namespace custScheduler
{
    public partial class Report : Form
    {
        private int report = 0; //Default to appointment type by Month
        private string[] reportQueries = new string[3]
        {
            // Appointment types by month
            "SELECT" + Environment.NewLine +
            "   DATE_FORMAT(start,'%Y-%m') AS month," + Environment.NewLine +
            "   type," + Environment.NewLine +
            "   COUNT(*) AS type_count" + Environment.NewLine +
            "FROM" + Environment.NewLine +
            "   appointment" + Environment.NewLine +
            "GROUP BY" + Environment.NewLine +
            "   month," + Environment.NewLine +
            "   type" + Environment.NewLine +
            "ORDER BY" + Environment.NewLine +
            "   month ASC, type ASC;",

            // User Schedules
            "SELECT" + Environment.NewLine +
            "   u.userName," + Environment.NewLine +
            "   a.type," + Environment.NewLine +
            "   a.start," + Environment.NewLine +
            "   a.title" + Environment.NewLine +
            "FROM" + Environment.NewLine +
            "   appointment AS a" + Environment.NewLine +
            "JOIN" + Environment.NewLine +
            "   user AS u ON a.userId = u.userId" + Environment.NewLine +
            "WHERE" + Environment.NewLine +
            "   a.start > NOW()" + Environment.NewLine +
            "ORDER BY" + Environment.NewLine +
            "   u.userName ASC, a.start ASC;",

            // Customer appointment counts by month
            "SELECT" + Environment.NewLine +
            "   DATE_FORMAT(start,'%Y-%m') AS month," + Environment.NewLine +
            "   c.customerName," + Environment.NewLine +
            "   COUNT(*) AS appointments" + Environment.NewLine +
            "FROM" + Environment.NewLine +
            "   appointment AS a" + Environment.NewLine +
            "JOIN" + Environment.NewLine +
            "   customer AS c ON a.customerId = c.customerId" +  Environment.NewLine +
            "GROUP BY" + Environment.NewLine +
            "   month," + Environment.NewLine +
            "   c.customerName" + Environment.NewLine +
            "ORDER BY" + Environment.NewLine +
            "   month ASC, c.customerName ASC;"
        };

        public Report(int report)
        {
            InitializeComponent();
            this.report = report;
        }

        private void Report_Load(object sender, EventArgs e)
        {
            Log.Debug("Loading report " + report.ToString(),"reports");
            string connectionString = Settings.Default.ConnectionString;
            try
            {
                using (MySqlConnection connection = new MySqlConnection(connectionString))
                {
                    connection.Open();

                    using (MySqlCommand command = new MySqlCommand(reportQueries[report], connection))
                    {
                        using (MySqlDataAdapter adapter = new MySqlDataAdapter(command))
                        {
                            DataTable dataTable = new DataTable();
                            adapter.Fill(dataTable);
                            dataGridView1.DataSource = dataTable;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                string message = "Failed to load report :" + ex.Message;
                Log.Error(message, "reports");
                MessageBox.Show(message);
            }
        }
    }
}
