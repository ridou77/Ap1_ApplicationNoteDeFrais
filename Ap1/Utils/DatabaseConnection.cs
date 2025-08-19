
using MySql.Data.MySqlClient;
using System.Configuration;

namespace GSB_demo.Utils
{
    public class DatabaseConnection
    {
        private static string connectionString =
            ConfigurationManager.ConnectionStrings["GSBDatabase"].ConnectionString;

        public static MySqlConnection GetConnection()
        {
            return new MySqlConnection(connectionString);
        }

        public static bool TestConnection()
        {
            try
            {
                using (var connection = GetConnection())
                {
                    connection.Open();
                    return true;
                }
            }
            catch (Exception ex)


            {
                MessageBox.Show($"Erreur de connexion à la base de données: {ex.Message}",
                    "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }
    }
}
