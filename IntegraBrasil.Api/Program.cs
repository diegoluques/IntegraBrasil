using AutoMapper;
using IntegraBrasil.Api.Dtos;
using IntegraBrasil.Api.Interfaces;
using IntegraBrasil.Api.Models;
using IntegraBrasil.Api.Rest;
using IntegraBrasil.Api.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddSingleton<IBrasilApi, BrasilApiRest>();
builder.Services.AddSingleton<IEnderecoService, EnderecoService>();
builder.Services.AddSingleton<IBancoService, BancoService>();

var config = new AutoMapper.MapperConfiguration(cfg =>
{
    cfg.CreateMap(typeof(ResponseObject<>), typeof(ResponseObject<>));
    cfg.CreateMap<EnderecoResponse, EnderecoModel>();
    cfg.CreateMap<EnderecoModel, EnderecoResponse>();
    cfg.CreateMap<BancoResponse, BancoModel>();
    cfg.CreateMap<BancoModel, BancoResponse>();
});
IMapper mapper = config.CreateMapper();
builder.Services.AddSingleton(mapper);

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
