using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WEBBABA.Models.ViewModels
{
    public class RegistroModel
    {
        public int idRegistro { get; set; }
        public int idMensalidadeRegistro { get; set; }
        public string nomeCredorRegistro { get; set; }
        public int idNomeAtleta { get; set; }
        public DateTime dataCadastroRegistro { get; set; }
        public int idTipoPagamentoRegistro { get; set; }
        public int idCategoriaRegistro { get; set; }
        public string observacaoRegistro { get; set; }
        public DateTime dataPagamento { get; set; }
        public string valorPagamento { get; set; }
        public string valorDesconto { get; set; }
        public string valorSaldo { get; set; }

        public virtual CategoriaModel Categoria { get; set; }
        public virtual MensalidadeModel Mensalidade { get; set; }
        public virtual TipoPagamentoModel TipoPagamento { get; set; }
    }
}