using System.Collections.Generic;

namespace DaVinciGlobal.Models
{
    public class Sensor
    {
        public int SensorId { get; set; }
        public string Nome { get; set; }
        public string Localizacao { get; set; }

        // Propriedade de navegação para os relatórios
        public ICollection<Relatorio> Relatorios { get; set; }

        // Navegação para os dados de temperatura registrados pelo sensor
        public ICollection<DadoTemperatura> DadosTemperatura { get; set; }

    }
}
