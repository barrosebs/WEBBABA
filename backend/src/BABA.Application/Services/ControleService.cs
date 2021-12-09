using AutoMapper;
using BABA.Application.Dto;
using BABA.Application.Interface;
using BABA.Domain.Models;
using BABA.Persistence.Interface;
using System;
using System.Threading.Tasks;

namespace BABA.Application.Services
{
    public class ControleService : IControleService
    {
        private readonly IAllPerssit _allPersist;
        private readonly IControlePersist _controlePersist;
        private readonly IMapper _mapper;

        public ControleService(IAllPerssit allPersist, IControlePersist controlePersist, IMapper mapper)
        {
            _allPersist = allPersist;
            _controlePersist = controlePersist;
            _mapper = mapper;
        }

        public async Task<ControleDto> AddControle(ControleDto model)
        {
            try
            {
                var controle = _mapper.Map<Controle>(model);
                _allPersist.Add<Controle>(controle);
                if (await _allPersist.SaveChangesAsync())
                {
                    var retorno = await _controlePersist.GetControleByIdAsync(controle.ControleId, false);
                    return _mapper.Map<ControleDto>(retorno);
                }
                return null;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public async Task<ControleDto> UpdateControle(int controleId, ControleDto model)
        {
            try
            {
                var controle = await _controlePersist.GetControleByIdAsync(controleId, false);

                if (controle == null) return null;

                model.ControleId = controleId;

                _mapper.Map(model, controle);

                _allPersist.Update<Controle>(controle);

                if (await _allPersist.SaveChangesAsync())
                {
                    var retorno = await _controlePersist.GetControleByIdAsync(controle.ControleId, false);
                    return _mapper.Map<ControleDto>(retorno);
                }
                return null;
            }

            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public async Task<bool> DeleteControle(int controleId)
        {
            try
            {
                var controle = await _controlePersist.GetControleByIdAsync(controleId, false);
                if (controle == null) throw new Exception("Controle não localizado");

                _allPersist.Delete<Controle>(controle);

                return await _allPersist.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<ControleDto[]> GetAllControleAsync(bool includeAtleta = false)
        {
            try
            {
                var controles = await _controlePersist.GetAllControleAsync(includeAtleta);
                if (controles == null) return null;
                var result = _mapper.Map<ControleDto[]>(controles);

                return result;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<ControleDto[]> GetAllControleByAtletaAsync(string controleNome, bool includeAtleta = false)
        {
            try
            {
                var controles = await _controlePersist.GetAllControleByAtletaAsync(controleNome, includeAtleta);
                if (controles == null) return null;
                var result = _mapper.Map<ControleDto[]>(controles);

                return result;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<ControleDto> GetControleByIdAsync(int controleId, bool includeControle = false)
        {
            try
            {
                var controle = await _controlePersist.GetControleByIdAsync(controleId, includeControle);
                if (controle == null) return null;
                var result = _mapper.Map<ControleDto>(controle);

                return result;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
