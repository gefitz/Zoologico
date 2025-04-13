using Microsoft.EntityFrameworkCore;
using Zoologico.API.Context;
using Zoologico.API.Models;
using Zoologico.API.Repository.Interfaces;

namespace Zoologico.API.Repository
{
    public class AnimalRepository : IRepository<AnimalModel>
    {
        private readonly ZoologicoContext _context;
        private readonly LogModel _log;

        public AnimalRepository(ZoologicoContext context, LogModel log)
        {
            _context = context;
            _log = log;
        }

        public async Task<bool> Create(AnimalModel model)
        {
            try
            {
                _context.Animais.Add(model);
               await _context.SaveChangesAsync();
                return true;

            }catch (Exception ex)
            {
                _log.Mensagem = ex.Message;
                _log.Classe = "AnimalRepository";
                _log.Metodo = "Create";
                return false;
            }
        }

        public async Task<bool> Remove(AnimalModel model)
        {
            try
            {
                _context.Animais.Remove(model);
                await _context.SaveChangesAsync();
                return true;

            }
            catch (Exception ex)
            {
                _log.Mensagem = ex.Message;
                _log.Classe = "AnimalRepository";
                _log.Metodo = "Remove";
                return false;
            }
        }

        public async Task<IEnumerable<AnimalModel>> Search(AnimalModel model)
        {
            try
            {
                var query = _context.Animais
                    .Include(x => x.Cuidados)
                    .AsQueryable();

                if(!string.IsNullOrWhiteSpace(model.Nome))
                    query = query.Where(a => a.Nome.ToLower().Contains(model.Nome.ToLower()));

                if (!string.IsNullOrWhiteSpace(model.Especie))
                    query = query.Where(a => a.Especie.ToLower().Contains(model.Especie.ToLower()));

                if (!string.IsNullOrWhiteSpace(model.PaisOrigem))
                    query = query.Where(a => a.PaisOrigem.ToLower().Contains(model.PaisOrigem.ToLower()));
                var teste = await query.ToListAsync();

                return await query.ToListAsync();
            }catch(Exception ex)
            {
                _log.Mensagem = ex.Message;
                _log.Classe = "AnimalRepository";
                _log.Metodo = "Search";
                return null;
            }
        }

        public async Task<AnimalModel> SearchId(int id)
        {
            try
            {
                return await _context.Animais.Where(c => c.id == id).FirstOrDefaultAsync();
            }
            catch (Exception ex)
            {
                _log.Mensagem = ex.Message;
                _log.Classe = "AnimalRepository";
                _log.Metodo = "SearchId";
                return null;
            }
        }

        public async Task<bool> Update(AnimalModel model)
        {
            try
            {
                _context.Entry(model).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                await _context.SaveChangesAsync();
                return true;

            }
            catch (Exception ex)
            {
                _log.Mensagem = ex.Message;
                _log.Classe = "AnimalRepository";
                _log.Metodo = "Update";
                return false;
            }
        }
    }
}
