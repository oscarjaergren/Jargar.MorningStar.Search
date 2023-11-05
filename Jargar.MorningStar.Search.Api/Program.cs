using Jargar.MorningStar.Search.Api.Person.Settings;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container here.
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Configuration.AddJsonFile("persons.json", optional: false);
builder.Services.Configure<PersonSettings>(builder.Configuration.GetSection("PersonSettings"));

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

app.Run();

public partial class Program { }
