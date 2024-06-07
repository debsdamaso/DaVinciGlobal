using System;
using System.ComponentModel.DataAnnotations;

namespace DaVinciGlobal.Models
{
    public class Relatorio
    {
        public int RelatorioId { get; set; }

        [Required]
        public DateTime DataInicio { get; set; }

        [Required]
        public DateTime DataFim { get; set; }

        [Required]
        public string Localizacao { get; set; }

        public double? TemperaturaMaxima { get; set; }
        public double? TemperaturaMedia { get; set; }
        public double? TemperaturaMinima { get; set; }

        public int SensorId { get; set; }
        public Sensor Sensor { get; set; }
    }
}

