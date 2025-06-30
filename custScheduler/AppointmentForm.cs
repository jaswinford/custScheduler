using MySql.Data.MySqlClient;
using System.Data;
using Swinford.Logging;

namespace custScheduler
{
    public partial class AppointmentForm : Form
    {
        //Query for populating the Datagrid
        private readonly string query = "SELECT appointmentId,title,location,contact,type,description FROM appointment";

        // Store the currently viewed/manipulated appointment locally
        private Appointment curAppointment = new Appointment();
        public AppointmentForm()
        {
            InitializeComponent();
        }

        // On load, Bind the DataGrid to the above query then alert on upcoming appointments
        private void Form1_Load(object sender, EventArgs e)
        {
            var timeZones = TimeZoneInfo.GetSystemTimeZones();

            cmbTimezone.DataSource = timeZones.ToList();
            cmbTimezone.DisplayMember = "DisplayName";
            cmbTimezone.ValueMember = "Id";
            cmbTimezone.SelectedValue = TimeZoneInfo.Local.Id;

            BindAppointments(appointmentGrid);
            AlertUpcomingAppointments();
            PopulateCustomers();
            RefreshValues();
        }


        // Get a list of apointments for the currently logged in user that start in the next 15 minutes and display a popup.
        private void AlertUpcomingAppointments()
        {
            Log.Info("Checking for urgent appointments");
            string connectionString = Settings.Default.ConnectionString;
            string query = "SELECT title,start,end FROM appointment WHERE userId = @id AND start BETWEEN @now AND @future";

            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                Log.Debug("Opening Connection");
                conn.Open();
                using (MySqlCommand cmd = new MySqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@id", Session.CurrentUser.userId);
                    cmd.Parameters.AddWithValue("@now", DateTime.Now.ToUniversalTime());
                    cmd.Parameters.AddWithValue("@future", DateTime.Now.ToUniversalTime().AddMinutes(15));
                    using (MySqlDataReader reader = cmd.ExecuteReader())
                    {
                        Log.Debug("Reading Data");
                        while (reader.Read())
                        {
                            MessageBox.Show((string)reader["title"] + "\n" + (DateTime)reader["start"] + " - " + (DateTime)reader["end"], "Upcoming Appointment");
                        }
                    }
                }
            }
        }

        // Form refresh function
        private void RefreshValues()
        {
            var selectedTimeZoneInfo = (TimeZoneInfo)cmbTimezone.SelectedItem;
            PopulateCustomers();
            customerComboBox.SelectedItem = curAppointment.Customer.customerName;
            IDBox.Text = curAppointment.appointmentId.ToString();
            titleTextBox.Text = curAppointment.Title;
            descriptionTextBox.Text = curAppointment.Description;
            try
            {
                startDTPick.Value = TimeZoneInfo.ConvertTimeFromUtc(curAppointment.Start, selectedTimeZoneInfo);
                endDTPick.Value = TimeZoneInfo.ConvertTimeFromUtc(curAppointment.End, selectedTimeZoneInfo);
            }
            catch (Exception ex) { Log.Error(ex.Message); }
            locationTextBox.Text = curAppointment.Location;
            contactTextBox.Text = curAppointment.Contact;
            txtURL.Text = curAppointment.Url;
            typeTextBox.Text = curAppointment.Type;
            lblDetails.Text = curAppointment.Details;
        }

