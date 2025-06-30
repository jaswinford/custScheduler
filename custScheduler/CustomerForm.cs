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
                PopulateCities();
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
            string query = "SELECT addressId, address FROM address";

            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                conn.Open();
                using (MySqlDataAdapter da = new MySqlDataAdapter(query, conn))
                {
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    cmbAddress.DataSource = dt;
                    cmbAddress.DisplayMember = "address";
                    cmbAddress.ValueMember = "addressId";
                }
            }
        }

        private void PopulateAddressFields()
        {
            txtAddress1.Text = curCustomer.Address.Address1;
            txtAddress2.Text = curCustomer.Address.Address2;
            cmbCity.SelectedValue = curCustomer.Address.City.cityId;
            txtPostalCode.Text = curCustomer.Address.PostalCode;
            txtPhone.Text = curCustomer.Address.Phone;

        }
        private void PopulateCities()
        {
            Log.Debug("Populating cities", "Customer Form");
            string connectionString = Settings.Default.ConnectionString;
            string query = "SELECT cityId, city FROM city";

            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                conn.Open();
                using (MySqlDataAdapter da = new MySqlDataAdapter(query, conn))
                {
                    cmbCity.Items.Clear();
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    cmbCity.DataSource = dt;
                    cmbCity.DisplayMember = "city";
                    cmbCity.ValueMember = "cityid";
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

            PopulateAddressFields();
            txtCustomerName.Text = curCustomer.customerName;
            txtDetails.Text = "Created on " + curCustomer.createDate.ToString() + " By " + curCustomer.createdBy + "\nLast updated by " + curCustomer.lastUpdateBy + " on " + curCustomer.lastUpdate.ToString();
            chkActive.Checked = curCustomer.active;
            cmbAddress.SelectedValue = curCustomer.Address.AddressId;
        }

        private void ClearForm()
        {
            curCustomer = new Customer();
            PopulateForm();
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
            try
            {
                curCustomer.Address.Save();
                curCustomer.Save();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Failed to save record : " + ex.Message, "Error");
            }

            PopulateCustomers();
            PopulateForm();
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
            if (cmbAddress.SelectedValue != null && cmbAddress.SelectedValue is not DataRowView) {
                curCustomer.Address = new Address((int)cmbAddress.SelectedValue);
                PopulateAddressFields();
            }
        }

        private void txtPhone_KeyPress(object sender, KeyPressEventArgs e)
        {
            char ch = e.KeyChar;

            // Allow digits, parentheses, hyphen, space, and backspace, but no other keys
            if (!char.IsDigit(ch) && ch != '(' && ch != ')' && ch != '-' && ch != '\b' && ch != ' ')
            {
                // If key isn't allowed, mark the event as handled to skip processing the input.
                e.Handled = true;
            }
        }

        private void txtPhone_TextChanged(object sender, EventArgs e)
        {
            curCustomer.Address.Phone = txtPhone.Text;
        }

        private void txtCustomerName_TextChanged(object sender, EventArgs e)
        {
            curCustomer.customerName = txtCustomerName.Text;
        }

        private void chkActive_CheckedChanged(object sender, EventArgs e)
        {
            curCustomer.active = chkActive.Checked;
        }

        private void dataGridView1_KeyPress(object sender, KeyPressEventArgs e)
        {
            curCustomer = new Customer((int)dataGridView1.CurrentRow.Cells[0].Value);
            PopulateForm();
        }

        private void txtAddress1_TextChanged(object sender, EventArgs e)
        {
            curCustomer.Address.Address1 = txtAddress1.Text;
        }

        private void txtAddress2_TextChanged(object sender, EventArgs e)
        {
            curCustomer.Address.Address2 = txtAddress2.Text;

        }

        private void txtPostalCode_TextChanged(object sender, EventArgs e)
        {
            curCustomer.Address.PostalCode = txtPostalCode.Text;
        }

        private void txtPostalCode_KeyPress(object sender, KeyPressEventArgs e)
        {
            char ch = e.KeyChar;

            // Allow digits, parentheses, hyphen, space, and backspace, but no other keys
            if (!char.IsDigit(ch) && ch != '-' && ch != '\b' && ch != ' ')
            {
                // If key isn't allowed, mark the event as handled to skip processing the input.
                e.Handled = true;
            }

        }

        private void cmbCity_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbCity.SelectedValue != null && cmbCity.SelectedValue is not DataRowView) 
            { 
                curCustomer.Address.City = new City((int)cmbCity.SelectedValue);
            }
        }
    }
}
