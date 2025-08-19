using GSB_demo.Views;

namespace GSB_demo
{
    internal static class Program
    {
        [STAThread]
        static void Main()
        {
            ApplicationConfiguration.Initialize();

            // Afficher le formulaire de connexion
            using (var loginForm = new LoginForm())
            {
                if (loginForm.ShowDialog() == DialogResult.OK)
                {
                    // Si la connexion réussit, ouvrir le formulaire principal
                    Application.Run(new MainForm(loginForm.ConnectedUser));
                }
            }
        }
    }
}