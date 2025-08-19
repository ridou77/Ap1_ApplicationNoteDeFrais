namespace GSB_demo.Models
{
    public class User
    {
        public int IdUser { get; set; }
        public int Role { get; set; }
        public string Nom { get; set; }
        public string Prenom { get; set; }
        public string Email { get; set; }
        public string Login { get; set; }
        public string Mdp { get; set; }
        public bool Actif { get; set; }
        public DateTime UserCreationDate { get; set; }

        public string NomComplet => $"{Prenom} {Nom}";
    }
}
