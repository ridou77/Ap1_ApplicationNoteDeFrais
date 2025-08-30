using GSB_demo.Manager;
using GSB_demo.Models;

namespace GSB_demo.Views
{
    public partial class NewLigneFraisForfaitForm : Form
    {
        private int idFicheFrais;

        public NewLigneFraisForfaitForm(int idFicheFrais)
        {
            InitializeComponent();
            this.idFicheFrais = idFicheFrais;
            ChargerTypesFrais();
        }

        private void ChargerTypesFrais()
        {
            var controller = new TypeFraisManager();
            var typesFrais = controller.GetAllTypeFrais();

            listeFraisDefini.DataSource = typesFrais;
            listeFraisDefini.DisplayMember = "LibelleTypeFrais";
            listeFraisDefini.ValueMember = "IdTypeFrais";
        }

        private void btnAddLigneFrais_Click(object sender, EventArgs e)
        {
            if (listeFraisDefini.SelectedItem is TypeFrais selection)
            {
                int quantite = (int)choixNombreFrais.Value;
                int idTypeFrais = selection.IdTypeFrais;

                var manager = new LigneFraisManager();
                bool success = manager.AddLigneFraisForfait(idFicheFrais, idTypeFrais, quantite);


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
            else
            {
                MessageBox.Show("Veuillez sélectionner un type de frais.", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
    }
}