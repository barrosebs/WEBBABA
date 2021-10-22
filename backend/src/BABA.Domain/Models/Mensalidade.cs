namespace BABA.Domain.Models
{
    public class Mensalidade
    {
        public int MensalidadeId { get; set; }
        public DateTime Vencimento { get; set; }
        public DateTime DataCadastro { get; set; }
        public decimal ValorPrincipal { get; set; }
        public decimal ValorPagamento { get; set; }
        public decimal ValorDesconto { get; set; }
        public decimal ValorSaldo { get; set; }
        public DateTime DataPagamento { get; set; }
        public bool EhQuitada { get; set; }
        public int AtletaId { get; set; }
        public Atleta Atleta { get; set; }
        public List<Controle> Controles { get; set; }
    }
}