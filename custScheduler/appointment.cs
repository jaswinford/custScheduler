using MySql.Data.MySqlClient;
using Swinford.Logging;

namespace custScheduler
{
    public class Appointment{

        // Member Variables

        public int appointmentId = -1; // appointmentId INT
        public Customer Customer = new Customer(); // customerId INT
        public User User = new User(); // userId INT
        public string Title = string.Empty; // title VARCHAR(50)
        public string Description = string.Empty; // description VARCHAR(50)
        public string Location = string.Empty; // location VARCHAR(50)
        public string Contact = string.Empty; // contact VARCHAR(50)
        public string Type = string.Empty; // type VARCHAR(50)
        public string Url = string.Empty; // url VARCHAR(100)
        public DateTime Start = DateTime.Now; // start DATETIME
        public DateTime End = DateTime.Now; // end DATETIME
        public DateTime CreatedAt = DateTime.Now; // createDate DATETIME
        public string CreatedBy = string.Empty; // createdBy VARCHAR(50)
        public DateTime UpdatedAt = DateTime.Now; // lastUpdate DATETIME
        public string UpdatedBy = string.Empty; // lastUpdateBy VARCHAR(50)


        // Pretty Print the update/creating times.
        public string Details { get
            {
                return "Created By " + CreatedBy + " on " + CreatedAt.ToString() + Environment.NewLine + "Last Update on " + UpdatedAt.ToString() + " by " + UpdatedBy;
            } }

        // No longer used. Allows for implicit casting of Appointments. 
        public static explicit operator Appointment(MySqlDataReader reader)
        {
            var appointment = new Appointment();
            if (reader.Read())
            {
                appointment.appointmentId = (int)reader["appointmentId"]; // appointmentId INT
                appointment.Customer = new Customer((int)reader["customerId"]); // customerId INT
                appointment.User = new User((int)reader["userId"]); // userId INT
                appointment.Title = (string)reader["title"]; // title VARCHAR(50)
                appointment.Description = (string)reader["description"]; // description VARCHAR(50)
                appointment.Location = (string)reader["location"]; // location VARCHAR(50)
                appointment.Contact = (string)reader["contact"]; // contact VARCHAR(50)
                appointment.Type = (string)reader["type"]; // type VARCHAR(50)
                appointment.Url = (string)reader["url"]; // url VARCHAR(100)
                appointment.Start = (DateTime)reader["start"]; // start DATETIME
                appointment.End = (DateTime)reader["end"]; // end DATETIME
                appointment.CreatedAt = (DateTime)reader["createDate"]; // createDate DATETIME
                appointment.CreatedBy = (string)reader["createdBy"]; // createdBy VARCHAR(50)
                appointment.UpdatedAt = (DateTime)reader["lastUpdate"]; // lastUpdate DATETIME
                appointment.UpdatedBy = (string)reader["lastUpdateBy"]; // lastUpdateBy VARCHAR(50)
            }
            return appointment;
        }


        // Populate data by appointmentId.
        public Appointment(int id = -1)
        {
            Log.Debug("Looking up appointment " + id, "appointment.cs");
            appointmentId = id;
            if (appointmentId == -1) return; // If the appointmentId is -1, do not load the appointment
            string _connectionString = Settings.Default.ConnectionString;
            using (MySqlConnection connection = new MySqlConnection(_connectionString))
            {
                Log.Debug("Connecting to DB", "appointment.cs");
                connection.Open();
                string query = "SELECT * FROM appointment WHERE appointmentId = @id";
                using (MySqlCommand command = new MySqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@id", appointmentId);
                    using (MySqlDataReader reader = command.ExecuteReader())
                    {
                        Log.Debug("Reading data", "appointment.cs");
                        if (reader.Read())
                        {
                            Customer = new Customer((int)reader["customerId"]); // customerId INT
                            User = new User((int)reader["userId"]); // userId INT
                            Title = (string)reader["title"]; // title VARCHAR(50)
                            Description = (string)reader["description"]; // description VARCHAR(50)
                            Location = (string)reader["location"]; // location VARCHAR(50)
                            Contact = (string)reader["contact"]; // contact VARCHAR(50)
                            Type = (string)reader["type"]; // type VARCHAR(50)
                            Url = (string)reader["url"]; // url VARCHAR(100)
                            Start = (DateTime)reader["start"]; // start DATETIME
                            End = (DateTime)reader["end"]; // end DATETIME
                            CreatedAt = (DateTime)reader["createDate"]; // createDate DATETIME
                            CreatedBy = (string)reader["createdBy"]; // createdBy VARCHAR(50)
                            UpdatedAt = (DateTime)reader["lastUpdate"]; // lastUpdate DATETIME
                            UpdatedBy = (string)reader["lastUpdateBy"]; // lastUpdateBy VARCHAR(50)

                            //Set DateTimeKinds to UTC
                            Start = DateTime.SpecifyKind(Start, DateTimeKind.Utc);
                            End = DateTime.SpecifyKind(End, DateTimeKind.Utc);
                            CreatedAt = DateTime.SpecifyKind(CreatedAt, DateTimeKind.Utc);
                            UpdatedAt = DateTime.SpecifyKind(UpdatedAt, DateTimeKind.Utc);
                        }
                    }
                }
            }
        }

