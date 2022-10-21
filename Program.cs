using webapi.Services;
using webapi;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
//builder.Services.AddSqlServer<TareasContext>("Data Source=servername;Initial Catalog=NombreBD;user id=usuariodb;password:passDB");
builder.Services.AddSqlServer<TareasContext>(builder.Configuration.GetConnectionString("cnTareas"));
//Cada vez que se inyecte la interfaz se crea un nuevo objeto HelloWorldService
// builder.Services.AddScoped<IHelloWorldService>(p=> new HelloworldService()); // Para cuando necesitamos pasar parametros
builder.Services.AddScoped<IHelloWorldService, HelloworldService>(); //Inyección de nuestra dependencia, crea una nueva instanacia a nivel de clase o de controlador
builder.Services.AddScoped<ICategoriaService,CategoriaService>();
builder.Services.AddScoped<ITareaService,TareaService>();
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

//app.UseTimeMiddleware();
//app.UseWelcomePage();//middleware

app.MapControllers();

app.Run();
