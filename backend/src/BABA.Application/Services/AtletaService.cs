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

        public AtletaService(IAllPerssit allPersist, IAtletaPersist atletaPersist)
        {
            _allPersist = allPersist;
            _atletaPersist = atletaPersist;
        }

        public async Task<Atleta> AddAtleta(Atleta model)
        {
            try
            {
                _allPersist.Add<Atleta>(model);
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
        public async Task<Atleta> UpdateAtleta(int atletaId, Atleta model)
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

        public async Task<Atleta[]> GetAllAtletaAsync(bool includeMensalidade = false)
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

        public async Task<Atleta[]> GetAllAtletaByMensalidadeAsync(string atletaNome, bool includeMensalidade = false)
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

        public async Task<Atleta> GetAtletaByIdAsync(int atletaId, bool includeMensalidade = false)
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
