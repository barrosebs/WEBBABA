using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BABA.Application.Dto
{
    public class ControleDto
    {
        public int ControleId { get; set; }
        public string Nome { get; set; }
        public bool ehAtleta { get; set; }
        public int CategoriaId { get; set; }
        public int Status { get; set; }
        // public Categoria Categoria { get; set; }
        public int MensalidadeId { get; set; }
        // public Mensalidade Mensalidade { get; set; }
    }
}