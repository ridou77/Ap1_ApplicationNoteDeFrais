namespace GSB_demo.Models;
    public class LigneFraisForfait
    {
        public int IdLigneFraisForfait { get; set; }
        public int IdFicheFrais { get; set; }
        public int IdTypeFrais { get; set; }
        public int Quantite { get; set; }
        public string LibelleTypeFrais { get; set; }
    }