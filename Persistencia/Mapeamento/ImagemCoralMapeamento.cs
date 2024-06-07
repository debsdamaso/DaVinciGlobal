using DaVinciGlobal.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DaVinciGlobal.Persistencia.Mapeamento
{
    public class ImagemCoralMapeamento : IEntityTypeConfiguration<ImagemCoral>
    {
        public void Configure(EntityTypeBuilder<ImagemCoral> builder)
        {
            builder.ToTable("TB_DV_IMAGEM_CORAL");

            builder.HasKey(ic => ic.ImagemCoralId);

            builder.Property(ic => ic.ImagemCoralId)
                .HasColumnName("id_imagem_coral");

            builder.Property(ic => ic.CaminhoImagem)
                .IsRequired()
                .HasColumnName("ds_caminho_imagem")
                .HasAnnotation("CaminhoImagem", "O campo CaminhoImagem é obrigatório");

            builder.Property(ic => ic.Localizacao)
                .IsRequired()
                .HasColumnName("ds_localizacao")
                .HasAnnotation("Localizacao", "O campo Localizacao é obrigatório");

            builder.Property(ic => ic.DataEnvio)
                .HasColumnName("dt_envio")
                .HasAnnotation("DataEnvio", "O campo DataEnvio é obrigatório");

            builder.Property(ic => ic.EstadoCoral)
                .IsRequired()
                .HasColumnName("ds_estado_coral")
                .HasAnnotation("EstadoCoral", "O campo EstadoCoral é obrigatório");
        }
    }
}
