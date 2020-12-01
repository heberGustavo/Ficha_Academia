using FichaAcademia.AcessoDados;
using FichaAcademia.AcessoDados.Interfaces;
using FichaAcademia.AcessoDados.Repositorios;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Rotativa.AspNetCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FichaAcademia
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllersWithViews();
            services.AddDbContext<Contexto>(opcoes => opcoes.UseSqlServer(Configuration.GetConnectionString("ConexaoDB")));

            //Repositorios
            services.AddTransient<ICategoriaExercicioRepositorio, CategoriaExercicioRepositorio>();

            //Possibilitar usar Sessões
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();

            //Sessões
            services.AddSession(opcoes =>
            {
               opcoes.IdleTimeout = TimeSpan.FromHours(1); //1h
            });

            //Autenticação
            services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
                .AddCookie(opcoes =>
                {
                    opcoes.LoginPath = "/Administradores/Login";
                });
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                app.UseHsts();
            }

            //Validando o uso de Sessão e Autenticacao
            app.UseSession();
            app.UseAuthentication();

            //Rotativa
            RotativaConfiguration.Setup(env.WebRootPath, "Rotativa");

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
