namespace DaVinciGlobal.Models
{
    public class DadoTemperatura
    {
        public int DadoTemperaturaId { get; set; }
        public DateTime DataColeta { get; set; }
        public double Temperatura { get; set; }
        public int SensorId { get; set; }
        public Sensor Sensor { get; set; }
    }

}
