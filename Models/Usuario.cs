using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;

namespace DaVinciGlobal.Models
{
    public class Usuario
    {
        public int UsuarioId { get; set; }

        [Required]
        public string Nome { get; set; }

        [Required]
        public string Email { get; set; }

        [Required]
        public string Senha { get; set; }

        public ICollection<ImagemCoral> ImagensCorais { get; set; }
    }
}
