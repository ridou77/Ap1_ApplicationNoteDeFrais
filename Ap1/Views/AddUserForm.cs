using GSB_demo.Manager;
using GSB_demo.Models;

namespace GSB_demo.Views
{
    public partial class AddUserForm : Form
    {
        public AddUserForm()
        {
            InitializeComponent();
            InitializeRoleComboBox();
            
            btn_CreateUser.Click += btn_CreateUser_Click;
        }

        private void InitializeRoleComboBox()
        {
            comboBox_SelectUserRole.DataSource = Enum.GetValues(typeof(User.RoleUser));
            comboBox_SelectUserRole.DropDownStyle = ComboBoxStyle.DropDownList;
        }

        private void btn_CreateUser_Click(object sender, EventArgs e)
        {
            try
            {
                string nom = txtBox_UserName.Text.Trim();
                string prenom = txtBox_FirstName.Text.Trim();
                string email = txtBox_Email.Text.Trim();
                string login = txt_BoxIdConnect.Text.Trim();
                string motDePasse = txtBox_MdpUser.Text.Trim();
                
                if (comboBox_SelectUserRole.SelectedItem == null)
                {
                    MessageBox.Show("Veuillez sélectionner un rôle pour l'utilisateur.", 
                        "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // Récupérer le rôle sélectionné
                User.RoleUser role = (User.RoleUser)comboBox_SelectUserRole.SelectedItem;

                if (string.IsNullOrEmpty(nom) || string.IsNullOrEmpty(prenom) ||
                    string.IsNullOrEmpty(email) || string.IsNullOrEmpty(login) || 
                    string.IsNullOrEmpty(motDePasse))
                {
                    MessageBox.Show("Veuillez remplir tous les champs.", 
                        "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // Créer l'objet utilisateur
                var nouvelUtilisateur = new User
                {
                    Nom = nom,
                    Prenom = prenom,
                    Email = email,
                    Login = login,
                    Mdp = motDePasse,
                    Role = role,
                    Actif = true,
                    UserCreationDate = DateTime.Now
                };

                var userManager = new AddUserManager();
                bool success = userManager.AddUser(nouvelUtilisateur);

                if (success)
                {
                    MessageBox.Show("Utilisateur ajouté avec succès.", 
                        "Succès", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Erreur lors de l'ajout de l'utilisateur.", 
                        "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Une erreur est survenue : {ex.Message}", 
                    "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }
    }
}
