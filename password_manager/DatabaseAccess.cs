using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Password_manager
{
    public class DatabaseAccess
    {
        private static DatabaseAccess instance = null;
        private static string connectionString = @"Server=(localdb)\MSSqlLocalDb;Database=PasswordManager;Trusted_Connection=True;";
        private static SqlConnection database = new SqlConnection(connectionString);
        private string errorMessage = "";
        public string ErrorMessage { get => errorMessage; private set { errorMessage = value; } }

        private DatabaseAccess() {}

        public static DatabaseAccess getInstance()
        {
            if (instance == null)
            {
                instance = new DatabaseAccess();
                database.Open();
            }

            return instance;
        }

        public bool newPasswordEntry(int userID ,String name, String email, String password)
        {
            
            //whether adding a row to the database was successful
            bool success = true;
            string query = "INSERT INTO LoginInfo VALUES (@UserID,@LoginUsername,@LoginPassword,@LoginName)";

            try
            {
                using (var command = new SqlCommand(query, database))
                {
                    command.Parameters.AddWithValue("@UserID", userID);
                    command.Parameters.AddWithValue("@LoginUsername", email);
                    command.Parameters.AddWithValue("@LoginPassword", password);
                    command.Parameters.AddWithValue("@LoginName", name);
                    command.ExecuteNonQuery();
                    command.Connection.Close();
                }
            }
            catch (Exception error)
            {
                ErrorMessage = error.Message;
                success = false;
            }

            return success;
        }

        public bool newUserEntry(String username, String userPassword)
        {
            //whether adding a row to the database was successful
            bool success = true;
            string query = "INSERT INTO Users VALUES (@Username,@UserPassword)";

            try
            {
                using (var command = new SqlCommand(query, database))
                {
                    command.Parameters.AddWithValue("@Username", username);
                    command.Parameters.AddWithValue("@UserPassword", userPassword);
                    command.ExecuteNonQuery();
                }
            }
            catch (Exception error)
            {
                ErrorMessage = error.Message;
                success = false;
            }

            return success;

        }

        public bool removePasswordEntry(int userID, string name)
        {
            bool success = true;
            string query = "DELETE FROM LoginInfo WHERE LoginName = @UserID AND LoginPassword = @LoginName";

            try
            {
                using (var command = new SqlCommand(query, database))
                {
                    command.Parameters.AddWithValue("@UserID", userID);
                    command.Parameters.AddWithValue("@LoginName", name);
                    command.ExecuteNonQuery();
                }
            }
            catch (Exception error)
            {
                ErrorMessage = error.Message;
                success = false;
            }

            return success;
        }

        public static void closeConnection()
        {
            database.Close();
        }
    }
}
