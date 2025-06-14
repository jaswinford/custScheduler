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
    public partial class CustomerForm : Form
    {
        private Customer curCustomer = new Customer();
        private string customerQuery = "SELECT customerId, customerName, addressId, active, createDate, createdBy, lastUpdate, lastUpdateBY FROM customer";

        public CustomerForm()
        {
            InitializeComponent();
        }

        private void CustomerForm_Load(object sender, EventArgs e)
        {
            try
            {
                PopulateAddresses();
                PopulateCustomers();
            }
            catch (Exception ex)
            {
                Log.Error(ex.Message);
                MessageBox.Show(ex.Message, "Error");
            }
            ClearForm();
        }


        // Populate the Address ComboBox with all addresses in the DB
        private void PopulateAddresses()
        {
            Log.Debug("Populating Addresses", "Customer Form");
            string connectionString = Settings.Default.ConnectionString;
            string query = "SELECT addressId FROM address";

            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                conn.Open();
                using (MySqlCommand cmd = new MySqlCommand(query, conn))
                {
                    using (MySqlDataReader reader = cmd.ExecuteReader())
                    {
                        cmbAddress.Items.Clear();
                        while (reader.Read())
                        {
                            Address address = new Address((int)reader["addressId"]);
                            cmbAddress.Items.Add(address.AddressId + " | " + address.ToString());
                        }
                    }

                }
            }
        }


        // Populate the customer list with all customers in the DB
        private void PopulateCustomers()
        {
            Log.Debug("Populating list of Customers", "Customer Form");
            string connectionString = Settings.Default.ConnectionString;

            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                conn.Open();
                using (MySqlCommand cmd = new MySqlCommand(customerQuery, conn))
                {
                    using (MySqlDataAdapter adapter = new MySqlDataAdapter(cmd))
                    {
                        DataTable dataTable = new DataTable();
                        adapter.Fill(dataTable);
                        dataGridView1.DataSource = dataTable;
                    }
                }
            }
        }

        // Populate the customer form with the current customer
        private void PopulateForm()
        {
            txtID.Text = curCustomer.customerId.ToString();
            txtAddress.Text = curCustomer.Address.ToString();
            txtCustomerName.Text = curCustomer.customerName;
            txtDetails.Text = "Created on " + curCustomer.createDate.ToString() + " By " + curCustomer.createdBy + "\nLast updated by " + curCustomer.lastUpdateBy + " on " + curCustomer.lastUpdate.ToString();
            chkActive.Checked = curCustomer.active;
        }

        private void ClearForm()
        {
            txtID.Text = "-1";
            txtAddress.Text = "";
            txtCustomerName.Text = "";
            txtDetails.Text = "";
            chkActive.Checked = false;
            cmbAddress.SelectedIndex = 0;
        }

        private void dataGridView1_Click(object sender, EventArgs e)
        {
            curCustomer = new Customer((int)dataGridView1.CurrentRow.Cells[0].Value);
            PopulateForm();
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            PopulateAddresses(); // Make sure we have the latest Addresses.
            ClearForm();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            curCustomer.customerName = txtCustomerName.Text;
            curCustomer.active = chkActive.Checked;
            string addressLine = cmbAddress.SelectedItem.ToString();
            curCustomer.Address = new Address(Int32.Parse(addressLine.Split("|")[0]));
            curCustomer.customerId = Int32.Parse(txtID.Text);
            try
            {
                curCustomer.Save();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Failed to save record : " + ex.Message, "Error");
            }

            PopulateCustomers();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            var result = MessageBox.Show("Are you sure you want to delete this record?", "Confirm", MessageBoxButtons.YesNo);
            if (result == DialogResult.No) { return; } // If user isn't sure, bail.

            try
            {
                curCustomer.Delete();
                MessageBox.Show("Deleted record");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Failed to delete record : " + ex.Message);
            }
            PopulateCustomers();
            ClearForm();
        }

        private void cmbAddress_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                string value = cmbAddress.SelectedItem.ToString();
                curCustomer.Address = new Address(Int32.Parse(value.Split("|")[0]));
                txtAddress.Text = curCustomer.Address.ToString();
            }
            catch (Exception ex)
            {
                Log.Error("Failed to update address box :" + ex.Message);
            }
        }
    }
}
