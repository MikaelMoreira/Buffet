using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Buffet.DataBase;
using Buffet.Models.Acesso;
using Buffet.Models.Buffet.Cliente;
using Buffet.Models.Buffet.Convidado;
using Buffet.Models.Buffet.Evento;
using Buffet.Models.Buffet.Local;
using Buffet.Models.Buffet.Situações;

using Buffet.Models.Buffet.Tipos;
using Buffet.Models.Buffet.User;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace Buffet
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllersWithViews();

          services.AddDbContext<DataBaseContext>(optionsAction: option => 
               
             option.UseMySql(Configuration.GetConnectionString("BuffetDb")));

            services.AddIdentity<Usuario, Papel>(options =>

             {

                options.User.RequireUniqueEmail = true;
                options.Password.RequiredLength = 8;
                
                }
                ).AddEntityFrameworkStores<DataBaseContext>();

                services.ConfigureApplicationCookie(options =>

             {

                 options.LoginPath = "/Home/Login";
             });
                
                services.AddDistributedMemoryCache();

                services.AddSession(options =>
                {
                    options.IdleTimeout = TimeSpan.FromSeconds(10);
                    options.Cookie.HttpOnly = true;
                    options.Cookie.IsEssential = true;
                });

            services.AddTransient<AcessoService>();
            services.AddTransient<ClienteService>();
            services.AddTransient<TipoClienteService>();
            services.AddTransient<LocalService>();
            services.AddTransient<EventoService>();
            services.AddTransient<ConvidadoService>();
            services.AddTransient<SituacaoEventoService>();
            services.AddTransient<TipoEventoService>();
            services.AddTransient<SituacaoConvidadoService>();


            services.AddControllersWithViews();
            services.AddRazorPages();
            
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();
            
            app.UseSession();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
                
                    
            });
        }
    }
}