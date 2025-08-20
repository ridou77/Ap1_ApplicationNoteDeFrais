using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using GSB_demo.Models;
using GSB_GestionnairePatients.Controllers;

namespace GSB_demo.Views
{
    public partial class FraisForfaitForm : Form
    {
        public FraisForfaitForm()
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
               
                var NewLigneFraisForm = new NewLigneFraisForm();
                NewLigneFraisForm.ShowDialog();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Une erreur est survenue : {ex.Message}",
                    "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
