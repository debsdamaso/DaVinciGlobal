using DaVinciGlobal.Models;

namespace DaVinciGlobal.Persistencia.Repositorios.Interfaces
{
    public interface ISensorRepositorio
    {
        IEnumerable<Sensor> GetAll();
        Sensor GetById(int? id);
        void Add(Sensor sensor);
        void Update(Sensor sensor);
        void Delete(Sensor sensor);
    }
}
