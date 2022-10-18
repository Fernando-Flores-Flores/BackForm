﻿using Microsoft.EntityFrameworkCore;
using ProyectoCurso.Controllers;
using ProyectoCurso.Servicios;
using System.Text.Json.Serialization;
using static ProyectoCurso.Servicios.IServicio;

namespace ProyectoCurso
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
         //   var autoresControler = new AutoresControler(new ApplicationDbContext(null), new ServicioA());
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        //Configurar los servicios
        public void ConfigureServices(IServiceCollection services) {
            // Add services to the container.
            services.AddDbContext<ApplicationDbContext>(options => options.UseNpgsql(Configuration.GetConnectionString("defaultConnection")));

            //Ignorar ciclos infinitosf
            services.AddControllers().AddJsonOptions(x=>x.JsonSerializerOptions.ReferenceHandler=ReferenceHandler.IgnoreCycles);
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            services.AddEndpointsApiExplorer();
            services.AddSwaggerGen();
        }

        public void Configure(IApplicationBuilder app,IWebHostEnvironment env) {

            // Configure the HTTP request pipeline.
            if (env.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();
            app.UseRouting();   

                    
            app.UseAuthorization();

            app.UseEndpoints(endpoints => {
                endpoints.MapControllers();
            });

        }


    }
}
