using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Agapea_MVC_NetCore.Interfaces;
using Agapea_MVC_NetCore.Models;

using Agapea_MVC_NetCore.Infraestructura; // restricciones segmentos rutas

using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Agapea_MVC_NetCore
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        [Obsolete]
        public void ConfigureServices(IServiceCollection services)
        {
            // ..... aqui se efinen la inyeccion de dependencias.....
            services.AddSingleton<IDBAccess, SQLServerDBAccess>();
            //services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();

            //-------------------------------------------------------
            services.AddDistributedMemoryCache();

            services.AddSession(options =>
            {
                // Set a short timeout for easy testing.
                options.IdleTimeout = TimeSpan.FromSeconds(10);
                options.Cookie.HttpOnly = true;
                // Make the session cookie essential
                options.Cookie.IsEssential = true;
            });
            /*services.Configure<CookiePolicyOptions>(options =>
            {
                // This lambda determines whether user consent for non-essential cookies is needed for a given request.
                options.CheckConsentNeeded = context => true;
                options.MinimumSameSitePolicy = SameSiteMode.None;
            });*/

            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);


            /*services.AddSession((SessionOptions options1) =>
            {
                options1.CookieHttpOnly = true;
            });*/

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
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

            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseCookiePolicy();

            app.UseSession();



            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
                routes.MapRoute(
                    name: "busqueda",   //nombre de ruta 1er parametro
                    template: "{controller=Home}/{action=Buscar}/{opcion}/{valor}",   //patron ruta 2º parametro
                    new { opcion= "Titulo",valor="*"},    //objeto anonimo con valores por defecto 3er parametro
                    new RouteValueDictionary() { 
                                        { "opcion", new OpcionesMateriaRouteConstraint()}//@"^(Titulo|ISBN|Autor|Editorial)$" },
                                        //{ "valor", @"^[A-Za-z][0-9]\\s+$"} 
                         }     //objeto de restricciones de formato 4º parametro
                               //es una colecion del tipo RouteValueDictionary , diccionario clave-valor, la clave es cada
                               //segmento y el valor es la restriccion sebre cada segmento
                               /* new {opcion= @"^(Titulo|ISBN|Autor|Editorial)$"}, 
                                * valor=@"^[A-Za-z][0-9]\\s+$"
                                */
                    );
            });
        }
    }
}
