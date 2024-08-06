using HepsiProject.Persistence;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var env = builder.Environment;
//buras� yukar�dan se�ilen projeye g�re environmenti ayarlar.
builder.Configuration.SetBasePath(env.ContentRootPath)
    .AddJsonFile("appsettings.json",optional:false)
//her �ekilde appsettingsi bul ve ona g�re konfigure et.
    .AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true);
//bu kod burada production veya environment olarak ay�klanmam�� olabilir. iste�e ba�l� kontrol et. demek.

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
