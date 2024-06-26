using MakersSolutions.Application;
using MakersSolutions.DataAccess;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddApplicationServicesRegistration();
builder.Services.AddDataAccessServicesRegistration(builder.Configuration);

builder.Services.AddControllers();

builder.Services.AddCors(options => {
    options.AddPolicy("all", builder => builder.AllowAnyOrigin()
        .AllowAnyHeader()
        .AllowAnyMethod()
    );
});

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

app.UseCors("all");

app.UseAuthorization();

app.MapControllers();

app.Run();
