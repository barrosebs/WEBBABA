using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace BABA.Application.Dto
{
    public class AtletaDto
    {
        public int AtletaId { get; set; }
        [Display(Name = "Nome do Atleta")]
        [MinLength(10, ErrorMessage = "Campo {0} é obirgatório mínimo de 10")]
        [Required(ErrorMessage = "Campo {0} é obrigatório")]
        public string Nome { get; set; }
        public string Apelido { get; set; }
        [Required(ErrorMessage = "Campo {0} é obrigatório")]
        public int Camisa { get; set; }
        [Display(Name = "Posição do Atleta")]
        public int Posicao { get; set; }
        public bool Comissao { get; set; }
        [Required(ErrorMessage = "Campo {0} é obrigatório")]
        public string WhatsApp { get; set; }
        [Display(Name = "Data de Nascimento")]
        [Required(ErrorMessage = "Campo {0} é obrigatório")]
        public DateTime DataNascimento { get; set; }
        [Display(Name = "Foto do Atleta")]
        [RegularExpression(@".*\.(jpe?g|bmp|png)$",
                            ErrorMessage = "Formato não permiti!")]
        public virtual string imageUrl { get; set; }
        public List<MensalidadeDto> Mensalidades { get; set; }
    }
}