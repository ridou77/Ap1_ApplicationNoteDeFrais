using System.Data;
using GSB_demo.Utils;
using GSB_demo.Models;
using MySql.Data.MySqlClient;

namespace GSB_demo.Manager;
    public class FicheFraisManager
    {
        public List<FicheFrais> GetAllFicheFrais()
        {
            var ficheFrais = new List<FicheFrais>();
            try
            {
                using (var connection = DatabaseConnection.GetConnection())
                {
                    connection.Open();
                    string query = @"SELECT ff.id_fiche_frais, ff.id_user, ff.id_comptable, ff.etat_fiche_frais, 
                               ff.date_creation_fiche_frais, ff.date_validation_fiche_frais, 
                               ff.date_modification_fiche_frais, ff.date_cloture_fiche_frais, 
                               ff.motif_refus_fiche_frais, u.nom, u.prenom
                            FROM fiche_frais ff
                            JOIN users u ON ff.id_user = u.id_user";

                    using (var cmd = new MySqlCommand(query, connection))
                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            string etatString = reader.GetString("etat_fiche_frais");
                            FicheFrais.EtatFicheFrais etat;
                            
                            if (Enum.TryParse(etatString, out etat))
                            {
                                ficheFrais.Add(new FicheFrais
                                {
                                    IdFicheFrais = reader.GetInt32("id_fiche_frais"),
                                    IdUser = reader.GetInt32("id_user"),
                                    NomUtilisateur = $"{reader.GetString("prenom")} {reader.GetString("nom")}",
                                    IdComptable = reader.IsDBNull("id_comptable") ? 0 : reader.GetInt32("id_comptable"),
                                    Etat = etat,
                                    DateCreationFicheFrais = reader.GetDateTime("date_creation_fiche_frais"),
                                    DateValidationFicheFrais = reader.IsDBNull("date_validation_fiche_frais") ? DateTime.MinValue : reader.GetDateTime("date_validation_fiche_frais"),
                                    DateModificationFicheFrais = reader.IsDBNull("date_modification_fiche_frais") ? DateTime.MinValue : reader.GetDateTime("date_modification_fiche_frais"),
                                    DateClotureFicheFrais = reader.IsDBNull("date_cloture_fiche_frais") ? DateTime.MinValue : reader.GetDateTime("date_cloture_fiche_frais"),
                                    MotifRefusFicheFrais = reader.IsDBNull("motif_refus_fiche_frais") ? "" : reader.GetString("motif_refus_fiche_frais")
                                });
                            }
                            else
                            {
                                MessageBox.Show($"Valeur d'état non reconnue: {etatString}", "Avertissement", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erreur lors de la récupération des fiches de frais: {ex.Message}",
                    "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return ficheFrais;
        }

        public FicheFrais GetFicheFraisById(int idFicheFrais)
        {
            try
            {
                using (var connection = DatabaseConnection.GetConnection())
                {
                    connection.Open();
                    string query = @"SELECT id_fiche_frais, id_user, id_comptable, etat_fiche_frais, date_creation_fiche_frais, date_validation_fiche_frais, date_modification_fiche_frais,
                                          date_cloture_fiche_frais, motif_refus_fiche_frais
                                   FROM fiche_frais
                                   WHERE id_fiche_frais = @id_fiche_frais";

                    using (var cmd = new MySqlCommand(query, connection))
                    {
                        cmd.Parameters.AddWithValue("@id_fiche_frais", idFicheFrais);

                        using (var reader = cmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                string etatString = reader.GetString("etat_fiche_frais");
                                FicheFrais.EtatFicheFrais etat;
                                
                                if (Enum.TryParse(etatString, out etat))
                                {
                                    return new FicheFrais
                                    {
                                        IdFicheFrais = reader.GetInt32("id_fiche_frais"),
                                        IdUser = reader.GetInt32("id_user"),
                                        IdComptable = reader.IsDBNull("id_comptable") ? null : reader.GetInt32("id_comptable"),
                                        Etat = etat,
                                        DateCreationFicheFrais = reader.GetDateTime("date_creation_fiche_frais"),
                                        DateValidationFicheFrais = reader.IsDBNull("date_validation_fiche_frais") ? DateTime.MinValue : reader.GetDateTime("date_validation_fiche_frais"),
                                        DateModificationFicheFrais = reader.IsDBNull("date_modification_fiche_frais") ? DateTime.MinValue : reader.GetDateTime("date_modification_fiche_frais"),
                                        DateClotureFicheFrais = reader.IsDBNull("date_cloture_fiche_frais") ? DateTime.MinValue : reader.GetDateTime("date_cloture_fiche_frais"),
                                        MotifRefusFicheFrais = reader.IsDBNull("motif_refus_fiche_frais") ? "" : reader.GetString("motif_refus_fiche_frais")
                                    };
                                }
                                else
                                {
                                    MessageBox.Show($"Valeur d'état non reconnue: {etatString}", "Avertissement", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                    return null;
                                }
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erreur lors de la récupération de la fiche de frais: {ex.Message}",
                    "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return null;
        }

        public bool AddFicheFrais(FicheFrais fiche)
        {
            try
            {
                using (var connection = DatabaseConnection.GetConnection())
                {
                    connection.Open();
                    string query = @"INSERT INTO fiche_frais
                (id_user, id_comptable, etat_fiche_frais, 
                date_creation_fiche_frais, date_validation_fiche_frais, 
                date_modification_fiche_frais, date_cloture_fiche_frais, 
                motif_refus_fiche_frais)
                VALUES 
                (@id_user, @id_comptable, @etat_fiche_frais, 
                @date_creation, @date_validation, 
                @date_modification, @date_cloture, 
                @motif_refus)";

                    using (var cmd = new MySqlCommand(query, connection))
                    {
                        cmd.Parameters.AddWithValue("@id_user", fiche.IdUser);
                        cmd.Parameters.AddWithValue("@id_comptable", fiche.IdComptable);
                        cmd.Parameters.AddWithValue("@etat_fiche_frais", fiche.Etat.ToString());
                        cmd.Parameters.AddWithValue("@date_creation", fiche.DateCreationFicheFrais);
                        cmd.Parameters.AddWithValue("@date_validation", fiche.DateValidationFicheFrais);
                        cmd.Parameters.AddWithValue("@date_modification", fiche.DateModificationFicheFrais);
                        cmd.Parameters.AddWithValue("@date_cloture", fiche.DateClotureFicheFrais);
                        cmd.Parameters.AddWithValue("@motif_refus", fiche.MotifRefusFicheFrais);

                        return cmd.ExecuteNonQuery() > 0;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erreur lors de l'ajout de la fiche de frais : {ex.Message}",
                    "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        public bool DeleteFicheFrais(int idFicheFrais)
        {
            try
            {
                using (var connection = DatabaseConnection.GetConnection())
                {
                    connection.Open();
                    string query = @"DELETE FROM fiche_frais WHERE id_fiche_frais = @id_fiche_frais";
                    using (var cmd = new MySqlCommand(query, connection))
                    {
                        cmd.Parameters.AddWithValue("@id_fiche_frais", idFicheFrais);
                        return cmd.ExecuteNonQuery() > 0;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erreur lors de la suppression de la fiche de frais : {ex.Message}",
                    "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        // Méthode pour vérifier et mettre à jour les statuts des fiches de frais
public void UpdateAllFicheFraisStatus()
{
    try
    {
        var allFicheFrais = GetAllFicheFrais();
        DateTime today = DateTime.Now;
        
        foreach (var fiche in allFicheFrais)
        {
            DateTime moisFiche = fiche.DateCreationFicheFrais;
            DateTime moisSuivant = moisFiche.AddMonths(1);
            
            // Une fiche doit être clôturée si nous sommes dans le mois suivant sa création
            // et si au moins le 10 du mois
            bool shouldClose = (today.Year > moisSuivant.Year || 
                              (today.Year == moisSuivant.Year && today.Month >= moisSuivant.Month)) && 
                              today.Day >= 10 && 
                              fiche.Etat == FicheFrais.EtatFicheFrais.EN_COURS;
                
            
            if (shouldClose)
            {
                var ligneFraisManager = new LigneFraisManager();
                var lignesFraisForfait = ligneFraisManager.GetAllLignesFraisForfait(fiche.IdFicheFrais);
                var lignesHorsForfait = ligneFraisManager.GetAllLignesFraisHF(fiche.IdFicheFrais);
                
                bool allValidated = true;
                bool allRejected = true;
                bool hasRejected = false;
                
                foreach (var ligne in lignesFraisForfait)
                {
                    if (ligne.StatusFraisFF == LigneFraisForfait.StatusFraisff.EN_ATTENTE)
                    {
                        allValidated = false;
                        allRejected = false;
                    }
                    else if (ligne.StatusFraisFF == LigneFraisForfait.StatusFraisff.REFUSE)
                    {
                        allValidated = false;
                        hasRejected = true;
                    }
                    else if (ligne.StatusFraisFF == LigneFraisForfait.StatusFraisff.ACCEPTE)
                    {
                        allRejected = false;
                    }
                }
                
                foreach (var ligne in lignesHorsForfait)
                {
                    if (ligne.StatusFraisHF == LigneFraisHF.StatusFraishf.EN_ATTENTE)
                    {
                        allValidated = false;
                        allRejected = false;
                    }
                    else if (ligne.StatusFraisHF == LigneFraisHF.StatusFraishf.REFUSE)
                    {
                        allValidated = false;
                        hasRejected = true;
                    }
                    else if (ligne.StatusFraisHF == LigneFraisHF.StatusFraishf.ACCEPTE)
                    {
                        allRejected = false;
                    }
                }
                
                FicheFrais.EtatFicheFrais nouveauStatut;
                
                if (allValidated)
                {
                    nouveauStatut = FicheFrais.EtatFicheFrais.VALIDEE;
                }
                else if (allRejected)
                {
                    nouveauStatut = FicheFrais.EtatFicheFrais.REFUSEE;
                }
                else if (hasRejected)
                {
                    nouveauStatut = FicheFrais.EtatFicheFrais.REFUS_PARTIEL;
                }
                else
                {
                    nouveauStatut = FicheFrais.EtatFicheFrais.EN_ATTENTE;
                }
                
                UpdateFicheFraisStatus(
                    fiche.IdFicheFrais, 
                    nouveauStatut,
                    nouveauStatut == FicheFrais.EtatFicheFrais.VALIDEE ? today : null,
                    today);
            }
        }
    }
    catch (Exception ex)
    {
        MessageBox.Show($"Erreur lors de la mise à jour des statuts des fiches de frais : {ex.Message}",
            "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
    }
}

// methode pour mettre à jour le statut d'une fiche de frais
public bool UpdateFicheFraisStatus(int idFicheFrais, FicheFrais.EtatFicheFrais etat, 
    DateTime? dateValidation = null, DateTime? dateCloture = null, string? motifRefus = null)
{
    try
    {
        using (var connection = DatabaseConnection.GetConnection())
        {
            connection.Open();
            string query = @"UPDATE fiche_frais 
                           SET etat_fiche_frais = @etat, 
                               date_validation_fiche_frais = @dateValidation,
                               date_modification_fiche_frais = @dateModification,
                               date_cloture_fiche_frais = @dateCloture,
                               motif_refus_fiche_frais = @motifRefus
                           WHERE id_fiche_frais = @idFicheFrais";

            using (var cmd = new MySqlCommand(query, connection))
            {
                cmd.Parameters.AddWithValue("@idFicheFrais", idFicheFrais);
                cmd.Parameters.AddWithValue("@etat", etat.ToString());
                cmd.Parameters.AddWithValue("@dateValidation", dateValidation ?? (object)DBNull.Value);
                cmd.Parameters.AddWithValue("@dateModification", DateTime.Now);
                cmd.Parameters.AddWithValue("@dateCloture", dateCloture ?? (object)DBNull.Value);
                cmd.Parameters.AddWithValue("@motifRefus", motifRefus ?? (object)DBNull.Value);

                return cmd.ExecuteNonQuery() > 0;
            }
        }
    }
    catch (Exception ex)
    {
        MessageBox.Show($"Erreur lors de la mise à jour du statut de la fiche de frais : {ex.Message}",
            "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
        return false;
    }
}
    }