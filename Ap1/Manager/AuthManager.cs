using System;
using System.Data;
using System.Security.Cryptography;
using System.Text;
using System.Windows.Forms;
using GSB_demo.Models;
using GSB_demo.Utils;
using Microsoft.VisualBasic.Logging;
using MySql.Data.MySqlClient;

namespace GSB_demo.Manager
{
    public class AuthManager
    {
        public string HashPassword(string password)
        {
            return Convert.ToHexString(SHA256.HashData(Encoding.UTF8.GetBytes(password)));
        }

        public User AuthenticateUser(string login, string password)
        {
            try
            {
                string hashedPassword = HashPassword(password);

                using (var connection = DatabaseConnection.GetConnection())
                {
                    connection.Open();
                    string query = @"SELECT id_user, id_role, nom, prenom, email, login, motdepasse_hash, actif, user_creation_date
                                   FROM users
                                   WHERE login = @login AND motdepasse_hash = @Mdp AND actif = TRUE";

                    using (var cmd = new MySqlCommand(query, connection))
                    {
                        cmd.Parameters.AddWithValue("@login", login);
                        cmd.Parameters.AddWithValue("@Mdp", hashedPassword);

                        using (var reader = cmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                return new User
                                {
                                    IdUser = reader.GetInt32("id_user"),
                                    Role = (User.RoleUser)reader.GetInt32("id_role"),
                                    Nom = reader.GetString("nom"),
                                    Prenom = reader.GetString("prenom"),
                                    Email = reader.IsDBNull("email") ? "" : reader.GetString("email"),
                                    Login = reader.GetString("login"),
                                    Mdp = reader.GetString("motdepasse_hash"),
                                    Actif = reader.GetBoolean("actif"),
                                    UserCreationDate = reader.GetDateTime("user_creation_date"),
                                };
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erreur lors de l'authentification: {ex.Message}",
                    "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return null;
        }
    }
}