        // Populate the Customers combobox with all current customers.
        private void PopulateCustomers()
        {
            Log.Debug("Populating list of customers");

            string connectionString = Settings.Default.ConnectionString;
            string query = "SELECT customerName from customer";

            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                connection.Open();
                using (MySqlCommand cmd = new MySqlCommand(query, connection))
                {
                    using (MySqlDataReader reader = cmd.ExecuteReader())
                    {
                        customerComboBox.Items.Clear();

                        while (reader.Read())
                        {
                            customerComboBox.Items.Add(reader["customerName"].ToString());
                        }
                    }
                }
            }
        }

        //Update DataGrid with all appointments
        public void BindAppointments(DataGridView dataGridView)
        {
            Log.Debug("Updating list of appointments");
            string connectionString = Settings.Default.ConnectionString;
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                connection.Open();

                using (MySqlCommand command = new MySqlCommand(query, connection))
                {
                    using (MySqlDataAdapter adapter = new MySqlDataAdapter(command))
                    {
                        DataTable dataTable = new DataTable();
                        adapter.Fill(dataTable);
                        dataGridView.DataSource = dataTable;
                    }
                }
            }
        }

        //Update DataGride with all appointments for a given day
        public void BindAppointments(DataGridView dataGridView, DateTime day)
        {
            Log.Debug("Updating list of appointments for " + day);
            string connectionString = Settings.Default.ConnectionString;
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                connection.Open();

                using (MySqlCommand command = new MySqlCommand(query + " WHERE start = @day", connection))
                {
                    command.Parameters.AddWithValue("@day", day.ToString("yyy-MM-dd"));
                    using (MySqlDataAdapter adapter = new MySqlDataAdapter(command))
                    {
                        // 3. Populate a DataTable
                        DataTable dataTable = new DataTable();
                        adapter.Fill(dataTable);

                        // 4. Bind the DataTable to the DataGridView
                        dataGridView.DataSource = dataTable;
                    }
                }
            }
        }

        //Clear form values and update grid.
        private void refreshToolStripMenuItem_Click(object sender, EventArgs e)
        {
            BindAppointments(appointmentGrid);
            RefreshValues();
        }

        // Clear form and update grid with date.
        private void monthCalendar_DateChanged(object sender, EventArgs e)
        {
            BindAppointments(appointmentGrid, monthCalendar.SelectionStart);
            RefreshValues();
        }

        // Clear form and prep for new appointment.
        private void newToolStripMenuItem_Click(object sender, EventArgs e)
        {
            curAppointment = new Appointment();
            RefreshValues();
        }

        //When a new record in the grid is selected, update the current appointment.
        private void appointmentGrid_Changed(object sender, EventArgs e)
        {
            try
            {
                //Set the current appointment to the one selected.
                curAppointment = new Appointment((int)appointmentGrid.CurrentRow.Cells[0].Value);
            }
            catch (Exception ex)
            {
                Log.Error("Failed to update DataGrid Selection. : " + ex.Message);
            }
            finally
            {
                RefreshValues();
            }
        }

        // Save the form data as a new appointment
        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var selectedTimeZoneInfo = (TimeZoneInfo)cmbTimezone.SelectedItem;

            // Copy user entries into current appointment.
            curAppointment.Start = TimeZoneInfo.ConvertTimeToUtc(startDTPick.Value, selectedTimeZoneInfo);
            curAppointment.End = TimeZoneInfo.ConvertTimeToUtc(endDTPick.Value, selectedTimeZoneInfo);
            curAppointment.Url = txtURL.Text;
            curAppointment.Title = titleTextBox.Text;
            curAppointment.Description = descriptionTextBox.Text;
            curAppointment.Contact = contactTextBox.Text;
            curAppointment.Customer = Customer.Lookup((string)customerComboBox.SelectedItem);
            curAppointment.Location = locationTextBox.Text;
            curAppointment.Type = typeTextBox.Text;
            curAppointment.User = Session.CurrentUser;

            try
            {
                Log.Info("Saving appointment");
                curAppointment.Save();
            }
            catch (Exception ex)
            {
                Log.Error("Unable to save appointment");
                MessageBox.Show(ex.Message);
            }
            finally
            {
                RefreshValues();
                BindAppointments(appointmentGrid);
            }
        }

        // Delete the selected appointment.
        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var result = MessageBox.Show("Are you sure you want to delete this appointment?", "Confirmation", MessageBoxButtons.YesNo);
            if (result == DialogResult.No) { return; } //If the user says no, bail. 
            try
            {
                Log.Info("Deleting appointment " + curAppointment.appointmentId);
                curAppointment.Delete();
            }
            catch (Exception ex)
            {
                Log.Error("Unable to delete" + ex.Message);
                MessageBox.Show(ex.Message);
            }
            finally
            {
                RefreshValues();
                BindAppointments(appointmentGrid);
            }
        }

        //Open the customer management Dialogue
        private void customersToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CustomerForm customerForm = new CustomerForm();
            customerForm.Show();
        }

        //Update customer info when selecting a new customer
        private void customerComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            curAppointment.Customer = Customer.Lookup(customerComboBox.SelectedItem.ToString());
        }

        private void tableLayoutPanel2_Paint(object sender, PaintEventArgs e)
        {

        }

        //Update the localized clock for the selected timezone.
        private void timerClock_Tick(object sender, EventArgs e)
        {
            try
            {
                var selectedTimeZoneInfo = (TimeZoneInfo)cmbTimezone.SelectedItem;

                DateTime utcTime = DateTime.UtcNow;
                DateTime localTime = TimeZoneInfo.ConvertTimeFromUtc(utcTime, selectedTimeZoneInfo);

                txtClock.Text = localTime.ToString("yyyy-MM-dd HH:mm:ss");
            }
            catch (Exception ex)
            {
                Log.Error("Failed to update clock : " + ex, "Clock");
            }
        }

        private void cmbTimezone_SelectedIndexChanged(object sender, EventArgs e)
        {
            RefreshValues();
        }

        private void typesByMonthToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Report report = new Report(0);
            report.Show();
        }

        private void scheduleByUserToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Report report = new Report(1);
            report.Show();
        }

        private void additionalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Report report = new Report(2);
            report.Show();
        }

        private void appointmentGrid_KeyUp(object sender, KeyEventArgs e)
        {
            try
            {
                //Set the current appointment to the one selected.
                curAppointment = new Appointment((int)appointmentGrid.CurrentRow.Cells[0].Value);
            }
            catch (Exception ex)
            {
                Log.Error("Failed to update DataGrid Selection. : " + ex.Message);
            }
            finally
            {
                RefreshValues();
            }

        }

    }
}
