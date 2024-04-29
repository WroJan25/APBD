using FluentValidation;
using Cwiczenia6;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddControllers();
builder.Services.AddValidatorsFromAssemblyContaining<CreateAnimalRequestValidator>();
builder.Services.AddValidatorsFromAssemblyContaining<EditAnimalRequestValidator>();
var app = builder.Build();
    app.UseSwagger();
    app.UseSwaggerUI();
app.MapControllers();
app.UseHttpsRedirection();

app.Run();