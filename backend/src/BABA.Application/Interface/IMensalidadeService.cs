using BABA.Application.Dto;
using BABA.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BABA.Application.Interface
{
    public interface IMensalidadeService
    {
        Task<MensalidadeDto> AddMensalidade(MensalidadeDto model);
        Task<MensalidadeDto> UpdateMensalidade(int atletaId, MensalidadeDto model);
        Task<bool> DeleteMensalidade(int controleId);

        Task<MensalidadeDto[]> GetAllMensalidadeByAtletaAsync(string condutor, bool includeAtleta = false);
        Task<MensalidadeDto[]> GetAllMensalidadeAsync(bool includeAtleta = false);
        Task<MensalidadeDto> GetMensalidadeByIdAsync(int controleId, bool includeAtleta = false);
    }
}
