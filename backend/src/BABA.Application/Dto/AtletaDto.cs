using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace BABA.Application.Dto
{
    public class AtletaDto
    {
        public int AtletaId { get; set; }
        [MinLength(10, ErrorMessage = "Campo {0} é obirgatório mínimo de 3")]
        [Required(ErrorMessage = "Campo {0} é obrigatório")]
        public string Nome { get; set; }
        public string Apelido { get; set; }
        [Required(ErrorMessage = "Campo {0} é obrigatório")]
        public int Camisa { get; set; }
        public int Posicao { get; set; }
        public bool Comissao { get; set; }
        [Required(ErrorMessage = "Campo {0} é obrigatório")]
        public string WhatsApp { get; set; }
        [Required(ErrorMessage = "Campo {0} é obrigatório")]
        public DateTime DataNascimento { get; set; }
        public virtual string imageUrl { get; set; }
        public List<MensalidadeDto> Mensalidades { get; set; }
    }
}