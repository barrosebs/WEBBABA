using System.Threading.Tasks;
using BABA.Domain.Models;

namespace BABA.Persistence.Interface
{
    public interface IAtletaPersist
    {
        Task<Atleta[]> GetAllAtletaByMensalidadeAsync(string nome, bool includeMensalidade = false);
        Task<Atleta[]> GetAllAtletaAsync(bool includeMensalidade = false);
        Task<Atleta> GetAtletaByIdAsync(int atletaId, bool includeMensalidade = false);
    }
}
