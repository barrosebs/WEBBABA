namespace BABA.Domain.Models
{
    public class Atleta
    {
        public int AtletaId { get; set; }
        public string Nome { get; set; }
        public string Apelido { get; set; }
        public int Camisa { get; set; }
        public int Posicao { get; set; }
        public bool Comissao { get; set; }
        public string WhatsApp { get; set; }
        public DateTime DataNascimento { get; set; }
        public DateTime DataCadastro { get; set; }
        public List<Mensalidade> Mensalidades { get; set; }
    }
}