        // Check validity based on provided business rules 
        public bool IsValid =>
            Customer.customerId != -1 &&
            User.userId != -1 &&
            Start.DayOfWeek != DayOfWeek.Saturday &&
            Start.DayOfWeek != DayOfWeek.Sunday &&
            End.DayOfWeek != DayOfWeek.Saturday &&
            End.DayOfWeek != DayOfWeek.Sunday &&
            Start.Hour > 13 && Start.Hour < 21 &&
            End.Hour > 13 && End.Hour < 21 &&
            Start.TimeOfDay < End.TimeOfDay;

        public bool HasConflicts { get
            {
                string query = "SELECT appointmentId " + Environment.NewLine +
                    "FROM appointment " + Environment.NewLine +
                    "WHERE userId = @userId " + Environment.NewLine +
                    "AND (start BETWEEN @start AND @end OR end BETWEEN @start AND @end)";
                string connectionString = Settings.Default.ConnectionString;

                try
                {
                    using (MySqlConnection con = new MySqlConnection(connectionString))
                    {
                        con.Open();
                        using (MySqlCommand cmd = new MySqlCommand(query, con))
                        {
                            cmd.Parameters.AddWithValue("@userId", User.userId);
                            cmd.Parameters.AddWithValue("@start", Start.ToString("yyyy-MM-dd HH:mm:ss"));
                            cmd.Parameters.AddWithValue("@end", End.ToString("yyyy-MM-dd HH:mm:ss"));

                            using (MySqlDataReader reader = cmd.ExecuteReader())
                            {
                                return reader.HasRows;
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    Log.Error(ex.Message, "appointment.cs");
                    throw ex;
                }
            } }


        // Create new records. This can only be called internally and relies on the calling function to perform validity checks
        private void Create()
        {
            // Before save, check for conflicts.
            if (HasConflicts) { throw new Exception("Appointment conflicts with existing event"); }

            Log.Debug("Attempting to create record", "appointment.cs");
            string connectionString = Settings.Default.ConnectionString;
            string query = "INSERT INTO appointment (customerId," +
                "userId,title,description,location,contact,type,url," +
                "start,end,createDate,createdBy,lastUpdate,lastUpdateBy) " +
                "VALUES (@customerId,@userId,@title,@description," +
                "@location,@contact,@type,@url,@start,@end,@createDate," +
                "@createBy,@lastUpdate,@lastUpdateBy);";


            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                Log.Debug("Connecting to DB");
                conn.Open();
                using (MySqlCommand cmd = new MySqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@customerid", Customer.customerId);
                    cmd.Parameters.AddWithValue("@userId", Session.CurrentUser.userId);
                    cmd.Parameters.AddWithValue("@title", Title);
                    cmd.Parameters.AddWithValue("@description", Description);
                    cmd.Parameters.AddWithValue("@location", Location);
                    cmd.Parameters.AddWithValue("@contact", Contact);
                    cmd.Parameters.AddWithValue("@type", Type);
                    cmd.Parameters.AddWithValue("@url", Url);
                    cmd.Parameters.AddWithValue("@start", Start.ToString("yyyy-MM-dd HH:mm:ss"));
                    cmd.Parameters.AddWithValue("@end", End.ToString("yyyy-MM-dd HH:mm:ss"));
                    cmd.Parameters.AddWithValue("@createDate", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
                    cmd.Parameters.AddWithValue("@createBy", Session.CurrentUser.Name);
                    cmd.Parameters.AddWithValue("@lastUpdate", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
                    cmd.Parameters.AddWithValue("@lastUpdateBy", Session.CurrentUser.Name);

                    Log.Debug("Writing Data");

                    try
                    {
                        cmd.ExecuteNonQuery();
                    }
                    catch (Exception ex)
                    {
                        string message = ("Failed to create record. : " + ex.Message);
                        Log.Error(message);
                        throw new Exception(message);
                    }
                }
            }
        }

        // Update existing records. Called internally and performs no checks
        private void Update()
        {
            string connectionString = Settings.Default.ConnectionString;
            string query = "UPDATE appointment" + Environment.NewLine +
                "SET userId = @userId, title = @title, description = @description, location = @location, contact=@contact," + Environment.NewLine +
                " type = @type, url=@url, start=@start,end = @end, lastUpdate = @lastUpdate, lastUpdateBy = @lastUpdateBy " + Environment.NewLine +
                "WHERE appointmentId = @id";
            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                conn.Open();
                using (MySqlCommand cmd = new MySqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@customerid", Customer.customerId);
                    cmd.Parameters.AddWithValue("@userId", User.userId);
                    cmd.Parameters.AddWithValue("@title", Title);
                    cmd.Parameters.AddWithValue("@description", Description);
                    cmd.Parameters.AddWithValue("@location", Location);
                    cmd.Parameters.AddWithValue("@contact", Contact);
                    cmd.Parameters.AddWithValue("@type", Type);
                    cmd.Parameters.AddWithValue("@url", Url);
                    cmd.Parameters.AddWithValue("@start", Start.ToString("yyyy-MM-dd HH:mm:ss"));
                    cmd.Parameters.AddWithValue("@end", End.ToString("yyyy-MM-dd HH:mm:ss"));
                    cmd.Parameters.AddWithValue("@lastUpdate", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
                    cmd.Parameters.AddWithValue("@lastUpdateBy", User.Name);
                    cmd.Parameters.AddWithValue("@id", appointmentId);
                    try
                    {
                        cmd.ExecuteNonQuery();
                    }
                    catch (Exception ex)
                    {
                        throw new Exception(ex.ToString());
                    }
                }
            }
 
        }

        // If this is new, use the Create function, if not, use the Update function.
        // Validation is performed here and will stop if record doesn't meet business rules
        public void Save()
        {

            // This if statement should probably be moved to the IsValid function, eventually.
            if (!IsValid)
            {
                string message = "Appointment Not Valid";
                if (Customer.customerId == -1) message += "\n"+Customer.customerId + ":Customer Not Found";
                if (User.userId == -1) message += "\nInvalid User";
                if (Start.DayOfWeek == DayOfWeek.Saturday) message += "\nCan't start on Saturday";
                if (Start.DayOfWeek == DayOfWeek.Sunday) message += "\nCan't start on Sunday";
                if (End.DayOfWeek == DayOfWeek.Saturday) message += "\nCan't End on Saturday";
                if (End.DayOfWeek == DayOfWeek.Sunday) message += "\nCan't end on Sunday";
                if (Start.Hour < 9 || Start.Hour > 17) message += "\n" + Start.Hour + " Can't start outside business hours";
                if (End.Hour < 9 || End.Hour > 17) message += "\n" + End.Hour+ " Can't end after business hours";
                if (Start.TimeOfDay > End.TimeOfDay) message += "\nStart time must be before end time";

                throw new Exception(message); 
            }


            // If we don't have an ID, create a new appointment. Otherwise, try to update the current appointment.
            if (appointmentId == -1) { Create(); }
            else { Update(); }
        }

        // Deletes record from DB. 
        public void Delete()
        {
            string connectionString = Settings.Default.ConnectionString;
            string query = "DELETE FROM appointment WHERE appointmentId = @id";
            try
            {
                using (MySqlConnection conn = new MySqlConnection(connectionString))
                {
                    conn.Open();
                    using (MySqlCommand cmd = new MySqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@id", appointmentId);
                        cmd.ExecuteNonQuery();
                    }
                }
            } 
            catch (Exception ex)
            {
                string message = "Failed to delete record :" + ex;
                Log.Error(message, "appointment.cs");
                throw new Exception(message);
            }

        }
    }
}