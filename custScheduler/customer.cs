using MySql.Data.MySqlClient;
using Swinford.Logging;

namespace custScheduler
{
    /// <summary>
    /// Customer object and logic to interact with DB for customer records
    /// </summary>
    public class Customer
    {
        // Public Variables
        public int customerId = -1;
        public string customerName = string.Empty;
        public Address Address = new Address();
        public bool active = true;
        public DateTime createDate = DateTime.Now;
        public string createdBy = string.Empty;
        public DateTime lastUpdate = DateTime.Now;
        public string lastUpdateBy = string.Empty;


        public Customer()
        {
            Address = new Address();
        }
        public static explicit operator Customer(MySqlDataReader reader)
        {
            var customer = new Customer();
            if (reader.Read())
            {
                customer.customerId = (int)reader["customerId"]; // customerId INT
                customer.customerName = (string)reader["customerName"]; // customerName VARCHAR(50)
                customer.active = Convert.ToBoolean(reader["active"]); // active BOOLEAN
                customer.createDate = (DateTime)reader["createDate"]; // createDate DATETIME
                customer.createdBy = (string)reader["createdBy"]; // createdBy VARCHAR(50)
                customer.lastUpdate = (DateTime)reader["lastUpdate"]; // lastUpdate DATETIME
                customer.lastUpdateBy = (string)reader["lastUpdateBy"]; // lastUpdateBy VARCHAR(50)
                customer.Address = new Address((int)reader["addressId"]);
            }
            return customer;
        }

        public Customer(int id = -1)
        {
            Log.Debug("Looking up customer " + id);
            customerId = id;
            if (customerId == -1) return; // If the customerId is -1, do not load the customer
            string _connectionString = Settings.Default.ConnectionString;
            using (MySqlConnection connection = new MySqlConnection(_connectionString))
            {
                Log.Debug("Opening connection");
                connection.Open();
                string query = "SELECT * FROM customer WHERE customerId = @id";
                using (MySqlCommand command = new MySqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@id", customerId);
                    using (MySqlDataReader reader = command.ExecuteReader())
                    {
                        Log.Debug("Parsing Data");
                        if (reader.Read())
                        {
                            customerName = (string)reader["customerName"]; // customerName VARCHAR(50)
                            active = Convert.ToBoolean(reader["active"]);
                            createDate = (DateTime)reader["createDate"]; // createDate DATETIME
                            createdBy = (string)reader["createdBy"]; // createdBy VARCHAR(50)
                            lastUpdate = (DateTime)reader["lastUpdate"]; // lastUpdate DATETIME
                            lastUpdateBy = (string)reader["lastUpdateBy"]; // lastUpdateBy VARCHAR(50)
                            Address = new Address((int)reader["addressId"]);
                        }
                    }
                }
            }
        }
        private void Create()
        {
            Log.Debug("Creating new record", "customer.cs");
            string query = "INSERT INTO customer " +Environment.NewLine + 
                "(customerName, addressId, active, createDate, createdBy, lastUpdate, lastUpdateBy) " +Environment.NewLine +
                "VALUES ( @customerName, @addressId, @active, @createDate, @createdBy, @lastUpdate, @lastUpdateBy);";
            string connectionString = Settings.Default.ConnectionString;

            try
            {
                using (MySqlConnection conn = new MySqlConnection(connectionString))
                {
                    conn.Open();
                    using (MySqlCommand cmd = new MySqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@customerName", customerName);
                        cmd.Parameters.AddWithValue("@addressid", Address.AddressId);
                        cmd.Parameters.AddWithValue("@active", active);
                        cmd.Parameters.AddWithValue("@createDate", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
                        cmd.Parameters.AddWithValue("@createdBy", Session.CurrentUser.Name);
                        cmd.Parameters.AddWithValue("@lastUpdate", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
                        cmd.Parameters.AddWithValue("@lastUpdateBy", Session.CurrentUser.Name);

                        cmd.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                string message = "Failed to create record. : " + ex.Message;
                Log.Error(message , "customer.cs");
                throw new Exception(message);
            }
        }

        private void Update()
        {
            string query = "UPDATE customer" + Environment.NewLine + 
                "SET customerName = @customerName, addressId = @addressId, active = @active, lastUpdate = @lastUpdate, lastUpdateBy = @lastUpdateBy " + Environment.NewLine +
                "WHERE customerId = @customerId";
            string connectionString = Settings.Default.ConnectionString;

            try
            {
                using (MySqlConnection conn = new MySqlConnection(connectionString))
                {
                    conn.Open();
                    using (MySqlCommand cmd = new MySqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@customerName", customerName);
                        cmd.Parameters.AddWithValue("@addressId", Address.AddressId);
                        cmd.Parameters.AddWithValue("@active", active);
                        cmd.Parameters.AddWithValue("@lastUpdate", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
                        cmd.Parameters.AddWithValue("@lastUpdateBy", Session.CurrentUser.Name);
                        cmd.Parameters.AddWithValue("@customerId", customerId);
                        cmd.ExecuteNonQuery();
                    }
                }

            }
            catch (Exception ex)
            {
                string message = "Failed to update " + customerId + ": " + ex.Message;
                Log.Error(message, "customer.cs");
                throw new Exception(message);
            }
        }

        public void Save()
        {

            // Perform validity check, then either Create or Update depending on if we have an ID or not.
            if (!IsValid) { throw new Exception("Customer is not valid"); }
            if (customerId == -1) { Create(); }
            else { Update(); }
        }

        public void Delete()
        {
            string connectionString = Settings.Default.ConnectionString;
            string query = "DELETE FROM customer WHERE appointmentId = @id";

            try
            {
                using (MySqlConnection conn = new MySqlConnection(connectionString)){
                    conn.Open();
                    using (MySqlCommand cmd = new MySqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@id", customerId);
                        cmd.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                string message = "Failed to delete record :" + ex;
                Log.Error(message, "customer.cs");
                throw new Exception(message);
            }
        }


        //Look up customer by their Name
        public static Customer Lookup(string value)
        {
            Log.Debug("Looking up " + value, "customer.cs");
            Customer output = new Customer();

            string _connectionString = Settings.Default.ConnectionString;
            using (MySqlConnection connection = new MySqlConnection(_connectionString))
            {
                Log.Debug("opening connection", "customer.cs");
                connection.Open();
                string query = "SELECT * FROM customer WHERE customerName = @name";
                using (MySqlCommand command = new MySqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@name", value);
                    using (MySqlDataReader reader = command.ExecuteReader())
                    {
                        Log.Debug("reading data", "customer.cs");
                        if (reader.Read())
                        {
                            output.customerId = (int)reader["customerId"];
                            output.customerName = (string)reader["customerName"]; // customerName VARCHAR(50)
                            output.active = Convert.ToBoolean(reader["active"]);
                            output.createDate = (DateTime)reader["createDate"]; // createDate DATETIME
                            output.createdBy = (string)reader["createdBy"]; // createdBy VARCHAR(50)
                            output.lastUpdate = (DateTime)reader["lastUpdate"]; // lastUpdate DATETIME
                            output.lastUpdateBy = (string)reader["lastUpdateBy"]; // lastUpdateBy VARCHAR(50)
                            output.Address = new Address((int)reader["addressId"]);
                        }
                    }
                }
            }
            return output;
        }

        public bool IsValid =>
            customerName != string.Empty &&
            Address.IsValid;
    }
}