﻿using DaVinciGlobal.Models;

namespace DaVinciGlobal.Persistencia.Repositorios.Interfaces
{
    public interface IUsuarioRepositorio
    {
        IEnumerable<Usuario> GetAll();
        Usuario GetById(int? id);
        void Add(Usuario usuario);
        void Update(Usuario usuario);
        void Delete(Usuario usuario);
    }
}
