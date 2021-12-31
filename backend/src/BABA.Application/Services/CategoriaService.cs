using AutoMapper;
using BABA.Application.Dto;
using BABA.Application.Interface;
using BABA.Domain.Models;
using BABA.Persistence.Interface;
using System;
using System.Threading.Tasks;

namespace BABA.Application.Services
{
    public class CategoriaService : ICategoriaService
    {
        private readonly IAllPerssit _allPersist;
        private readonly ICategoriaPersist _categoriaPersist;
        private readonly IMapper _mapper;

        public CategoriaService(IAllPerssit allPersist, ICategoriaPersist categoriaPersist, IMapper mapper)
        {
            _allPersist = allPersist;
            _categoriaPersist = categoriaPersist;
            _mapper = mapper;
        }

        public async Task<CategoriaDto> AddCategoria(CategoriaDto model)
        {
            try
            {
                var categoria = _mapper.Map<Categoria>(model);
                _allPersist.Add<Categoria>(categoria);
                if (await _allPersist.SaveChangesAsync())
                {
                    var retorno = await _categoriaPersist.GetCategoriaByIdAsync(categoria.CategoriaId);
                    return _mapper.Map<CategoriaDto>(retorno);
                }
                return null;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public async Task<CategoriaDto> UpdateCategoria(int categoriaId, CategoriaDto model)
        {
            try
            {
                var categoria = await _categoriaPersist.GetCategoriaByIdAsync(categoriaId);

                if (categoria == null) return null;

                model.CategoriaId = categoriaId;

                _mapper.Map(model, categoria);

                _allPersist.Update<Categoria>(categoria);

                if (await _allPersist.SaveChangesAsync())
                {
                    var retorno = await _categoriaPersist.GetCategoriaByIdAsync(categoria.CategoriaId);
                    return _mapper.Map<CategoriaDto>(retorno);
                }
                return null;
            }

            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public async Task<bool> DeleteCategoria(int CategoriaId)
        {
            try
            {
                var categoria = await _categoriaPersist.GetCategoriaByIdAsync(CategoriaId);
                if (categoria == null) throw new Exception("Categoria não localizado");

                _allPersist.Delete<Categoria>(categoria);

                return await _allPersist.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<CategoriaDto[]> GetAllByAsync()
        {
            try
            {
                var categoria = await _categoriaPersist.GetAllCategoriaAsync();
                if (categoria == null) return null;
                var result = _mapper.Map<CategoriaDto[]>(categoria);

                return result;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<CategoriaDto[]> GetAllCategoriaByAsync()
        {
            try
            {
                var categorias = await _categoriaPersist.GetAllCategoriaAsync();
                if (categorias == null) return null;
                var result = _mapper.Map<CategoriaDto[]>(categorias);

                return result;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<CategoriaDto> GetCategoriaByIdAsync(int controleId)
        {
            try
            {
                var categoria = await _categoriaPersist.GetCategoriaByIdAsync(controleId);
                if (categoria == null) return null;
                var result = _mapper.Map<CategoriaDto>(categoria);

                return result;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
