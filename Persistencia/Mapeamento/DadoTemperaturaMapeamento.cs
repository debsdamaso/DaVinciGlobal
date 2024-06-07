using DaVinciGlobal.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DaVinciGlobal.Persistencia.Mapeamento
{
    public class DadoTemperaturaMapeamento : IEntityTypeConfiguration<DadoTemperatura>
    {
        public void Configure(EntityTypeBuilder<DadoTemperatura> builder)
        {
            builder.ToTable("TB_DV_DADO_TEMPERATURA");

            builder.HasKey(dt => dt.DadoTemperaturaId);

            builder.Property(dt => dt.DadoTemperaturaId)
                .HasColumnName("id_dado_temperatura");

            builder.Property(dt => dt.DataColeta)
                .HasColumnName("dt_coleta")
                .HasAnnotation("DataColeta", "O campo DataColeta é obrigatório");

            builder.Property(dt => dt.Temperatura)
                .HasColumnName("vl_temperatura")
                .HasAnnotation("Temperatura", "O campo Temperatura é obrigatório");
        }
    }
}
