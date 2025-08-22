using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using GSB_demo.Controller;
using GSB_demo.Models;
using GSB_GestionnairePatients.Controllers;

namespace GSB_demo.Views
{
    public partial class FraisForfaitForm : Form
    {
        private FicheFrais ficheFrais;
        private LigneFraisController ligneFraisController = new LigneFraisController();
        private TypeFraisController typeFraisController = new TypeFraisController();

        private void LoadLignesFraisForfait()
        {
            var lignes = ligneFraisController.GetAllLignesFraisForfait(ficheFrais.IdFicheFrais);
            LigneFraisForfaitDG.DataSource = lignes;
            
            // Calculer le prix total
            CalculerEtAfficherPrixTotal();
        }
        
        private void CalculerEtAfficherPrixTotal()
        {
            try
            {
                // Récupérer tous les types de frais pour avoir accès aux tarifs
                var typesFrais = typeFraisController.GetAllTypeFrais();
                
                // Récupérer les lignes de frais forfait
                var lignes = ligneFraisController.GetAllLignesFraisForfait(ficheFrais.IdFicheFrais);
                
                // Calculer le montant total
                decimal prixTotal = 0;
                
                foreach (var ligne in lignes)
                {
                    // Trouver le type de frais correspondant
                    var typeFrais = typesFrais.FirstOrDefault(tf => tf.IdTypeFrais == ligne.IdTypeFrais);
                    
                    if (typeFrais != null)
                    {
                        // Calculer le montant pour cette ligne (quantité × tarif)
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

        public FraisForfaitForm(FicheFrais fiche)
        {
            InitializeComponent();
            InitializeInterface();
            ficheFrais = fiche;
            label1.Text = $"Fiche de frais du : {ficheFrais.DateCreationFicheFrais:dd/MM/yyyy}";
            LoadLignesFraisForfait();
        }

        private void btnAddFraisForfait_Click(object sender, EventArgs e)
        {
            try
            {
                // Récupérer l'utilisateur connecté depuis le MainForm
                User connectedUser = ((MainForm)this.Owner).connectedUser;

                var NewLigneFraisForm = new NewLigneFraisForm(ficheFrais.IdFicheFrais);
                NewLigneFraisForm.ShowDialog();
                LoadLignesFraisForfait(); // Recharge la DataGridView après fermeture
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Une erreur est survenue : {ex.Message}",
                    "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
