using System;
using System.Security.Cryptography;
using System.Text;
using System.Windows.Forms;
using GSB_demo.Models;
using MySql.Data.MySqlClient;
using GSB_demo.Utils;

namespace GSB_demo.Manager
{
    public class AddUserManager
    {
        // Méthode pour hasher un mot de passe en une ligne
        public string HashPassword(string password)
        {
            return Convert.ToHexString(SHA256.HashData(Encoding.UTF8.GetBytes(password)));
        }

        public bool AddUser(User user)
        {
            try
            {
                using (MySqlConnection connection = DatabaseConnection.GetConnection())
                {
                    connection.Open();
                    
                    // Hasher le mot de passe avant de l'enregistrer
                    string hashedPassword = HashPassword(user.Mdp);
                    
                    string query = @"INSERT INTO users (id_role, nom, prenom, email, login, motdepasse_hash, actif, user_creation_date) 
                                     VALUES (@Role, @Nom, @Prenom, @Email, @Login, @Mdp, @Actif, @UserCreationDate)";
                    
                    using (MySqlCommand command = new MySqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@Role", (int)user.Role);
                        command.Parameters.AddWithValue("@Nom", user.Nom);
                        command.Parameters.AddWithValue("@Prenom", user.Prenom);
                        command.Parameters.AddWithValue("@Email", user.Email);
                        command.Parameters.AddWithValue("@Login", user.Login);
                        command.Parameters.AddWithValue("@Mdp", hashedPassword); // Utilisation du mot de passe hashé
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
        
        // Méthode pour vérifier un mot de passe
        public bool VerifyPassword(string enteredPassword, string storedHash)
        {
            // Hasher le mot de passe entré
            string enteredPasswordHash = HashPassword(enteredPassword);
            
            // Comparer avec le hash stocké
            return enteredPasswordHash.Equals(storedHash);
        }
    }
}
