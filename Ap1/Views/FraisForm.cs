using GSB_demo.Manager;
using GSB_demo.Models;

namespace GSB_demo.Views
{
    public partial class FraisForm : Form
    {
        private FicheFrais ficheFrais;
        private LigneFraisManager ligneFraisManager = new LigneFraisManager();
        private TypeFraisManager typeFraisManager = new TypeFraisManager();

        private void LoadLignesFraisForfait()
        {
            var lignes = ligneFraisManager.GetAllLignesFraisForfait(ficheFrais.IdFicheFrais);
            LigneFraisForfaitDG.DataSource = lignes;

            // Calculer le prix total
            CalcAndPrintPrixTotal();
        }

        private void LoadLignesFraisHF()
        {
            var lignes = ligneFraisManager.GetAllLignesFraisHF(ficheFrais.IdFicheFrais);
            ligneFraisHFDG.DataSource = lignes;

            // Calculer le prix total
            CalcAndPrintPrixTotal();
        }

        private void CalcAndPrintPrixTotal()
        {
            try
            {
                // Récupérer tous les types de frais pour avoir accès aux tarifs
                var typesFrais = typeFraisManager.GetAllTypeFrais();

                // Récupérer les lignes de frais forfait
                var lignes = ligneFraisManager.GetAllLignesFraisForfait(ficheFrais.IdFicheFrais);

                // Calculer le montant total
                decimal prixTotal = 0;

                foreach (var ligne in lignes)
                {
                    // Trouver le type de frais
                    var typeFrais = typesFrais.FirstOrDefault(tf => tf.IdTypeFrais == ligne.IdTypeFrais);

                    if (typeFrais != null)
                    {
                        // Calculer le montant pour la ligne en question (quantité × tarif)
                        decimal montantLigne = ligne.Quantite * typeFrais.TarifTypeFrais;
                        prixTotal += montantLigne;
                    }
                }

                // Afficher le prix total dans le label
                TotalPriceFraisForfait.Text = $"Prix total : {prixTotal:C2}";
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erreur lors du calcul du prix total : {ex.Message}",
                    "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void InitializeInterface()
        {
            LigneFraisForfaitDG.AutoGenerateColumns = false;
            LigneFraisForfaitDG.Columns.Clear();

            LigneFraisForfaitDG.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "LibelleTypeFrais",
                HeaderText = "Libellé Type Frais",
                DataPropertyName = "LibelleTypeFrais",
                Width = 150
            });
            LigneFraisForfaitDG.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "Quantite",
                HeaderText = "Nombre",
                DataPropertyName = "Quantite",
                Width = 80
            });
        }

        public FraisForm(FicheFrais fiche)
        {
            InitializeComponent();
            InitializeInterface();
            ficheFrais = fiche;
            label1.Text = $"Fiche de frais du : {ficheFrais.DateCreationFicheFrais:dd/MM/yyyy}";
            LoadLignesFraisForfait();
            LoadLignesFraisHF();
        }

        private void btnAddFraisForfait_Click(object sender, EventArgs e)
        {
            try
            {
                // Récupérer l'utilisateur connecté depuis le MainForm
                User connectedUser = ((MainForm)this.Owner).connectedUser;

                var NewLigneFraisForfaitForm = new NewLigneFraisForfaitForm(ficheFrais.IdFicheFrais);
                NewLigneFraisForfaitForm.ShowDialog();
                LoadLignesFraisForfait(); // Recharge la DataGridView après fermeture
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Une erreur est survenue : {ex.Message}",
                    "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btn_AddFraisHF_Click(object sender, EventArgs e)
        {
            try
            {
                // Récupérer l'utilisateur connecté depuis le MainForm
                User connectedUser = ((MainForm)this.Owner).connectedUser;

                var NewLigneFraisHFForm = new NewLigneFraisHFForm(ficheFrais.IdFicheFrais);
                NewLigneFraisHFForm.ShowDialog();
                LoadLignesFraisHF(); // Recharge la DataGridView après fermeture
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Une erreur est survenue : {ex.Message}",
                    "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
