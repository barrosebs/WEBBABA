using System;
using System.Collections.Generic;

namespace BABA.Application.Dto
{
    public class AtletaDto
    {
        public int AtletaId { get; set; }
        public string Nome { get; set; }
        public string Apelido { get; set; }
        public int Camisa { get; set; }
        public int Posicao { get; set; }
        public bool Comissao { get; set; }
        public string WhatsApp { get; set; }
        public DateTime DataNascimento { get; set; }
        public virtual string imageUrl { get; set; }
        // public List<Mensalidade> Mensalidades { get; set; }
    }
}