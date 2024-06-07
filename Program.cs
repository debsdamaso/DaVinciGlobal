using Microsoft.EntityFrameworkCore;
using DaVinciGlobal.Persistencia;
using DaVinciGlobal.Persistencia.Repositorios.Interfaces;
using DaVinciGlobal.Persistencia.Repositorios;
using DaVinciGlobal.Models;

namespace DaVinciGlobal
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllersWithViews();

            builder.Services.AddDbContext<OracleFIAPDbContext>(options =>
            {
                options.UseOracle(builder.Configuration.GetConnectionString("OracleFIAPDbContext"));
            });

            // Register your repositories
            builder.Services.AddScoped<IRepositorio<Usuario>, Repositorio<Usuario>>();
            builder.Services.AddScoped<IRepositorio<Sensor>, Repositorio<Sensor>>();
            builder.Services.AddScoped<IRepositorio<DadoTemperatura>, Repositorio<DadoTemperatura>>();
            builder.Services.AddScoped<IRepositorio<ImagemCoral>, Repositorio<ImagemCoral>>();
            builder.Services.AddScoped<IRepositorio<Relatorio>, Repositorio<Relatorio>>();
            builder.Services.AddScoped<IUsuarioRepositorio, UsuarioRepositorio>();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");

            app.Run();
        }
    }
}

