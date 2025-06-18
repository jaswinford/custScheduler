using MySql.Data.MySqlClient;
using Swinford.Logging;

namespace custScheduler
{
    public class User
    {

        //Member Variables

        public int userId = -1;
        public string Name = string.Empty; // userName VARCHAR(50)
        public bool IsActive;
        public string Password = string.Empty; // password VARCHAR(50)
        public DateTime CreatedAt; // createDate DATETIME
        public string CreatedBy = string.Empty; // createdBy VARCHAR(50)
        public DateTime UpdatedAt; // lastUpdate DATETIME
        public string UpdatedBy = string.Empty; // lastUpdateBy VARCHAR(50)

        // Create a User object for a given username. Used for logins.
        public User(string username)
        {
            Log.Info("Looking up user " + username, "user.cs");
            string _connectionString = Settings.Default.ConnectionString;
            using (MySqlConnection connection = new MySqlConnection(_connectionString))
            {
                Log.Debug("Opening connection","user.cs");

                connection.Open();
                string query = "SELECT * FROM user WHERE userName = @input";
                using (MySqlCommand command = new MySqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@input", username);

                    Log.Debug("Executing query","user.cs");

                    using (MySqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            userId = (int)reader["userId"];
                            Name = (string)reader["userName"];
                            IsActive = Convert.ToBoolean(reader["active"]);
                            CreatedAt = (DateTime)reader["createDate"];
                            CreatedBy = (string)reader["createdBy"];
                            UpdatedAt = (DateTime)reader["lastUpdate"];
                            UpdatedBy = (string)reader["lastUpdateBy"];
                            Password = (string)reader["password"];
                        }
                    }
                }
                connection.Close();
            }
        }

        // This function was written to be able to implicitly cast MySqlDataReader as a User.
        //I've since gone with the simpler to code option of just operating entirely on IDs.
        // Left code in case I choose to go this route in the future.
        public static explicit operator User(MySqlDataReader reader)
        {
            var user = new User();
            if (reader.Read())
            {
                user.userId = (int)reader["userId"]; // userId INT
                user.Name = (string)reader["userName"]; // userName VARCHAR(50)
                user.IsActive = Convert.ToBoolean(reader["active"]); // active BOOLEAN
                user.CreatedAt = (DateTime)reader["createDate"]; // createDate DATETIME
                user.CreatedBy = (string)reader["createdBy"]; // createdBy VARCHAR(50)
                user.UpdatedAt = (DateTime)reader["lastUpdate"]; // lastUpdate DATETIME
                user.UpdatedBy = (string)reader["lastUpdateBy"]; // lastUpdateBy VARCHAR(50)
                user.Password = (string)reader["password"]; // password VARCHAR(50)
            }
            return user;
        }

        // Most common constructor. Generates an object by looking it up by ID in the DB.
        public User(int id = -1)
        {
            userId = id;
            Log.Debug("Looking up User-by-ID " + id);
            if (userId == -1)
            {
                Log.Error("Tried to lookup non-existant user");
                return; // If the userId is -1, do not load the user
            }
            string _connectionString = Settings.Default.ConnectionString;

            using (MySqlConnection connection = new MySqlConnection(_connectionString))
            {
                Log.Debug("Opening Connection");
                connection.Open();
                string query = "SELECT * FROM user WHERE userId = @id";
                using (MySqlCommand command = new MySqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@id", userId);
                    using (MySqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            Name = (string)reader["userName"];
                            IsActive = Convert.ToBoolean(reader["active"]);
                            CreatedAt = (DateTime)reader["createDate"];
                            CreatedBy = (string)reader["createdBy"];
                            UpdatedAt = (DateTime)reader["lastUpdate"];
                            UpdatedBy = (string)reader["lastUpdateBy"];
                            Password = (string)reader["password"];
                        }
                    }
                }
                connection.Close();
            }
        }

        //Compares provided password against stored password. 
        public bool Authenticated(string password)
        {
            Log.Debug("Verifying Password");
            if (userId == -1) return false; //If the user is not loaded, return false
            if (string.IsNullOrEmpty(password)) return false; //If the password is empty, return false
            if (password == Password) return true; //If the password matches, return true
            return false;
        }


        // These methods are placeholders for database operations that are not implemented in this example.
        public void Create()
        {
            throw new NotImplementedException("Create method not implemented for User class.");
        }

        public void Update()
        {
            throw new NotImplementedException("Update method not implemented for User class.");
        }

        public void Delete()
        {
            throw new NotImplementedException("Delete method not implemented for User class.");
        }

        public bool IsValid => Name != string.Empty;
    }
}