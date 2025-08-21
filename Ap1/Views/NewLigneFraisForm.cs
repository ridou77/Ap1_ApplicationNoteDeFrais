using GSB_demo.Controller;
using GSB_demo.Models;

namespace GSB_demo.Views
{
    public partial class NewLigneFraisForm : Form
    {
        private int idFicheFrais;

        public NewLigneFraisForm(int idFicheFrais)
        {
            InitializeComponent();
            this.idFicheFrais = idFicheFrais;
            ChargerTypesFrais();
        }

        private void ChargerTypesFrais()
        {
            var controller = new TypeFraisController();
            var typesFrais = controller.GetAllTypeFrais();

            listeFraisDefini.DataSource = typesFrais;
            listeFraisDefini.DisplayMember = "LibelleTypeFrais"; // Ce qui s'affiche
            listeFraisDefini.ValueMember = "IdTypeFrais";        // La valeur associée
        }

        private void btnAddLigneFrais_Click(object sender, EventArgs e)
        {
            if (listeFraisDefini.SelectedItem is TypeFrais selection)
            {
                int quantite = (int)choixNombreFrais.Value;
                int idTypeFrais = selection.IdTypeFrais;

                var controller = new LigneFraisController();
                bool success = controller.AddLigneFrais(idFicheFrais, idTypeFrais, quantite);

                if (success)
                {
                    MessageBox.Show("Ligne de frais ajoutée avec succès !", "Succès", MessageBoxButtons.OK, MessageBoxIcon.Information);

                }
                else
                {
                    MessageBox.Show("Erreur lors de l'ajout de la ligne de frais.", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Veuillez sélectionner un type de frais.", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void choixNombreFrais_ValueChanged(object sender, EventArgs e)
        {
            int quantite = (int)choixNombreFrais.Value;
        }
    }
}