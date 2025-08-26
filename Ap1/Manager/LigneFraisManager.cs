using GSB_demo.Models;
using GSB_demo.Utils;
using MySql.Data.MySqlClient;
using static GSB_demo.Models.LigneFraisHF;

namespace GSB_demo.Manager;
public class LigneFraisManager
{
    public List<LigneFraisForfait> GetAllLignesFraisForfait(int idFicheFrais)
    {
        var lignesForfait = new List<LigneFraisForfait>();
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
                            lignesForfait.Add(new LigneFraisForfait
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
        return lignesForfait;
    }
    public bool AddLigneFraisForfait(int idFicheFrais, int idTypeFrais, int quantite)
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

    public List<LigneFraisHF> GetAllLignesFraisHF(int idFicheFrais)
    {
        var ligneFraisHF = new List<LigneFraisHF>();

        try
        {
            using (var connection = DatabaseConnection.GetConnection())
            {
                connection.Open();
                // Modifié pour utiliser id_fiche_frais au lieu de id_fiche
                string query = @"SELECT lfh.id_ligne_frais_hf, lfh.id_fiche, lfh.libelle, lfh.date_depense, lfh.montant, lfh.etat, lfh.motif_refus
                             FROM ligne_frais_hf lfh
                             WHERE lfh.id_fiche = @idFicheFrais";
                using (var cmd = new MySqlCommand(query, connection))
                {
                    cmd.Parameters.AddWithValue("@idFicheFrais", idFicheFrais);
                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            ligneFraisHF.Add(new LigneFraisHF
                            {
                                IdLigneFraisHF = reader.GetInt32("id_ligne_frais_hf"),
                                IdFiche = reader.GetInt32("id_fiche"), // Utiliser la propriété correcte
                                LibelleFraisHF = reader.GetString("libelle"),
                                DateDepenseFraisHF = reader.GetDateTime("date_depense"),
                                MontantFraisHF = reader.GetDecimal("montant"),
                                // Utiliser IsDBNull avant de lire une colonne qui peut être null
                                StatusFraisHF = reader.IsDBNull(reader.GetOrdinal("etat"))
                                    ? StatusFraishf.EN_ATTENTE
                                    : Enum.TryParse<StatusFraishf>(reader.GetString("etat"), out var status)
                                        ? status
                                        : StatusFraishf.EN_ATTENTE,
                                MotifRefusFraisHF = reader.IsDBNull(reader.GetOrdinal("motif_refus")) ? null : reader.GetString("motif_refus")
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
        return ligneFraisHF;
    }

    public bool AddLigneFraisHF(int idFicheFrais, string LibelleFraisHF, DateTime DateDepenseFraisHF, decimal MontantFraisHF, StatusFraishf? StatusFraisHF, string? MotifRefusFraisHF)
    {
        try
        {
            using (var connection = DatabaseConnection.GetConnection())
            {
                connection.Open();
                string query = @"INSERT INTO ligne_frais_hf (id_fiche, libelle, date_depense, montant, etat, motif_refus)
                            VALUES (@idFicheFrais, @LibelleFraisHF, @DateDepenseFraisHF, @MontantFraisHF, @StatusFraisHF, @MotifRefusFraisHF)";
                using (var cmd = new MySqlCommand(query, connection))
                {
                    cmd.Parameters.AddWithValue("@idFicheFrais", idFicheFrais);
                    cmd.Parameters.AddWithValue("@LibelleFraisHF", LibelleFraisHF);
                    cmd.Parameters.AddWithValue("@DateDepenseFraisHF", DateDepenseFraisHF);
                    cmd.Parameters.AddWithValue("@MontantFraisHF", MontantFraisHF);
                    // Gérer correctement les valeurs nulles
                    cmd.Parameters.AddWithValue("@StatusFraisHF", StatusFraisHF?.ToString() ?? StatusFraishf.EN_ATTENTE.ToString());
                    cmd.Parameters.AddWithValue("@MotifRefusFraisHF", MotifRefusFraisHF ?? (object)DBNull.Value);
                    return cmd.ExecuteNonQuery() > 0;
                }
            }
        }
        catch (MySqlException ex)
        {
            MessageBox.Show($"Erreur MySQL ({ex.Number}): {ex.Message}", "Erreur MySQL", MessageBoxButtons.OK, MessageBoxIcon.Error);
            return false;
        }
        catch (Exception ex)
        {
            MessageBox.Show($"Erreur lors de l'ajout de la ligne de frais : {ex.Message}",
                "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
            return false;
        }
    }
}