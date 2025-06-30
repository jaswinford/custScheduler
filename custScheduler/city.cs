using MySql.Data.MySqlClient;
using Swinford.Logging;

namespace custScheduler
{
    /// <summary>
    /// City object and logic to interact with DB for city records
    /// </summary>
    /// <remarks>
    /// </remarks>
    public partial class City 
    {
        public int cityId = -1; // cityId INT
        public string Name = string.Empty;
        public Country Country = new Country();
        public DateTime CreatedAt = DateTime.Now; // createDate DATETIME
        public string CreatedBy = string.Empty; // createdBy VARCHAR(50)
        public DateTime UpdatedAt = DateTime.Now; // lastUpdate DATETIME
        public string UpdatedBy = string.Empty; // lastUpdateBy VARCHAR(50)

        public static explicit operator City(MySqlDataReader reader)
        {
            var city = new City();
            if (reader.Read())
            {
                city.cityId = (int)reader["cityId"]; // cityId INT
                city.Name = (string)reader["city"]; // city VARCHAR(50)
                city.Country = new Country((int)reader["countryId"]); // countryId INT
                city.CreatedAt = (DateTime)reader["createDate"]; // createDate DATETIME
                city.CreatedBy = (string)reader["createdBy"]; // createdBy VARCHAR(50)
                city.UpdatedAt = (DateTime)reader["lastUpdate"]; // lastUpdate DATETIME
                city.UpdatedBy = (string)reader["lastUpdateBy"]; // lastUpdateBy VARCHAR(50)
            }
            return city;
        }

        public City(int id = -1)
        {
            cityId = id;
            if (cityId == -1) return; // If the cityId is -1, do not load the city
            string _connectionString = Settings.Default.ConnectionString;
            using (MySqlConnection connection = new MySqlConnection(_connectionString))
            {
                connection.Open();
                string query = "SELECT * FROM city WHERE cityId = @id";
                using (MySqlCommand command = new MySqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@id", cityId);
                    using (MySqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            Name = (string)reader["city"]; // city VARCHAR(50)
                            Country = new Country((int)reader["countryId"]); // countryId INT
                            CreatedAt = (DateTime)reader["createDate"]; // createDate DATETIME
                            CreatedBy = (string)reader["createdBy"]; // createdBy VARCHAR(50)
                            UpdatedAt = (DateTime)reader["lastUpdate"]; // lastUpdate DATETIME
                            UpdatedBy = (string)reader["lastUpdateBy"]; // lastUpdateBy VARCHAR(50)
                        }
                    }
                }
            }
        }
        public City(string cityName)
        {
            string _connectionString = Settings.Default.ConnectionString;
            using (MySqlConnection connection = new MySqlConnection(_connectionString))
            {
                connection.Open();
                string query = "SELECT * FROM city WHERE city = @cityName";
                using (MySqlCommand command = new MySqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@id", cityId);
                    using (MySqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            cityId = (int)reader["cityId"];
                            Name = (string)reader["city"]; // city VARCHAR(50)
                            Country = new Country((int)reader["countryId"]); // countryId INT
                            CreatedAt = (DateTime)reader["createDate"]; // createDate DATETIME
                            CreatedBy = (string)reader["createdBy"]; // createdBy VARCHAR(50)
                            UpdatedAt = (DateTime)reader["lastUpdate"]; // lastUpdate DATETIME
                            UpdatedBy = (string)reader["lastUpdateBy"]; // lastUpdateBy VARCHAR(50)
                        }
                    }
                }
            }
        }

        private void Create()
        {
            string connectionString = Settings.Default.ConnectionString;
            string query = "INSERT INTO city (city, countryId, createDate, createdBy, lastUpdate, lastUpdateBy)" +
                "VALUES (@city, @countryId, @createDate, @createdBy, @lastUpdate, @lastUpdateBy);";

            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                conn.Open();
                using (MySqlCommand command = new MySqlCommand(query, conn))
                {
                    command.Parameters.AddWithValue("@city", Name);
                    command.Parameters.AddWithValue("@countryId", Country.countryId);
                    command.Parameters.AddWithValue("@createDate", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
                    command.Parameters.AddWithValue("@lastUpdate", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
                    command.Parameters.AddWithValue("@createdBy", Session.CurrentUser.Name);
                    command.Parameters.AddWithValue("@lastUpdateBy", Session.CurrentUser.Name);

                    try
                    {
                        command.ExecuteNonQuery();
                    }
                    catch (Exception ex)
                    {
                        string message = "Failed to create city : " + ex.Message;
                        Log.Error(message);
                        throw new Exception(message);
                    }
                }
            }
        }

        private void Update()
        {
            string connectionString = Settings.Default.ConnectionString;
            string query = "UPDATE city SET city = @city, countryId = @countryId, lastUpdate = @lastUpdate, lastUpdateBy = @lastUpdateBy";

            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                connection.Open();
                using (MySqlCommand cmd = new MySqlCommand(query, connection))
                {
                    cmd.Parameters.AddWithValue("@city", Name);
                    cmd.Parameters.AddWithValue("@countryId", Country.countryId);
                    cmd.Parameters.AddWithValue("@lastUpdate", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
                    cmd.Parameters.AddWithValue("@lastUpdateBy", Session.CurrentUser.Name);

                    try
                    {
                        cmd.ExecuteNonQuery();
                    }
                    catch (Exception ex)
                    {
                        string message = "Failed to update city :" + ex.Message;
                        Log.Error(message);
                        throw new Exception(message);
                    }
                }
            }
        }

        public void Save()
        {
            if (cityId != -1)
            {
                Update();
            }
            else
            {
                Create();
            }
        }

        public void Delete()
        {
            throw new NotImplementedException();
        }

        public bool IsValid => Name != string.Empty && Country.countryId != -1;
    }
}