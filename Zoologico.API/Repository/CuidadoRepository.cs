using Microsoft.EntityFrameworkCore;
using Zoologico.API.Context;
using Zoologico.API.Models;
using Zoologico.API.Repository.Interfaces;

namespace Zoologico.API.Repository
{
    public class CuidadoRepository : IRepository<CuidadoModel>
    {
        private readonly ZoologicoContext _context;
        private readonly LogModel _log;

        public CuidadoRepository(ZoologicoContext context, LogModel log)
        {
            _context = context;
            _log = log;
        }

        public async Task<bool> Create(CuidadoModel model)
        {
            try
            {
                _context.Cuidados.Add(model);
                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                _log.Mensagem = ex.Message;
                _log.Classe = "CuidadoReposiroy";
                _log.Metodo = "Create";
                return false;
            }
        }

        public async Task<bool> Remove(CuidadoModel model)
        {
            try
            {
                _context.Cuidados.Remove(model);
                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                _log.Mensagem = ex.Message;
                _log.Classe = "CuidadoReposiroy";
                _log.Metodo = "Remove";
                return false;
            }
        }

        public async Task<IEnumerable<CuidadoModel>> Search(CuidadoModel model)
        {
            try
            {
                var query = _context.Cuidados.Include(a => a.Animais).AsQueryable();
                if (!string.IsNullOrWhiteSpace(model.NomeCuidado))
                {
                    query = query.Where(c => c.NomeCuidado.ToLower().Contains(model.NomeCuidado.ToLower()));
                }
                return await query.ToListAsync();
            }
            catch (Exception ex)
            {
                _log.Mensagem = ex.Message;
                _log.Classe = "CuidadoRepository";
                _log.Metodo = "Search";
                return null;
            }
        }

        public async Task<bool> Update(CuidadoModel model)
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
                _log.Classe = "CuidadoReposiroy";
                _log.Metodo = "Update";
                return false;
            }
        }

        public async Task<CuidadoModel> SearchId(int id)
        {
            try
            {
                return await _context.Cuidados.Where(c => c.id == id).FirstOrDefaultAsync();
            }catch (Exception ex)
            {
                _log.Mensagem = ex.Message;
                _log.Classe = "CuidadoRepository";
                _log.Metodo = "SearchId";
                return null;
            }
        }
    }
}
