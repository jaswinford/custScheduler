using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Swinford.Logging;

namespace custScheduler
{
    public partial class AppointmentForm : Form
    {
        //Query for populating the Datagrid
        private readonly string query = "SELECT appointmentId,title,location,contact,type,start,end,description FROM appointment";

        // Store the currently viewed/manipulated appointment locally
        private Appointment curAppointment = new Appointment();
        public AppointmentForm()
        {
            InitializeComponent();
        }

        // On load, Bind the DataGrid to the above query then alert on upcoming appointments
        private void Form1_Load(object sender, EventArgs e)
        {
            BindAppointments(appointmentGrid);
            AlertUpcomingAppointments();
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
                    cmd.Parameters.AddWithValue("@now", DateTime.Now);
                    cmd.Parameters.AddWithValue("@future", DateTime.Now.AddMinutes(15));
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
            PopulateCustomers();
            customerComboBox.SelectedItem = curAppointment.Customer.customerName;
            IDBox.Text = curAppointment.appointmentId.ToString();
            titleTextBox.Text = curAppointment.Title;
            descriptionTextBox.Text = curAppointment.Description;
            startDTPick.Value = curAppointment.Start;
            endDTPick.Value = curAppointment.End;
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
        }

        // Clear form and update grid with date.
        private void monthCalendar_DateChanged(object sender, EventArgs e)
        {
            BindAppointments(appointmentGrid, monthCalendar.SelectionStart);
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
            // Copy user entries into current appointment.
            curAppointment.Start = startDTPick.Value;
            curAppointment.End = endDTPick.Value;
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
                Log.Info("Deleting appointment "+curAppointment.appointmentId);
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
    }
}
