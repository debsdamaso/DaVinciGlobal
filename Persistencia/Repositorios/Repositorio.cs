using DaVinciGlobal.Persistencia.Repositorios.Interfaces;

using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace DaVinciGlobal.Persistencia.Repositorios
{
    public class Repositorio<T> : IRepositorio<T> where T : class
    {
        private readonly OracleFIAPDbContext _context;
        private readonly DbSet<T> _dbSet;

        public Repositorio(OracleFIAPDbContext context)
        {
            _context = context;
            _dbSet = _context.Set<T>();
        }

        public void Add(T entity)
        {
            _context.Add(entity);
            _context.SaveChanges();
        }

        public void Delete(T entity)
        {
            _context.Remove(entity);
            _context.SaveChanges();
        }

        public IEnumerable<T> GetAll()
        {
            return _dbSet.ToList();
        }

        public T GetById(int? id)
        {
            return _dbSet.Find(id);
        }

        public void Update(T entity)
        {
            _context.Update(entity);
            _context.SaveChanges();
        }
    }
}
