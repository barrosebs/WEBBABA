using BABA.Application.Dto;
using System.Threading.Tasks;

namespace BABA.Application.Interface
{
    public interface IAtletaService
    {
        Task<AtletaDto> AddAtleta(AtletaDto model);
        Task<AtletaDto> UpdateAtleta(int atletaId, AtletaDto model);
        Task<bool> DeleteAtleta(int atletaId);

        Task<AtletaDto[]> GetAllAtletaByMensalidadeAsync(string condutor, bool includeMensalidade = false);
        Task<AtletaDto[]> GetAllAtletaAsync(bool includeAtleta = false);
        Task<AtletaDto> GetAtletaByIdAsync(int atletaId, bool includeMensalidade = false);
    }
}
