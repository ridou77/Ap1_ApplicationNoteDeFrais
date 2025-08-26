using System;
using GSB_demo.Manager;
using GSB_demo.Models;
using static GSB_demo.Models.LigneFraisHF;

namespace GSB_demo.Views
{
    public partial class NewLigneFraisHFForm : Form
    {
        private int idFicheFrais;
        
        public NewLigneFraisHFForm(int idFicheFrais)
        {
            InitializeComponent();
            this.idFicheFrais = idFicheFrais;

            // Add the control to the form
            this.Controls.Add(dtp_NewLigneFraisHF);
        }

        private void Btn_AddLigneFraisHF_Click(object sender, EventArgs e)
        {
            // Ajouter ma logique qui utilise ma fonction AddLigneFraisHF
            var manager = new LigneFraisManager();

            string libelle = NameLigneFraisHFTxtBox.Text;
            DateTime dateDepense = dtp_NewLigneFraisHF.Value;
            decimal montant = PriceNumericUpDown.Value;

            bool success = manager.AddLigneFraisHF(idFicheFrais, libelle, dateDepense, montant, null, null );

            if (success)
            {
                MessageBox.Show("Ligne de frais ajoutée avec succès !", "Succès", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close(); // Ferme le formulaire d'ajout
            }
            else
            {
                MessageBox.Show("Erreur lors de l'ajout de la ligne de frais.", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
