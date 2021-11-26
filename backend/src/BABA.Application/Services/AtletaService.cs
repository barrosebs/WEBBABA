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
                _allPersist.Add<AtletaDto>(model);
                if (await _allPersist.SaveChangesAsync())
                {
                    return await _atletaPersist.GetAtletaByIdAsync(model.AtletaId, false);
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

                _allPersist.Update(model);
                if (await _allPersist.SaveChangesAsync())
                {
                    return await _atletaPersist.GetAtletaByIdAsync(model.AtletaId, false);
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
                var condutor = await _atletaPersist.GetAllAtletaAsync(includeMensalidade);
                if (condutor == null) return null;

                return condutor;
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

                return atletas;
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

                return atleta;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
