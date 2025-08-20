using GSB_demo.Models;
using GSB_GestionnairePatients.Controllers;

namespace GSB_demo.Views
{
    public partial class MainForm : Form
    {
        private FicheFraisController FicheFraisController;
        public User connectedUser { get; private set; }
        private List<FicheFrais> allFicheFrais;

        public MainForm(User user)
        {
            InitializeComponent();
            connectedUser = user;
            FicheFraisController = new FicheFraisController();

            InitializeInterface();
            LoadFicheFrais();
        }

        private void InitializeInterface()
        {
            this.Text = "GSB - Gestionnaire de Fiches de Frais";
            this.WindowState = FormWindowState.Maximized;

            lblConnectedUser.Text = $"Connecté: {connectedUser.NomComplet} ({connectedUser.Role})";

            // Configuration du DataGridView
            dgvFicheFrais.AutoGenerateColumns = false;
            dgvFicheFrais.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvFicheFrais.MultiSelect = false;
            dgvFicheFrais.AllowUserToAddRows = false;
            dgvFicheFrais.AllowUserToDeleteRows = false;
            dgvFicheFrais.ReadOnly = true;

            // Colonnes du DataGridView
            dgvFicheFrais.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "IdFicheFrais",
                HeaderText = "ID",
                DataPropertyName = "IdFicheFrais",
                Width = 50
            });

            dgvFicheFrais.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "IdUser",
                HeaderText = "ID Utilisateur",
                DataPropertyName = "IdUser",
                Width = 100
            });

            // Afficher le nom de l'utilisateur dans la DAtaGridView
            dgvFicheFrais.Columns.Add(new DataGridViewTextBoxColumn
            {
                // ne s'affiche pas car il n'y a pas de propriété nom dans la classe FicheFrais
                Name = "NomUtilisateur",
                HeaderText = "Nom Utilisateur",
                DataPropertyName = "NomUtilisateur",
                Width = 100
            });

            dgvFicheFrais.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "Etat",
                HeaderText = "État",
                DataPropertyName = "Etat",
                Width = 120
            });

            dgvFicheFrais.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "DateCreationFicheFrais",
                HeaderText = "Date de création",
                DataPropertyName = "DateCreationFicheFrais",
                Width = 140,
                DefaultCellStyle = { Format = "dd/MM/yyyy" }
            });

            // Gestion des permissions selon le rôle
            ConfigurePermissions();
        }

        // donner tout les droits aux administrateurs
        // Comptable : droit de rechercher des fiches par utilisateurs + validation / refus des fiches
        // Visiteurs : Créer une fiche, ajouter une ligne de frais, ajouter justificatif à la fiche de frais
        private void ConfigurePermissions()
        {
            // 1 = Administrateur, 2 = Comptable, 3 = Visiteur
            switch (connectedUser.Role)
            {
                case 1: // Administrateur
                        // Tous les droits
                    btnAdd.Enabled = true;
                    btnEdit.Enabled = true;
                    btnDelete.Enabled = true;
                    break;
                case 2: // Comptable
                        // Droit de recherche et validation/refus, pas de suppression
                    btnAdd.Enabled = false;
                    btnEdit.Enabled = true;
                    btnDelete.Enabled = false;
                    break;
                case 3: // Visiteur
                        // Créer une fiche, ajouter une ligne, ajouter justificatif
                    btnAdd.Enabled = true;
                    btnEdit.Enabled = true;
                    btnDelete.Enabled = false;
                    break;
                default:
                    // Aucun droit
                    btnAdd.Enabled = false;
                    btnEdit.Enabled = false;
                    btnDelete.Enabled = false;
                    break;
            }
        }

        private void LoadFicheFrais()
        {
            try
            {
                allFicheFrais = FicheFraisController.GetAllFicheFrais();
                dgvFicheFrais.DataSource = allFicheFrais;

                // Mise à jour du titre avec le nombre de patients
                this.Text = $"GSB - Gestionnaire de Patients ({allFicheFrais.Count} patients)";
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erreur lors du chargement des patients: {ex.Message}",
                    "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            LoadFicheFrais();
            txtSearch.Clear();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtSearch.Text))
            {
                dgvFicheFrais.DataSource = allFicheFrais;
                return;
            }

            string searchTerm = txtSearch.Text.ToLower();
            var filteredFicheFrais = allFicheFrais.Where(p =>
                p.IdFicheFrais.ToString().Contains(searchTerm) ||
                p.Etat.ToString().ToLower().Contains(searchTerm)
            ).ToList();

            dgvFicheFrais.DataSource = filteredFicheFrais;
        }

        private void txtSearch_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnSearch_Click(sender, e);
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            var ChoixFraisForm = new ChoixFraisForm();
            ChoixFraisForm.Owner = this;
            ChoixFraisForm.ShowDialog();
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (dgvFicheFrais.SelectedRows.Count == 0)
            {
                MessageBox.Show("Veuillez sélectionner un patient à modifier.",
                    "Aucune sélection", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            MessageBox.Show("Fonctionnalité de modification en cours de développement",
                "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (dgvFicheFrais.SelectedRows.Count == 0)
            {
                MessageBox.Show("Veuillez sélectionner un patient à supprimer.",
                    "Aucune sélection", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            MessageBox.Show("Fonctionnalité de suppression en cours de développement",
                "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Êtes-vous sûr de vouloir vous déconnecter ?",
                "Déconnexion", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                this.Close();
            }
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Êtes-vous sûr de vouloir quitter l'application ?",
                "Quitter", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                Application.Exit();
            }
        }

        private void dgvFicheFrais_DoubleClick(object sender, EventArgs e)
        {
            if (dgvFicheFrais.SelectedRows.Count > 0)
            {
                var patient = (FicheFrais)dgvFicheFrais.SelectedRows[0].DataBoundItem;
               
            }
        }
    }
}