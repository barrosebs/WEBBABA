using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WEBBABA.Models.ViewModels
{
    public class CategoriaModel
    {
    [Key]
        public int idCategoria { get; set; }
        [DisplayName("Nome Da Categoria")]

        public string nomeCategoria { get; set; }
        [DisplayName("Data de Cadastro Categoria")]

        public DateTime dataCadastroCategoria { get; set; }

        public virtual ICollection<RegistroModel> Registros { get; set; }
    }
}