using BABA.Domain.Models;
using System.Threading.Tasks;

namespace BABA.Persistence.Interface
{
    public interface IMensalidadePersist
    {
        Task<Mensalidade[]> GetAllMensalidadeByAtletaAsync(string nome, bool includeAtleta = false);
        Task<Mensalidade[]> GetAllMensalidadeAsync(bool includeMensalidade = false);
        Task<Mensalidade> GetMensalidadeByIdAsync(int mensalidadeId, bool includeAtleta = false);
    }
}
