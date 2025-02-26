namespace ChessApp
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            // Add services to the container.
            //recorre cod fuente buscando anotacion apicontroller
            builder.Services.AddControllers();
            //para hacer que cada vez que creo algo y le tenga que llover un database llamas a idatabase y lo metes dejandolo vivo
            builder.Services.AddSingleton<IDatabase, Database>();

            var app = builder.Build();
            //// Configure the HTTP request pipeline.
            app.UseAuthorization();
            //esto hace new de las clases apicontroller
            app.MapControllers();
            app.Run();
        }
    }
}
