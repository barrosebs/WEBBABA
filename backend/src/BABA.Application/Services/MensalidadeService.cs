using AutoMapper;
using BABA.Application.Dto;
using BABA.Application.Interface;
using BABA.Domain.Models;
using BABA.Persistence.Interface;
using System;
using System.Threading.Tasks;

namespace BABA.Application.Services
{
    public class MensalidadeService : IMensalidadeService
    {
        private readonly IAllPerssit _allPersist;
        private readonly IMensalidadePersist _mensalidadePersist;
        private readonly IMapper _mapper;

        public MensalidadeService(IAllPerssit allPersist, IMensalidadePersist mensalidadePersist, IMapper mapper)
        {
            _allPersist = allPersist;
            _mensalidadePersist = mensalidadePersist;
            _mapper = mapper;
        }

        public async Task<MensalidadeDto> AddMensalidade(MensalidadeDto model)
        {
            try
            {
                var mensalidade = _mapper.Map<Mensalidade>(model);
                _allPersist.Add<Mensalidade>(mensalidade);
                if (await _allPersist.SaveChangesAsync())
                {
                    var retorno = await _mensalidadePersist.GetMensalidadeByIdAsync(mensalidade.MensalidadeId, false);
                    return _mapper.Map<MensalidadeDto>(retorno);
                }
                return null;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public async Task<MensalidadeDto> UpdateMensalidade(int mensalidadeId, MensalidadeDto model)
        {
            try
            {
                var mensalidade = await _mensalidadePersist.GetMensalidadeByIdAsync(mensalidadeId, false);

                if (mensalidade == null) return null;

                model.MensalidadeId = mensalidadeId;

                _mapper.Map(model, mensalidade);

                _allPersist.Update<Mensalidade>(mensalidade);

                if (await _allPersist.SaveChangesAsync())
                {
                    var retorno = await _mensalidadePersist.GetMensalidadeByIdAsync(mensalidade.MensalidadeId, false);
                    return _mapper.Map<MensalidadeDto>(retorno);
                }
                return null;
            }

            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public async Task<bool> DeleteMensalidade(int mensalidadeId)
        {
            try
            {
                var mensalidade = await _mensalidadePersist.GetMensalidadeByIdAsync(mensalidadeId, false);
                if (mensalidade == null) throw new Exception("Mensalidade não localizado");

                _allPersist.Delete<Mensalidade>(mensalidade);

                return await _allPersist.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<MensalidadeDto[]> GetAllMensalidadeAsync(bool includeAtleta = false)
        {
            try
            {
                var mensalidades = await _mensalidadePersist.GetAllMensalidadeAsync(includeAtleta);
                if (mensalidades == null) return null;
                var result = _mapper.Map<MensalidadeDto[]>(mensalidades);

                return result;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<MensalidadeDto[]> GetAllMensalidadeByAtletaAsync(string mensalidadeNome, bool includeAtleta = false)
        {
            try
            {
                var mensalidades = await _mensalidadePersist.GetAllMensalidadeByAtletaAsync(mensalidadeNome, includeAtleta);
                if (mensalidades == null) return null;
                var result = _mapper.Map<MensalidadeDto[]>(mensalidades);

                return result;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<MensalidadeDto> GetMensalidadeByIdAsync(int mensalidadeId, bool includeMensalidade = false)
        {
            try
            {
                var mensalidade = await _mensalidadePersist.GetMensalidadeByIdAsync(mensalidadeId, includeMensalidade);
                if (mensalidade == null) return null;
                var result = _mapper.Map<MensalidadeDto>(mensalidade);

                return result;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
