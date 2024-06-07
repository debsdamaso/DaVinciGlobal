using DaVinciGlobal.Models;

namespace DaVinciGlobal.Persistencia.Repositorios.Interfaces
{
    public interface IDadoTemperaturaRepositorio
    {
        IEnumerable<DadoTemperatura> GetAll();
        DadoTemperatura GetById(int? id);
        void Add(DadoTemperatura dadoTemperatura);
        void Update(DadoTemperatura dadoTemperatura);
        void Delete(DadoTemperatura dadoTemperatura);
    }
}
