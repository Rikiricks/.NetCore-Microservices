using Microsoft.EntityFrameworkCore;
using PlatformService.Data;
using PlatformService.SyncDataServices.Http;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddDbContext<AppDbContext>();
// builder.Services.AddDbContext<AppDbContext>(opt =>
//                     opt.UseSqlServer("Data Source=DESKTOP-7354L29\\SQLEXPRESS;Database=platformsdb;Trusted_Connection=True;MultipleActiveResultSets=true;TrustServerCertificate=True"));


// if (app.Environment.IsProduction())
//             {
                Console.WriteLine("--> Using SqlServer Db");
                // builder.Services.AddDbContext<AppDbContext>(opt =>
                //     opt.UseSqlServer("Data Source=DESKTOP-7354L29\\SQLEXPRESS;Database=platformsdb;Trusted_Connection=True;MultipleActiveResultSets=true"));
            // }
            // else
            // {
            //     Console.WriteLine("--> Using InMem Db");
            //    builder.Services.AddDbContext<AppDbContext>(opt => opt.UseInMemoryDatabase("InMem"));
            // }

// Add services to the container.


builder.Services.AddScoped<IPlatformRepo, PlatformRepo>();

builder.Services.AddHttpClient<ICommandDataClient, HttpCommandDataClient>();

builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


var app = builder.Build();
// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

//PrepDb.PrepPopulation(app, app.Environment.IsProduction());

app.Run();

