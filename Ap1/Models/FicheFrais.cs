namespace GSB_demo.Models
{
    public class FicheFrais
    {
        public int IdFicheFrais { get; set; }
        public int IdUser { get; set; }
        public string? NomUtilisateur { get; set; }
        public int? IdComptable { get; set; }
        public enum EtatFicheFrais
        {
            EN_COURS,
            EN_ATTENTE,
            VALIDEE,
            REFUSEE,
            REFUS_PARTIEL,
        }
  
        public EtatFicheFrais Etat { get; set; }
        public DateTime DateCreationFicheFrais { get; set; }
        public DateTime DateValidationFicheFrais { get; set; }
        public DateTime DateModificationFicheFrais { get; set; }
        public DateTime DateClotureFicheFrais { get; set; }
        public string? MotifRefusFicheFrais { get; set; }


    }
}
