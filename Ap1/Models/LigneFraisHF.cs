
namespace GSB_demo.Models;
    public class LigneFraisHF
    {
        public int IdLigneFraisHF { get; set; }
        public int IdFiche { get; set; }
        public string LibelleFraisHF { get; set; }
        public DateTime DateDepenseFraisHF { get; set; }
        public decimal MontantFraisHF { get; set; }
    public enum StatusFraishf
    {
        EN_ATTENTE,
        ACCEPTE,
        REFUSE
    }
    public StatusFraishf? StatusFraisHF { get; set; }
    public string? MotifRefusFraisHF { get; set; }
    }

