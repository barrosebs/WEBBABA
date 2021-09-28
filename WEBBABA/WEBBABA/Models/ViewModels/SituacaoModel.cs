using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WEBBABA.Models.ViewModels
{
    public class SituacaoModel
    {

        public int idSituacao { get; set; }
        public string nomeSituacao { get; set; }
        public DateTime dataCastrodoSituacao { get; set; } = DateTime.Now;

        public virtual ICollection<AtletaModel> TBAtletas { get; set; }
    }
}