using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WEBBABA.Models.ViewModels
{
    public class MensalidadeModel
    { 
        public int idMensalidade { get; set; }
        public int idAtletaMensalidade { get; set; }
        public int statusMensalidade { get; set; }
        public DateTime dataMensalidade { get; set; }
        public DateTime dataCadastroMensalidade { get; set; } = DateTime.Now;
        public decimal valorMensalidade { get; set; }

        public virtual AtletaModel Atleta { get; set; }
        public virtual ICollection<TBRegistro> TBRegistroes { get; set; }
    }
}