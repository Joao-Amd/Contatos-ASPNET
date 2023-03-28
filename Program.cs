using ControladorContatos.Data;
using ControladorContatos.Repositorio;
using ControladorContatos.Repositorio.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace ControladorContatos
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllersWithViews();

            builder.Services.AddDbContext<BancoContext>(o => o.UseSqlServer(builder.Configuration.GetConnectionString("DataBase")));
            builder.Services.AddScoped<IContatoRepositorio, ContatoRepositorio>();
            builder.Services.AddScoped<IUsuarioRepositorio, UsuarioRepositorio>();
            var app = builder.Build();
            

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
            }
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");

            app.Run();
            var connectionString = builder.Configuration.GetConnectionString("DataBase");
            builder.Services.AddEntityFrameworkSqlServer().AddDbContext<BancoContext>(options =>
                options.UseSqlServer(connectionString));

            
        }
    }
}