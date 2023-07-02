using AutoMapper;
using CleanArchitecture.API.Mappers;
using CleanArchitecture.Application.Abstractions;
using CleanArchitecture.Application.Services;
using CleanArchitecture.Infrastructure.Database.Abstractions;
using System.Text.Json.Serialization;

namespace CleanArchitecture.API.Extensions
{
    public static class AppServiceExtensions
    {
        public static void ConfigureCors(this IServiceCollection services) =>
        services.AddCors( options =>
        {
            options.AddPolicy("CorsPolicy", builder => builder
            .AllowAnyOrigin() //WithOrigins("url"))
            .AllowAnyMethod() //WithMethods("GET", "POST")
            .AllowAnyHeader()); //WithHeaders("accept","content-type")
        });

        public static void AddAplicationServices(this IServiceCollection services)
        {
            services.AddScoped<IArtistService, ArtistService>();
            services.AddScoped<IArtistDAO, ArtistDAO>();
        }

        public static void AddMappers(this IServiceCollection services) 
        {
            var mapperConfig = new MapperConfiguration(m => { m.AddProfile(new MappingProfile()); });

            IMapper mapper = mapperConfig.CreateMapper();

            services.AddSingleton(mapper);
            services.AddMvc();
        }

        public static void IngoreJsonCircularReferences(this IServiceCollection services)
        {
            services.AddControllers().AddJsonOptions(x =>
                x.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles);
        }
    }
}
