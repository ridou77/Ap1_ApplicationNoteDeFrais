using GSB_demo.Utils;
using GSB_demo.Controllers;
using GSB_demo.Models;
using GSB_demo.Utils;

namespace GSB_demo.Views
{
    public partial class LoginForm : Form
    {
        private AuthController authController;

        public User ConnectedUser { get; private set; }

        public LoginForm()
        {
            InitializeComponent();
            authController = new AuthController();

            // Test de la connexion à la base de données au démarrage
            if (!DatabaseConnection.TestConnection())
            {
                MessageBox.Show("Impossible de se connecter à la base de données. Vérifiez la configuration.",
                    "Erreur de connexion", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtUsername.Text) || string.IsNullOrWhiteSpace(txtPassword.Text))
            {
                MessageBox.Show("Veuillez saisir un nom d'utilisateur et un mot de passe.",
                    "Champs requis", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var user = authController.AuthenticateUser(txtUsername.Text.Trim(), txtPassword.Text);

            if (user != null)
            {
                ConnectedUser = user;
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            else
            {
                MessageBox.Show("Nom d'utilisateur ou mot de passe incorrect.",
                    "Erreur d'authentification", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtPassword.Clear();
                txtUsername.Focus();
            }
        }

        private void btnQuit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void LoginForm_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnLogin_Click(sender, e);
            }
        }

        private void LoginForm_Load(object sender, EventArgs e)
        {

        }
    }
}