using CardsOfWords.WebApi.Words.Data;
using CardsOfWords.WebApi.Words.Helpers;
using CardsOfWords.WebApi.Words.Repository.Interfaces;
using CardsOfWords.WebApi.Words.Services;

namespace CardsOfWords.WebApi.Words
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            var services = builder.Services;
            services.AddDbContext<DataContext>();

            services.AddCors();
            services.AddControllers();
            services.AddEndpointsApiExplorer();
            services.AddSwaggerGen();
            services.AddAutoMapper(typeof(AppMappingProfile));
            services.AddScoped<IAppVersionRepository, AppVersionRepository>();
            services.AddScoped<ILanguageRepository, LanguageRepository>();
            services.AddScoped<IWordGroupRepository, WordGroupRepository>();
            services.AddScoped<IWordRepository, WordRepository>();

            var app = builder.Build();

            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }
            app.UseCors(x => x.AllowAnyHeader().AllowAnyMethod().AllowAnyOrigin());
            app.MapControllers();
            app.Run();
        }
    }
}