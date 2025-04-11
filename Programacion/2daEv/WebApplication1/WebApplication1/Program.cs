using System.Text.Json.Serialization;

namespace ChessApp
{
    public class Program
    {
        
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            //// Add services to the container.
            ////recorre cod fuente buscando anotacion apicontroller
            builder.Services.AddControllers()
                .AddJsonOptions(options =>
                {
                    options.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter());
                }); ;
            ////para hacer que cada vez que creo algo y le tenga que llover un database llamas a idatabase y lo metes dejandolo vivo
            builder.Services.AddSingleton<IDatabase, Database>();

            //var app = builder.Build();
            ////// Configure the HTTP request pipeline.
            //app.UseAuthorization();
            ////esto hace new de las clases apicontroller
            //app.MapControllers();
            //app.Run();

            // Habilitar CORS sin restricciones
            builder.Services.AddCors(options =>
            {
                options.AddPolicy("AllowAll",
                    policy => policy.AllowAnyOrigin()
                                    .AllowAnyMethod()
                                    .AllowAnyHeader());
            });

            var app = builder.Build();

            app.UseCors("AllowAll"); // Aplica la política de CORS

            app.UseAuthorization();
            app.MapControllers();
            app.Run();

        }
    }
}
