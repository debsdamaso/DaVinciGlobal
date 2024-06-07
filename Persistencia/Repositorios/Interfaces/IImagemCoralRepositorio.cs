using DaVinciGlobal.Models;

namespace DaVinciGlobal.Persistencia.Repositorios.Interfaces
{
    public interface IImagemCoralRepositorio
    {
        IEnumerable<ImagemCoral> GetAll();
        ImagemCoral GetById(int? id);
        void Add(ImagemCoral imagemCoral);
        void Update(ImagemCoral imagemCoral);
        void Delete(ImagemCoral imagemCoral);
    }
}
