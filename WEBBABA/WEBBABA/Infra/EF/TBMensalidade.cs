//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace WEBBABA.Infra.EF
{
    using System;
    using System.Collections.Generic;
    
    public partial class TBMensalidade
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public TBMensalidade()
        {
            this.TBRegistro = new HashSet<TBRegistro>();
        }
    
        public int idMensalidade { get; set; }
        public int idAtletaMensalidade { get; set; }
        public int statusMensalidade { get; set; }
        public System.DateTime dataMensalidade { get; set; }
        public System.DateTime dataCadastroMensalidade { get; set; }
        public decimal valorMensalidade { get; set; }
    
        public virtual TBAtleta TBAtleta { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TBRegistro> TBRegistro { get; set; }
    }
}
