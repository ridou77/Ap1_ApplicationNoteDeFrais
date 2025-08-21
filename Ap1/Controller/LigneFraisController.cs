using GSB_demo.Utils;
using MySql.Data.MySqlClient;
using GSB_demo.Models;

namespace GSB_demo.Controller
{
    public class LigneFraisController
    {
        public List<LigneFraisForfait> GetAllLignesFraisForfait(int idFicheFrais)
        {
            var lignes = new List<LigneFraisForfait>();
            try
            {
                using (var connection = DatabaseConnection.GetConnection())
                {
                    connection.Open();
                    string query = @"SELECT lff.id_ligne_frais_forfait, lff.id_fiche_frais, lff.id_type_frais, lff.quantite, tf.libelle_type_frais
                                     FROM ligne_frais_forfait lff
                                     LEFT JOIN type_frais tf ON lff.id_type_frais = tf.id_type_frais
                                     WHERE lff.id_fiche_frais = @idFicheFrais";
                    using (var cmd = new MySqlCommand(query, connection))
                    {
                        cmd.Parameters.AddWithValue("@idFicheFrais", idFicheFrais);
                        using (var reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                lignes.Add(new LigneFraisForfait
                                {
                                    IdLigneFraisForfait = reader.GetInt32("id_ligne_frais_forfait"),
                                    IdFicheFrais = reader.GetInt32("id_fiche_frais"),
                                    IdTypeFrais = reader.GetInt32("id_type_frais"),
                                    Quantite = reader.GetInt32("quantite"),
                                    LibelleTypeFrais = reader.GetString("libelle_type_frais")
                                });
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erreur lors de la récupération des lignes de frais : {ex.Message}",
                    "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return lignes;
        }
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