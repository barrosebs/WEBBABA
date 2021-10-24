using BABA.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BABA.Persistence.Interface
{
    public interface IAtletaPersist 
    {
        Task<Atleta[]> GetAllAtletaByMensalidadeAsync(string nome, bool includeMensalidade= false);
        Task<Atleta[]> GetAllAtletaAsync();
        Task<Atleta> GetAtletaByIdAsync(int atletaId, bool includeMensalidade = false);
    }
}
