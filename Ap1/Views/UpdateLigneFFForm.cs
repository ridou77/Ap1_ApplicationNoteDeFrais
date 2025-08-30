using GSB_demo.Manager;
using GSB_demo.Models;
using static GSB_demo.Models.LigneFraisHF;

namespace GSB_demo.Views
{
    public partial class UpdateLigneFFForm : Form
    {
        private LigneFraisForfait ligneFraisForfait;
        private LigneFraisManager ligneFraisManager = new LigneFraisManager();
        private TypeFraisManager typeFraisManager = new TypeFraisManager();

        public UpdateLigneFFForm(LigneFraisForfait ligneFraisForfait)
        {
            InitializeComponent();
            this.ligneFraisForfait = ligneFraisForfait;

            LoadTypeFrais();
            
            LoadStatuts();

            comboBox_MajFF.SelectedValue = ligneFraisForfait.IdTypeFrais;
            
            numericUpDown_MajFF.Value = ligneFraisForfait.Quantite;
            
            if (ligneFraisForfait.StatusFraisFF.HasValue)
            {
                comboBox_StatusModif.SelectedItem = ligneFraisForfait.StatusFraisFF.Value;
            }
            else
            {
                comboBox_StatusModif.SelectedItem = StatusFraishf.EN_ATTENTE;
            }
        }

        private void LoadStatuts()
        {
            try
            {
                comboBox_StatusModif.DataSource = Enum.GetValues(typeof(StatusFraishf));
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erreur lors du chargement des statuts : {ex.Message}",
                    "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoadTypeFrais()
        {
            try
            {
                var typesFrais = typeFraisManager.GetAllTypeFrais();

                comboBox_MajFF.DataSource = typesFrais;
                comboBox_MajFF.DisplayMember = "LibelleTypeFrais";
                comboBox_MajFF.ValueMember = "IdTypeFrais";
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erreur lors du chargement des types de frais : {ex.Message}",
                    "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btn_MajFF_Click(object sender, EventArgs e)
        {
            try
            {
                int idTypeFrais = (int)comboBox_MajFF.SelectedValue;
                int quantite = (int)numericUpDown_MajFF.Value;
                
                StatusFraishf selectedStatus = StatusFraishf.EN_ATTENTE;
                if (comboBox_StatusModif.SelectedItem != null)
                {
                    selectedStatus = (StatusFraishf)comboBox_StatusModif.SelectedItem;
                }

                if (quantite <= 0)
                {
                    MessageBox.Show("La quantité doit être supérieure à zéro.",
                        "Erreur de saisie", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                bool success = UpdateLigneFraisForfait(
                    ligneFraisForfait.IdLigneFraisForfait,
                    idTypeFrais,
                    quantite,
                    selectedStatus);

                if (success)
                {
                    MessageBox.Show("La ligne de frais forfait a été mise à jour avec succès, " +
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

        private bool UpdateLigneFraisForfait(int idLigneFraisForfait, int idTypeFrais, int quantite, StatusFraishf statut)
        {
            try
            {
                using (var connection = GSB_demo.Utils.DatabaseConnection.GetConnection())
                {
                    connection.Open();
                    string query = "UPDATE ligne_frais_forfait SET id_type_frais = @idTypeFrais, quantite = @quantite, etat_ligne_frais_forfait = @etat WHERE id_ligne_frais_forfait = @idLigneFraisForfait";
                    using (var cmd = new MySql.Data.MySqlClient.MySqlCommand(query, connection))
                    {
                        cmd.Parameters.AddWithValue("@idLigneFraisForfait", idLigneFraisForfait);
                        cmd.Parameters.AddWithValue("@idTypeFrais", idTypeFrais);
                        cmd.Parameters.AddWithValue("@quantite", quantite);
                        cmd.Parameters.AddWithValue("@etat", statut.ToString());
                        return cmd.ExecuteNonQuery() > 0;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erreur lors de la modification de la ligne de frais : {ex.Message}",
                    "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }
    }
}