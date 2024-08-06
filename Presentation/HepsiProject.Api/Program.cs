using HepsiProject.Persistence;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var env = builder.Environment;
//burasý yukarýdan seçilen projeye göre environmenti ayarlar.
builder.Configuration.SetBasePath(env.ContentRootPath)
    .AddJsonFile("appsettings.json",optional:false)
//her þekilde appsettingsi bul ve ona göre konfigure et.
    .AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true);
//bu kod burada production veya environment olarak ayýklanmamýþ olabilir. isteðe baðlý kontrol et. demek.

builder.Services.AddPersistence(builder.Configuration);

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();

app.MapControllers();

app.Run();
