using System.Data;
using GSB_demo.Utils;
using GSB_demo.Models;
using MySql.Data.MySqlClient;

namespace GSB_demo.Manager
{
    public class AddUserManager
    {
        public bool AddUser(User user)
        {
            try
            {
                using (MySqlConnection connection = DatabaseConnection.GetConnection())
                {
                    connection.Open();
                    
                    string query = @"INSERT INTO users (id_role, nom, prenom, email, login, motdepasse_hash, actif, user_creation_date) 
                                     VALUES (@Role, @Nom, @Prenom, @Email, @Login, @Mdp, @Actif, @UserCreationDate)";
                    
                    using (MySqlCommand command = new MySqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@Role", (int)user.Role);
                        command.Parameters.AddWithValue("@Nom", user.Nom);
                        command.Parameters.AddWithValue("@Prenom", user.Prenom);
                        command.Parameters.AddWithValue("@Email", user.Email);
                        command.Parameters.AddWithValue("@Login", user.Login);
                        command.Parameters.AddWithValue("@Mdp", user.Mdp);
                        command.Parameters.AddWithValue("@Actif", user.Actif);
                        command.Parameters.AddWithValue("@UserCreationDate", user.UserCreationDate);
                        
                        int rowsAffected = command.ExecuteNonQuery();
                        return rowsAffected > 0;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erreur lors de l'ajout de l'utilisateur : {ex.Message}", 
                    "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }
    }
}
