using System.Data;
using GSB_demo.Models;
using GSB_demo.Utils;
using Microsoft.VisualBasic.Logging;
using MySql.Data.MySqlClient;

namespace GSB_demo.Controller
{
    public class TypeFraisController
    {
        public List<TypeFrais> GetAllTypeFrais()
        {
            var typesFrais = new List<TypeFrais>();
            try
            {
                using (var connection = DatabaseConnection.GetConnection())
                {
                    connection.Open();
                    string query = @"SELECT id_type_frais, libelle_type_frais, tarif_type_frais FROM type_frais";

                    using (var cmd = new MySqlCommand(query, connection))
                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            typesFrais.Add(new TypeFrais
                            {
                                IdTypeFrais = reader.GetInt32("id_type_frais"),
                                LibelleTypeFrais = reader.GetString("libelle_type_frais"),
                                TarifTypeFrais = reader.GetDecimal("tarif_type_frais")
                            });
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erreur lors de la récupération des types de frais: {ex.Message}",
                    "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return typesFrais;
        }
    }
}
