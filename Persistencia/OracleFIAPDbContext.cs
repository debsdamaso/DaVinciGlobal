using DaVinciGlobal.Models;
using DaVinciGlobal.Persistencia.Mapeamento;
using Microsoft.EntityFrameworkCore;

namespace DaVinciGlobal.Persistencia
{
    public class OracleFIAPDbContext : DbContext
    {
        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Relatorio> Relatorios { get; set; }
        public DbSet<Sensor> Sensores { get; set; }
        public DbSet<DadoTemperatura> DadosTemperatura { get; set; }
        public DbSet<ImagemCoral> ImagensCorais { get; set; }

        public OracleFIAPDbContext(DbContextOptions<OracleFIAPDbContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new UsuarioMapeamento());
            modelBuilder.ApplyConfiguration(new RelatorioMapeamento());
            modelBuilder.ApplyConfiguration(new SensorMapeamento());
            modelBuilder.ApplyConfiguration(new DadoTemperaturaMapeamento());
            modelBuilder.ApplyConfiguration(new ImagemCoralMapeamento());
        }
    }
}

