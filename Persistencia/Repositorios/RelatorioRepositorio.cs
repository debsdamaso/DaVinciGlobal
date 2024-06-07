using DaVinciGlobal.Models;
using DaVinciGlobal.Persistencia.Repositorios.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace DaVinciGlobal.Persistencia.Repositorios
{
    public class RelatorioRepositorio : IRelatorioRepositorio
    {
        private readonly OracleFIAPDbContext _context;

        public RelatorioRepositorio(OracleFIAPDbContext context)
        {
            _context = context;
        }

        public void Add(Relatorio relatorio)
        {
            _context.Add(relatorio);
            _context.SaveChanges();
        }

        public void Delete(Relatorio relatorio)
        {
            _context.Remove(relatorio);
            _context.SaveChanges();
        }

        public IEnumerable<Relatorio> GetAll()
        {
            return _context.Relatorios.ToList();
        }

        public Relatorio GetById(int? id)
        {
            return _context.Relatorios.Find(id);
        }

        public void Update(Relatorio relatorio)
        {
            _context.Update(relatorio);
            _context.SaveChangesAsync();
        }
    }
}
