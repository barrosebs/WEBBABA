using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WEBBABA.Models.ViewModels
{
    public class AtletaModel
    {
        [Key]
        public int idAtleta { get; set; }
        [DisplayName("Nome do Atleta")]
        public string nomeAtleta { get; set; }
        [DisplayName("Sobrenome do Atleta")]

        public string sobrenomeAtleta { get; set; }
        [DisplayName("Apelido do Atleta")]

        public string apelidoAtleta { get; set; }
        [DisplayName("Número do Colete")]

        public int? coleteNumeroAtleta { get; set; }
        [DisplayName("Data de Nascimento")]

        public DateTime? nascimentoAtleta { get; set; }
        [DisplayName("Situação do Atleta")]

        public int idSituacaoAtleta { get; set; }
        [DisplayName("Telefone do Atleta")]

        public string telefoneAtleta { get; set; }
        public DateTime dataCadastroAtleta { get; set; } = DateTime.Now;
        [DisplayName("Posição de campo")]

        public int? posicaoAtleta { get; set; }
        [DisplayName("O atleta é membro da Comissão?")]

        public int comissaoAtleta { get; set; }

        public virtual SituacaoModel Situacao { get; set; }
        public virtual ICollection<MensalidadeModel> Mensalidades { get; set; }
    }
}