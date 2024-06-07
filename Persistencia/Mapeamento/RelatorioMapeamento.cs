using DaVinciGlobal.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DaVinciGlobal.Persistencia.Mapeamento
{
    public class RelatorioMapeamento : IEntityTypeConfiguration<Relatorio>
    {
        public void Configure(EntityTypeBuilder<Relatorio> builder)
        {
            builder.ToTable("TB_DV_RELATORIO");

            builder.HasKey(r => r.RelatorioId);

            builder.Property(r => r.RelatorioId)
                .HasColumnName("id_relatorio")
                .IsRequired();

            builder.Property(r => r.DataInicio)
                .HasColumnName("dt_inicio")
                .IsRequired();

            builder.Property(r => r.DataFim)
                .HasColumnName("dt_fim")
                .IsRequired();

            builder.Property(r => r.Localizacao)
                .HasColumnName("ds_localizacao")
                .IsRequired();

            builder.Property(r => r.TemperaturaMaxima)
                .HasColumnName("vl_temperatura_maxima");

            builder.Property(r => r.TemperaturaMedia)
                .HasColumnName("vl_temperatura_media");

            builder.Property(r => r.TemperaturaMinima)
                .HasColumnName("vl_temperatura_minima");

            builder.Property(r => r.SensorId)
                .HasColumnName("SensorId")
                .IsRequired();

            builder.HasOne(r => r.Sensor)
                .WithMany(s => s.Relatorios)
                .HasForeignKey(r => r.SensorId);
        }
    }
}

