using GSB_demo.Utils;
using MySql.Data.MySqlClient;

namespace GSB_demo.Controller
{
    public class LigneFraisController
    {
        public bool AddLigneFrais(int idFicheFrais, int idTypeFrais, int quantite)
        {
            try
            {
                using (var connection = DatabaseConnection.GetConnection())
                {
                    connection.Open();
                    string query = @"INSERT INTO ligne_frais_forfait (id_fiche_frais, id_type_frais, quantite)
                                     VALUES (@idFicheFrais, @idTypeFrais, @quantite)";
                    using (var cmd = new MySqlCommand(query, connection))
                    {
                        cmd.Parameters.AddWithValue("@idFicheFrais", idFicheFrais);
                        cmd.Parameters.AddWithValue("@idTypeFrais", idTypeFrais);
                        cmd.Parameters.AddWithValue("@quantite", quantite);
                        return cmd.ExecuteNonQuery() > 0;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erreur lors de l'ajout de la ligne de frais : {ex.Message}",
                    "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }
    }
}