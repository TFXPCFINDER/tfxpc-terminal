using TfxPcApi.Services;
using TfxPcApi.Endpoints;

var builder = WebApplication.CreateBuilder(args);

// Serviços
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddScoped<ProdutoService>();
builder.Services.AddScoped<UsuarioService>();
builder.Services.AddScoped<PedidoService>();

// CORS liberado para permitir acesso do React
builder.Services.AddCors(options =>
{
    options.AddPolicy("Liberado", policy =>
    {
        policy.AllowAnyOrigin()
              .AllowAnyMethod()
              .AllowAnyHeader();
    });
});

builder.Services.AddAuthorization();

var app = builder.Build();

// Swagger
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

// Ativar CORS antes da autorização
app.UseCors("Liberado");

// app.UseHttpsRedirection(); // Desabilitado por problemas com porta
app.UseAuthorization();

// Mapear endpoints
ProdutoEndpoints.Map(app);
UsuarioEndpoints.Map(app);
PedidoEndpoints.Map(app);

app.Run();
