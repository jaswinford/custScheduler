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
        public void Create()
        {
            throw new NotImplementedException("Create method not implemented for Customer class.");
        }

        public void Update()
        {
            throw new NotImplementedException("Update method not implemented for Customer class.");
        }

        public void Delete()
        {
            throw new NotImplementedException("Delete method not implemented for Customer class.");
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