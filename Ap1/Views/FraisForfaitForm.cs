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
        private FicheFrais ficheFrais;

        public FraisForfaitForm(FicheFrais fiche)
        {
            InitializeComponent();
            ficheFrais = fiche;
            label1.Text = $"Fiche de frais du : {ficheFrais.DateCreationFicheFrais:dd/MM/yyyy}";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                // Récupérer l'utilisateur connecté depuis le MainForm
                User connectedUser = ((MainForm)this.Owner).connectedUser;

                // Passer l'ID de la fiche de frais au constructeur de NewLigneFraisForm
                var NewLigneFraisForm = new NewLigneFraisForm(ficheFrais.IdFicheFrais);
                NewLigneFraisForm.ShowDialog();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Une erreur est survenue : {ex.Message}",
                    "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
