using DaVinciGlobal.Models;

namespace DaVinciGlobal.Persistencia.Repositorios.Interfaces
{
    public interface IRelatorioRepositorio
    {
        IEnumerable<Relatorio> GetAll();
        Relatorio GetById(int? id);
        void Add(Relatorio relatorio);
        void Update(Relatorio relatorio);
        void Delete(Relatorio relatorio);
    }
}
