using System.Collections.Generic;

namespace BABA.Application.Dto
{
    public class MensalidadeDto
    {
        public int MensalidadeId { get; set; }
        public string Vencimento { get; set; }
        public decimal ValorPrincipal { get; set; }
        public decimal ValorPagamento { get; set; }
        public decimal ValorDesconto { get; set; }
        public decimal ValorSaldo { get; set; }
        public string DataPagamento { get; set; }
        public bool EhQuitada { get; set; }
        public int AtletaId { get; set; }
        public AtletaDto Atleta { get; set; }
        public List<ControleDto> Controles { get; set; }
    }
}