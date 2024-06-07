using DaVinciGlobal.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DaVinciGlobal.Persistencia.Mapeamento
{
    public class SensorMapeamento : IEntityTypeConfiguration<Sensor>
    {
        public void Configure(EntityTypeBuilder<Sensor> builder)
        {
            builder.ToTable("TB_DV_SENSOR");

            builder.HasKey(s => s.SensorId);

            builder.Property(s => s.SensorId)
                .HasColumnName("id_sensor");

            builder.Property(s => s.Localizacao)
                .IsRequired()
                .HasColumnName("ds_localizacao")
                .HasAnnotation("Localizacao", "O campo Localizacao é obrigatório");
        }
    }
}
