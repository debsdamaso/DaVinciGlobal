namespace DaVinciGlobal.Models
{
    public class ImagemCoral
    {
        public int ImagemCoralId { get; set; }
        public string CaminhoImagem { get; set; }
        public string Localizacao { get; set; }
        public DateTime DataEnvio { get; set; }
        public string EstadoCoral { get; set; }
        public int UsuarioId { get; set; }
        public Usuario Usuario { get; set; }
    }

}
