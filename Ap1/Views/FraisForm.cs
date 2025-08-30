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

            CalcAndPrintPrixTotalFF();
        }

        private void LoadLignesFraisHF()
        {
            var lignes = ligneFraisManager.GetAllLignesFraisHF(ficheFrais.IdFicheFrais);
            ligneFraisHFDG.DataSource = lignes;

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
                var typesFrais = typeFraisManager.GetAllTypeFrais();

                var lignes = ligneFraisManager.GetAllLignesFraisForfait(ficheFrais.IdFicheFrais);

                decimal prixTotal = 0;

                foreach (var ligne in lignes)
                {
                    var typeFrais = typesFrais.FirstOrDefault(tf => tf.IdTypeFrais == ligne.IdTypeFrais);

                    if (typeFrais != null)
                    {
                        //quantité × tarif)
                        decimal montantLigne = ligne.Quantite * typeFrais.TarifTypeFrais;
                        prixTotal += montantLigne;
                    }
                }

                // Afficher le prix total dans le label( a reutiliser)
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
                   prixTotal += ligne.MontantFraisHF;
                }

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
                Name = "StatusFraisFF",
                HeaderText = "Statut",
                DataPropertyName = "StatusFraisFF",
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

            InitializeInterface();
            InitializeInterfaceHF();

            label1.Text = $"Fiche de frais du : {ficheFrais.DateCreationFicheFrais:dd/MM/yyyy}";
            LoadLignesFraisForfait();
            LoadLignesFraisHF();
        }

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

        private void btn_deleteFF_Click(object sender, EventArgs e)
        {
            try
            {
                List<LigneFraisForfait> lignesASupprimer = new List<LigneFraisForfait>();

                for (int i = 0; i < LigneFraisForfaitDG.Rows.Count; i++)
                {
                    if (LigneFraisForfaitDG.Rows[i].Cells["Selectionner"].Value != null &&
                        (bool)LigneFraisForfaitDG.Rows[i].Cells["Selectionner"].Value == true)
                    {
                        var ligne = (LigneFraisForfait)LigneFraisForfaitDG.Rows[i].DataBoundItem;
                        lignesASupprimer.Add(ligne);
                    }
                }

                if (lignesASupprimer.Count == 0)
                {
                    MessageBox.Show("Veuillez cocher au moins une ligne à supprimer.",
                        "Aucune sélection", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (MessageBox.Show($"Êtes-vous sûr de vouloir supprimer {lignesASupprimer.Count} ligne(s) de frais ?",
                    "Confirmation de suppression", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    int nbSupprimees = 0;

                    foreach (var ligne in lignesASupprimer)
                    {
                        if (ligneFraisManager.DeleteLigneFraisForfait(ligne.IdLigneFraisForfait))
                        {
                            nbSupprimees++;
                        }
                    }

                    MessageBox.Show($"{nbSupprimees} ligne(s) de frais supprimée(s) avec succès.",
                        "Suppression", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    LoadLignesFraisForfait();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Une erreur est survenue : {ex.Message}",
                    "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btn_UpdateFF_Click(object sender, EventArgs e)
        {
            try
            {
                int lignesSelectionnees = 0;
                LigneFraisForfait ligneAModifier = null;
                int indexLigne = -1;

                for (int i = 0; i < LigneFraisForfaitDG.Rows.Count; i++)
                {
                    if (LigneFraisForfaitDG.Rows[i].Cells["Selectionner"].Value != null &&
                        (bool)LigneFraisForfaitDG.Rows[i].Cells["Selectionner"].Value == true)
                    {
                        lignesSelectionnees++;
                        indexLigne = i;
                        ligneAModifier = (LigneFraisForfait)LigneFraisForfaitDG.Rows[i].DataBoundItem;
                    }
                }

                if (lignesSelectionnees == 0)
                {
                    MessageBox.Show("Veuillez sélectionner une ligne à modifier.",
                        "Aucune sélection", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                else if (lignesSelectionnees > 1)
                {
                    MessageBox.Show("Veuillez sélectionner une seule ligne à modifier.",
                        "Plusieurs sélections", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                var modificationForm = new UpdateLigneFFForm(ligneAModifier);
                if (modificationForm.ShowDialog() == DialogResult.OK)
                {
                    LoadLignesFraisForfait();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Une erreur est survenue : {ex.Message}",
                    "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btn_DeleteHF_Click(object sender, EventArgs e)
        {
            try
            {
                List<LigneFraisHF> lignesASupprimer = new List<LigneFraisHF>();

                for (int i = 0; i < ligneFraisHFDG.Rows.Count; i++)
                {
                    if (ligneFraisHFDG.Rows[i].Cells["Selectionner"].Value != null &&
                        (bool)ligneFraisHFDG.Rows[i].Cells["Selectionner"].Value == true)
                    {
                        var ligne = (LigneFraisHF)ligneFraisHFDG.Rows[i].DataBoundItem;
                        lignesASupprimer.Add(ligne);
                    }
                }

                if (lignesASupprimer.Count == 0)
                {
                    MessageBox.Show("Veuillez cocher au moins une ligne à supprimer.",
                        "Aucune sélection", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (MessageBox.Show($"Êtes-vous sûr de vouloir supprimer {lignesASupprimer.Count} ligne(s) de frais hors forfait ?",
                    "Confirmation de suppression", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    int nbSupprimees = 0;

                    foreach (var ligne in lignesASupprimer)
                    {
                        if (ligneFraisManager.DeleteLigneFraisHF(ligne.IdLigneFraisHF))
                        {
                            nbSupprimees++;
                        }
                    }

                    MessageBox.Show($"{nbSupprimees} ligne(s) de frais hors forfait supprimée(s) avec succès.",
                        "Suppression", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    LoadLignesFraisHF();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Une erreur est survenue : {ex.Message}",
                    "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btn_UpdateHF_Click(object sender, EventArgs e)
        {
            try
            {
                int lignesSelectionnees = 0;
                LigneFraisHF ligneAModifier = null;
                int indexLigne = -1;

                for (int i = 0; i < ligneFraisHFDG.Rows.Count; i++)
                {
                    if (ligneFraisHFDG.Rows[i].Cells["Selectionner"].Value != null &&
                        (bool)ligneFraisHFDG.Rows[i].Cells["Selectionner"].Value == true)
                    {
                        lignesSelectionnees++;
                        indexLigne = i;
                        ligneAModifier = (LigneFraisHF)ligneFraisHFDG.Rows[i].DataBoundItem;
                    }
                }

                if (lignesSelectionnees == 0)
                {
                    MessageBox.Show("Veuillez sélectionner une ligne à modifier.",
                        "Aucune sélection", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                else if (lignesSelectionnees > 1)
                {
                    MessageBox.Show("Veuillez sélectionner une seule ligne à modifier.",
                        "Plusieurs sélections", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                var modificationForm = new UpdateLigneHFForm(ligneAModifier);
                if (modificationForm.ShowDialog() == DialogResult.OK)
                {
                    LoadLignesFraisHF();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Une erreur est survenue : {ex.Message}",
                    "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
