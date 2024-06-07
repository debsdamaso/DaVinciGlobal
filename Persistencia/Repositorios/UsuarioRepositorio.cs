using DaVinciGlobal.Models;
using DaVinciGlobal.Persistencia.Repositorios.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace DaVinciGlobal.Persistencia.Repositorios
{
    public class UsuarioRepositorio : IUsuarioRepositorio
    {
        private readonly OracleFIAPDbContext _context;

        public UsuarioRepositorio(OracleFIAPDbContext context)
        {
            _context = context;
        }

        public void Add(Usuario usuario)
        {
            _context.Add(usuario);
            _context.SaveChanges();
        }

        public void Delete(Usuario usuario)
        {
            _context.Remove(usuario);
            _context.SaveChanges();
        }

        public IEnumerable<Usuario> GetAll()
        {
            return _context.Usuarios.ToList();
        }

        public Usuario GetById(int? id)
        {
            return _context.Usuarios.Find(id);
        }

        public void Update(Usuario usuario)
        {
            _context.Update(usuario);
            _context.SaveChanges();
        }
    }
}

