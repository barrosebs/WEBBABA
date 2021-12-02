using AutoMapper;
using BABA.Application.Dto;
using BABA.Application.Interface;
using BABA.Domain.Models;
using BABA.Persistence.Interface;
using System;
using System.Threading.Tasks;

namespace BABA.Application.Services
{
    public class AtletaService : IAtletaService
    {
        private readonly IAllPerssit _allPersist;
        private readonly IAtletaPersist _atletaPersist;
        private readonly IMapper _mapper;

        public AtletaService(IAllPerssit allPersist, IAtletaPersist atletaPersist, IMapper mapper)
        {
            _allPersist = allPersist;
            _atletaPersist = atletaPersist;
            _mapper = mapper;
        }

        public async Task<AtletaDto> AddAtleta(AtletaDto model)
        {
            try
            {
                var atleta = _mapper.Map<Atleta>(model);
                _allPersist.Add<Atleta>(atleta);
                if (await _allPersist.SaveChangesAsync())
                {
                    var retorno = await _atletaPersist.GetAtletaByIdAsync(atleta.AtletaId, false);
                    return _mapper.Map<AtletaDto>(retorno);
                }
                return null;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public async Task<AtletaDto> UpdateAtleta(int atletaId, AtletaDto model)
        {
            try
            {
                var atleta = await _atletaPersist.GetAtletaByIdAsync(atletaId, false);

                if (atleta == null) return null;

                model.AtletaId = atletaId;

                _mapper.Map(model, atleta);

                _allPersist.Update<Atleta>(atleta);

                if (await _allPersist.SaveChangesAsync())
                {
                    var retorno = await _atletaPersist.GetAtletaByIdAsync(atleta.AtletaId, false);
                    return _mapper.Map<AtletaDto>(retorno);
                }
                return null;
            }

            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public async Task<bool> DeleteAtleta(int atletaId)
        {
            try
            {
                var atleta = await _atletaPersist.GetAtletaByIdAsync(atletaId, false);
                if (atleta == null) throw new Exception("Atleta não localizado");

                _allPersist.Delete<Atleta>(atleta);

                return await _allPersist.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<AtletaDto[]> GetAllAtletaAsync(bool includeMensalidade = false)
        {
            try
            {
                var atletas = await _atletaPersist.GetAllAtletaAsync(includeMensalidade);
                if (atletas == null) return null;
                var result = _mapper.Map<AtletaDto[]>(atletas);

                return result;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<AtletaDto[]> GetAllAtletaByMensalidadeAsync(string atletaNome, bool includeMensalidade = false)
        {
            try
            {
                var atletas = await _atletaPersist.GetAllAtletaByMensalidadeAsync(atletaNome, includeMensalidade);
                if (atletas == null) return null;
                var result = _mapper.Map<AtletaDto[]>(atletas);

                return result;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<AtletaDto> GetAtletaByIdAsync(int atletaId, bool includeMensalidade = false)
        {
            try
            {
                var atleta = await _atletaPersist.GetAtletaByIdAsync(atletaId, includeMensalidade);
                if (atleta == null) return null;
                var result = _mapper.Map<AtletaDto>(atleta);

                return result;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
