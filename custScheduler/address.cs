using MySql.Data.MySqlClient;
using System.Text.RegularExpressions;

namespace custScheduler
{
    /// <summary>
    /// Address object and logic to interact with DB for address records
    /// </summary>
    public class Address
    {
        // Public Variables
        public int AddressId = -1; // addressId INT
        public string Address1 = string.Empty;
        public string Address2 = string.Empty;
        public City City = new City();
        public string PostalCode = string.Empty;
        public string Phone = string.Empty;
        public DateTime CreateDate = DateTime.Now; // createDate DATETIME
        public string CreatedBy = string.Empty; // createdBy VARCHAR(50)
        public DateTime LastUpdate = DateTime.Now; // lastUpdate DATETIME
        public string LastUpdateBy = string.Empty; // lastUpdateBy VARCHAR(50)


        // Implemented to allow Implicit Casting. No longer used.
        public static explicit operator Address(MySqlDataReader reader)
        {
            var address = new Address();
            if (reader.Read())
            {
                address.AddressId = (int)reader["addressId"]; // addressId INT
                address.Address1 = (string)reader["address"]; // address VARCHAR(50)
                address.Address2 = (string)reader["address2"]; // address2 VARCHAR(50)
                address.City = new City((int)reader["cityId"]);
                address.PostalCode = (string)reader["postalCode"]; // postalCode VARCHAR(20)
                address.Phone = (string)reader["phone"]; // phone VARCHAR(20)
                address.CreateDate = (DateTime)reader["createDate"]; // createDate DATETIME
                address.CreatedBy = (string)reader["createdBy"]; // createdBy VARCHAR(50)
                address.LastUpdate = (DateTime)reader["lastUpdate"]; // lastUpdate DATETIME
                address.LastUpdateBy = (string)reader["lastUpdateBy"]; // lastUpdateBy VARCHAR(50)
            }
            return address;
        }

        // Create Address by DB ID.
        public Address(int id = -1)
        {
            AddressId = id;
            if (AddressId == -1) return; // If the AddressId is -1, do not load the address
            string _connectionString = Settings.Default.ConnectionString;
            using (MySqlConnection connection = new MySqlConnection(_connectionString))
            {
                connection.Open();
                string query = "SELECT * FROM address WHERE addressId = @id";
                using (MySqlCommand command = new MySqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@id", AddressId);
                    using (MySqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            Address1 = (string)reader["address"];
                            Address2 = (string)reader["address2"];
                            City = new City((int)reader["cityId"]);
                            PostalCode = (string)reader["postalCode"];
                            Phone = (string)reader["phone"];
                            CreateDate = (DateTime)reader["createDate"];
                            CreatedBy = (string)reader["createdBy"];
                            LastUpdate = (DateTime)reader["lastUpdate"];
                            LastUpdateBy = (string)reader["lastUpdateBy"];
                        }
                    }
                }
            }
        }


        public bool IsValid
        {
            get
            {
                if (Address1 == string.Empty || City.Name == string.Empty || PostalCode == string.Empty ||
                    Phone == string.Empty) return false; //verify address is provided
                if (!Regex.IsMatch(Phone, @"^[0-9-]+$")) return false;
                return true;
            }
        }

        // Functions

        // Only read functions are implemented in this example.
        public void Create()
        {
            throw new NotImplementedException(); //Create method not implemented for Address class
        }
        public void Update()
        {
            throw new NotImplementedException(); //Update method not implemented for Address class
        }
        public void Delete()
        {
            throw new NotImplementedException(); //Delete method not implemented for Address class
        }

        //Pretty-print the address
        public override string ToString()
        {
            string output = "";
            if (Address1 != string.Empty) output += Address1 + Environment.NewLine;
            if (Address2 != string.Empty) output += Address2 + Environment.NewLine;
            if (City.Name != string.Empty) output += City.Name + ", ";
            if (PostalCode != string.Empty) output += PostalCode + Environment.NewLine;
            if (Phone != string.Empty) output += Phone;
            return output;
        }

        internal static Address Lookup(string text)
        {
            // Split the address by linebreaks
            var addressLines = text.Split(new string[] { System.Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries);
            string address = addressLines[0].Trim();
            string address2 = addressLines[1].Trim();

            // City and Postcode are on the same line, need to split them again.
            var cityCode = addressLines[2].Split(",");
            // var city = cityCode[0]; we don't really need the city, and this saves another lookup
            var postalCode = cityCode[1];


            // Now we're ready to lookup the address in the DB.

            string query = "SELECT addressId FROM address WHERE address = @address AND address2 = @address2 AND postalCode = @postalCode";
            string connectionString = Settings.Default.ConnectionString;

            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                conn.Open();
                using (MySqlCommand cmd = new MySqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@address", address);
                    cmd.Parameters.AddWithValue("@address2", address2);
                    cmd.Parameters.AddWithValue("@postalCode", postalCode);
                    using (MySqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            Address output = new Address((int)reader["addressId"]);
                            return output;
                        }
                        return null;
                    }
                }
            }
        }
    }
}