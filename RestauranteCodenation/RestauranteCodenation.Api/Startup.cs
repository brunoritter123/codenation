using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using RestauranteCodenation.Data.Repositorio;
using RestauranteCodenation.Domain.Repositorio;
using RestauranteCodenation.Application.Mapper;
using AutoMapper;
using RestauranteCodenation.Application.Interface;
using RestauranteCodenation.Application.App;
using Microsoft.OpenApi.Models;

namespace RestauranteCodenation.Api
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
            services.AddControllers()
                .AddNewtonsoftJson(options => options.SerializerSettings.ReferenceLoopHandling =
                Newtonsoft.Json.ReferenceLoopHandling.Ignore);

            services.AddScoped(typeof(IRepositorioBase<>), typeof(RepositorioBase<>));
            services.AddScoped<ITipoPratoRepositorio, TipoPratoRepositorio>();
            services.AddScoped<IAgendaCardapioRepositorio, AgendaCardapioRepositorio>();
            services.AddScoped<IAgendaRepositorio, AgendaRepositorio>();
            services.AddScoped<ICardapioRepositorio, CardapioRepositorio>();
            services.AddScoped<IIngredienteRepositorio, IngredienteRepositorio>();
            services.AddScoped<IPratoRepositorio, PratoRepositorio>();
            services.AddScoped<IPratosIngredientesRepositorio, PratosIngredientesRepositorio>();

            services.AddScoped<ITipoPratoApplication, TipoPratoApplication>();
            services.AddScoped<IAgendaCardapioApplication, AgendaCardapioApplication>();
            services.AddScoped<IAgendaApplication, AgendaApplication>();
            services.AddScoped<ICardapioApplication, CardapioApplication>();
            services.AddScoped<IIngredienteApplication, IngredienteApplication>();
            services.AddScoped<IPratoApplication, PratoApplication>();
            services.AddScoped<IPratosIngredientesApplication, PratosIngredientesApplication>();

            services.AddAutoMapper(typeof(AutoMapperConfig));
            services.AddSwaggerGen(x => x.SwaggerDoc(name: "v1", new OpenApiInfo { Title = "Restaurante do Bruno", Version = "v1" }));
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseSwagger();
            app.UseSwaggerUI(x =>
            {
                x.SwaggerEndpoint(url: "/swagger/v1/swagger.json", name: "Api do Bruno");
            });

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

        }
    }
}
