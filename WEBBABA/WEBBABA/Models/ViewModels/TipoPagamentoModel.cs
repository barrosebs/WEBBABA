using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WEBBABA.Models.ViewModels
{
    public class TipoPagamentoModel
    {
        public int idTipoPagemento { get; set; }
        public string nomeTipoPagamento { get; set; }

        public virtual ICollection<RegistroModel> Registros { get; set; }

    }
}