using GSB_demo.Manager;
using GSB_demo.Models;

namespace GSB_demo.Views
{
    public partial class FraisForm : Form
    {
        private FicheFrais ficheFrais;
        private LigneFraisManager ligneFraisManager = new LigneFraisManager();
        private TypeFraisManager typeFraisManager = new TypeFraisManager();
        public User connectedUser { get; private set; }


        private void LoadLignesFraisForfait()
        {
            var lignes = ligneFraisManager.GetAllLignesFraisForfait(ficheFrais.IdFicheFrais);
            LigneFraisForfaitDG.DataSource = lignes;

            // Calculer le prix total
            CalcAndPrintPrixTotalFF();
        }

        private void LoadLignesFraisHF()
        {
            var lignes = ligneFraisManager.GetAllLignesFraisHF(ficheFrais.IdFicheFrais);
            ligneFraisHFDG.DataSource = lignes;

            // Calculer le prix total
            CalcAndPrintPrixTotalHF();
        }

        private void ConfigurePermissions()
        {
            if (connectedUser == null)
            {
                // Si l'utilisateur n'est pas initialisé, on masque tous les boutons
                btn_deleteFF.Visible = false;
                btn_UpdateFF.Visible = false;
                btn_DeleteHF.Visible = false;
                btn_UpdateHF.Visible = false;
                return;
            }
            
            // Configurer les permissions selon le rôle
            switch (connectedUser.Role)
            {
                case User.RoleUser.ADMIN: // Administrateur
                    btn_deleteFF.Visible = true;
                    btn_UpdateFF.Visible = true;
                    btn_DeleteHF.Visible = true;
                    btn_UpdateHF.Visible = true;
                    break;
                case User.RoleUser.COMPTABLE: // Comptable
                    btn_deleteFF.Visible = true;
                    btn_UpdateFF.Visible = true;
                    btn_DeleteHF.Visible = true;
                    btn_UpdateHF.Visible = true;
                    break;
                case User.RoleUser.VISITEUR: // Visiteur
                    btn_deleteFF.Visible = true;
                    btn_UpdateFF.Visible = false;
                    btn_DeleteHF.Visible = true;
                    btn_UpdateHF.Visible = false;
                    break;
                default:
                    btn_deleteFF.Visible = false;
                    btn_UpdateFF.Visible = false;
                    btn_DeleteHF.Visible = false;
                    btn_UpdateHF.Visible = false;
                    break;
            }
        }

        private void CalcAndPrintPrixTotalFF()
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

        private void CalcAndPrintPrixTotalHF()
        {
            try
            {
                var lignes = ligneFraisManager.GetAllLignesFraisHF(ficheFrais.IdFicheFrais) ?? new List<LigneFraisHF>();

                decimal prixTotal = 0m;

                foreach (var ligne in lignes)
                {
                    // Utiliser la propriété MontantFraisHF du modèle
                    prixTotal += ligne.MontantFraisHF;
                }

                // Afficher le prix total des frais hors forfait dans le label dédié
                TotalPriceFraisHorsForfait.Text = $"Prix total : {prixTotal:C2}";
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erreur lors du calcul du total hors forfait : {ex.Message}",
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
            LigneFraisForfaitDG.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "StatusFraisHF",
                HeaderText = "Statut",
                DataPropertyName = "StatusFraisHF",
                Width = 80
            });
            var checkBoxLigneFF = new DataGridViewCheckBoxColumn
            {
                Name = "Selectionner",
                HeaderText = "Sélectionner",
                ReadOnly = false,
                Width = 103
            };
            LigneFraisForfaitDG.Columns.Add(checkBoxLigneFF);
        }
        private void InitializeInterfaceHF()
        {
            ligneFraisHFDG.AutoGenerateColumns = false;
            ligneFraisHFDG.Columns.Clear();

            ligneFraisHFDG.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "LibelleFraisHF",
                HeaderText = "Libellé Frais HF",
                DataPropertyName = "LibelleFraisHF",
                Width = 150
            });
            ligneFraisHFDG.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "DateDepenseFraisHF",
                HeaderText = "Date Dépense",
                DataPropertyName = "DateDepenseFraisHF",
                Width = 100
            });
            ligneFraisHFDG.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "MontantFraisHF",
                HeaderText = "Montant",
                DataPropertyName = "MontantFraisHF",
                Width = 80
            });
            ligneFraisHFDG.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "StatusFraisHF",
                HeaderText = "Statut",
                DataPropertyName = "StatusFraisHF",
                Width = 80
            });
            var btnVoirMotifRefus = new DataGridViewButtonColumn
            {
                Name = "MotifRefusFraisHF",
                HeaderText = "Motif Refus",
                Text = "Voir le motif du refus",
                UseColumnTextForButtonValue = true,
                Width = 150
            };
            ligneFraisHFDG.Columns.Insert(4, btnVoirMotifRefus);
            var checkBoxLigneHF = new DataGridViewCheckBoxColumn
            {
                Name = "Selectionner",
                HeaderText = "Sélectionner",
                ReadOnly = false,
                Width = 103
            };
            ligneFraisHFDG.Columns.Insert(5, checkBoxLigneHF);
        }

        public FraisForm(FicheFrais fiche)
        {
            InitializeComponent();
            ficheFrais = fiche;
            
            // Nous initialisons l'interface avant de configurer les permissions
            InitializeInterface();
            InitializeInterfaceHF();
            
            label1.Text = $"Fiche de frais du : {ficheFrais.DateCreationFicheFrais:dd/MM/yyyy}";
            LoadLignesFraisForfait();
            LoadLignesFraisHF();
        }

        // Ajoutez cette méthode pour initialiser l'utilisateur et configurer les permissions
        public void SetConnectedUser(User user)
        {
            connectedUser = user;
            ConfigurePermissions();
        }

        private void btnAddFraisForfait_Click(object sender, EventArgs e)
        {
            try
            {
                var NewLigneFraisForfaitForm = new NewLigneFraisForfaitForm(ficheFrais.IdFicheFrais);
                NewLigneFraisForfaitForm.ShowDialog();
                LoadLignesFraisForfait();
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
                var NewLigneFraisHFForm = new NewLigneFraisHFForm(ficheFrais.IdFicheFrais);
                NewLigneFraisHFForm.ShowDialog();
                LoadLignesFraisHF();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Une erreur est survenue : {ex.Message}",
                    "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
