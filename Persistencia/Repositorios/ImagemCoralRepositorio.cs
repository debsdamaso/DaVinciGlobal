using DaVinciGlobal.Models;
using DaVinciGlobal.Persistencia.Repositorios.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace DaVinciGlobal.Persistencia.Repositorios
{
    public class ImagemCoralRepositorio : IImagemCoralRepositorio
    {
        private readonly OracleFIAPDbContext _context;

        public ImagemCoralRepositorio(OracleFIAPDbContext context)
        {
            _context = context;
        }

        public void Add(ImagemCoral imagemCoral)
        {
            _context.Add(imagemCoral);
            _context.SaveChanges();
        }

        public void Delete(ImagemCoral imagemCoral)
        {
            _context.Remove(imagemCoral);
            _context.SaveChanges();
        }

        public IEnumerable<ImagemCoral> GetAll()
        {
            return _context.ImagensCorais.ToList();
        }

        public ImagemCoral GetById(int? id)
        {
            return _context.ImagensCorais.Find(id);
        }

        public void Update(ImagemCoral imagemCoral)
        {
            _context.Update(imagemCoral);
            _context.SaveChangesAsync();
        }
    }
}
