using DaVinciGlobal.Models;
using DaVinciGlobal.Persistencia.Repositorios.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace DaVinciGlobal.Persistencia.Repositorios
{
    public class DadoTemperaturaRepositorio : IDadoTemperaturaRepositorio
    {
        private readonly OracleFIAPDbContext _context;

        public DadoTemperaturaRepositorio(OracleFIAPDbContext context)
        {
            _context = context;
        }

        public void Add(DadoTemperatura dadoTemperatura)
        {
            _context.Add(dadoTemperatura);
            _context.SaveChanges();
        }

        public void Delete(DadoTemperatura dadoTemperatura)
        {
            _context.Remove(dadoTemperatura);
            _context.SaveChanges();
        }

        public IEnumerable<DadoTemperatura> GetAll()
        {
            return _context.DadosTemperatura.ToList();
        }

        public DadoTemperatura GetById(int? id)
        {
            return _context.DadosTemperatura.Find(id);
        }

        public void Update(DadoTemperatura dadoTemperatura)
        {
            _context.Update(dadoTemperatura);
            _context.SaveChangesAsync();
        }
    }
}
