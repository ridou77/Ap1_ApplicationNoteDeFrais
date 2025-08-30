using GSB_demo.Manager;
using GSB_demo.Models;
using static GSB_demo.Models.LigneFraisHF;

namespace GSB_demo.Views
{
    public partial class UpdateLigneHFForm : Form
    {
        private LigneFraisHF ligneFraisHF;
        private LigneFraisManager ligneFraisManager = new LigneFraisManager();

        public UpdateLigneHFForm(LigneFraisHF ligneFraisHF)
        {
            InitializeComponent();
            this.ligneFraisHF = ligneFraisHF;

            textBox_MajHF.Text = ligneFraisHF.LibelleFraisHF;
            numericUpDown1.Value = (decimal)ligneFraisHF.MontantFraisHF;
            
            LoadStatuts();

            if (ligneFraisHF.StatusFraisHF.HasValue)
            {
                comboBox_StatutHF.SelectedItem = ligneFraisHF.StatusFraisHF.Value;
            }
            else
            {
                comboBox_StatutHF.SelectedItem = StatusFraishf.EN_ATTENTE;
            }
        }

        private void LoadStatuts()
        {
            try
            {
                comboBox_StatutHF.DataSource = Enum.GetValues(typeof(StatusFraishf));
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erreur lors du chargement des statuts : {ex.Message}",
                    "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            }

        private void btn_MajHF_Click(object sender, EventArgs e)
        {
            try
            {
                string libelle = textBox_MajHF.Text.Trim();
                decimal montant = numericUpDown1.Value;
                DateTime dateDepense = ligneFraisHF.DateDepenseFraisHF;
                
                StatusFraishf selectedStatus = StatusFraishf.EN_ATTENTE;
                if (comboBox_StatutHF.SelectedItem != null)
                {
                    selectedStatus = (StatusFraishf)comboBox_StatutHF.SelectedItem;
                }

                if (string.IsNullOrEmpty(libelle))
                {
                    MessageBox.Show("Veuillez saisir un libellé valide.", "Erreur de saisie",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                bool success = UpdateLigneFraisHF(
                    ligneFraisHF.IdLigneFraisHF,
                    libelle,
                    dateDepense,
                    montant,
                    selectedStatus);

                if (success)
                {
                    MessageBox.Show("La ligne de frais hors forfait a été mise à jour avec succès, " +
                        "y compris le statut.",
                        "Mise à jour réussie", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    DialogResult = DialogResult.OK;
                    Close();
                }
                else
                {
                    MessageBox.Show("Une erreur est survenue lors de la mise à jour de la ligne de frais.",
                        "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Une erreur est survenue : {ex.Message}",
                    "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private bool UpdateLigneFraisHF(int idLigneFraisHF, string libelle, DateTime dateDepense, decimal montant, StatusFraishf statut)
        {
            try
            {
                using (var connection = GSB_demo.Utils.DatabaseConnection.GetConnection())
                {
                    connection.Open();
                    string query = "UPDATE ligne_frais_hf SET libelle = @libelle, date_depense = @dateDepense, montant = @montant, etat = @etat WHERE id_ligne_frais_hf = @idLigneFraisHF";
                    using (var cmd = new MySql.Data.MySqlClient.MySqlCommand(query, connection))
                    {
                        cmd.Parameters.AddWithValue("@idLigneFraisHF", idLigneFraisHF);
                        cmd.Parameters.AddWithValue("@libelle", libelle);
                        cmd.Parameters.AddWithValue("@dateDepense", dateDepense);
                        cmd.Parameters.AddWithValue("@montant", montant);
                        cmd.Parameters.AddWithValue("@etat", statut.ToString());
                        return cmd.ExecuteNonQuery() > 0;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erreur lors de la modification de la ligne de frais hors forfait : {ex.Message}",
                    "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }
    }
}