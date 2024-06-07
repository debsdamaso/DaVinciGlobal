using DaVinciGlobal.Models;
using DaVinciGlobal.Persistencia.Repositorios.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace DaVinciGlobal.Persistencia.Repositorios
{
    public class SensorRepositorio : ISensorRepositorio
    {
        private readonly OracleFIAPDbContext _context;

        public SensorRepositorio(OracleFIAPDbContext context)
        {
            _context = context;
        }

        public void Add(Sensor sensor)
        {
            _context.Add(sensor);
            _context.SaveChanges();
        }

        public void Delete(Sensor sensor)
        {
            _context.Remove(sensor);
            _context.SaveChanges();
        }

        public IEnumerable<Sensor> GetAll()
        {
            return _context.Sensores.ToList();
        }

        public Sensor GetById(int? id)
        {
            return _context.Sensores.Find(id);
        }

        public void Update(Sensor sensor)
        {
            _context.Update(sensor);
            _context.SaveChangesAsync();
        }
    }
}
