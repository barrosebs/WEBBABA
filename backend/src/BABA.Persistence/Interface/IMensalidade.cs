using BABA.Domain.Models;
using System.Threading.Tasks;

namespace BABA.Persistence.Interface
{
    public interface IMensalidade
    {
        Task<Mensalidade[]> GetAllMensalidadeByAtletaAsync(string nome, bool includeAtleta = false);
        Task<Mensalidade[]> GetAllMensalidadeAsync();
        Task<Mensalidade> GetMensalidadeByIdAsync(int mensalidadeId, bool includeAtleta = false);
    }
}
