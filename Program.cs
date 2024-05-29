using GetPatientInfo.Models;
using GetPatientInfo.Repository;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddScoped<IResponseService, ResponseService>();
builder.Services.AddDbContext<DbContextClass>();

builder.Services.AddCors(options => {
    options.AddPolicy("CorsPolicy", builder => builder.WithOrigins(
        "http://localhost:4200",
        "https://localhost:7267"
    )
    .AllowAnyMethod()
    .AllowAnyHeader());
});

builder.Services.AddControllers();
builder.Services.AddCorrelationIdGenerator();
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

app.Run();
