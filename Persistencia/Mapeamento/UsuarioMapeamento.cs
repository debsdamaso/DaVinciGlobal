using DaVinciGlobal.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DaVinciGlobal.Persistencia.Mapeamento
{
    public class UsuarioMapeamento : IEntityTypeConfiguration<Usuario>
    {
        public void Configure(EntityTypeBuilder<Usuario> builder)
        {
            builder.ToTable("TB_DV_USUARIO");

            builder.HasKey(u => u.UsuarioId);

            builder.Property(u => u.UsuarioId)
                .HasColumnName("id_usuario");

            builder.Property(u => u.Nome)
                .IsRequired()
                .HasColumnName("nm_usuario")
                .HasAnnotation("Nome", "O campo Nome é obrigatório");

            builder.Property(u => u.Email)
                .IsRequired()
                .HasColumnName("ds_email")
                .HasAnnotation("Email", "O campo Email é obrigatório");

            builder.Property(u => u.Senha)
                .IsRequired()
                .HasColumnName("ds_senha")
                .HasAnnotation("Senha", "O campo Senha é obrigatório");
        }
    }
}
