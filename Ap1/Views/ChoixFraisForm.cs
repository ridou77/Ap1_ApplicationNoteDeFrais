using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Text;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using GSB_demo.Models;
using GSB_GestionnairePatients.Controllers;

namespace GSB_demo.Views
{
    public partial class ChoixFraisForm : Form
    {
        public ChoixFraisForm()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                // Récupérer l'utilisateur connecté depuis le MainForm
                User connectedUser = ((MainForm)this.Owner).connectedUser;

                // Créer l'objet FicheFrais
                var nouvelleFiche = new FicheFrais
                {
                    IdUser = connectedUser.IdUser,
                    IdComptable = null,
                    Etat = FicheFrais.EtatFicheFrais.EN_COURS,
                    DateCreationFicheFrais = DateTime.Now,
                    DateValidationFicheFrais = DateTime.MinValue,
                    DateModificationFicheFrais = DateTime.MinValue,
                    DateClotureFicheFrais = DateTime.MinValue,
                    MotifRefusFicheFrais = ""
                };

                var controller = new FicheFraisController();

                if (controller.AddFicheFrais(nouvelleFiche))
                {
                    var fraisForfaitForm = new NewFicheFraisForm();
                    fraisForfaitForm.ShowDialog();

                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Échec lors de la création de la fiche de frais",
                        "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
