using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using TfxPcApi.Models;
using TfxPcApi.Services;

namespace TfxPcApi.Endpoints
{
    public static class ProdutoEndpoints
    {
        public static void Map(WebApplication app)
        {
            app.MapGet("/produtos", (ProdutoService service) =>
            {
                return Results.Ok(service.Listar());
            });

            app.MapPost("/produtos", (Produto produto, ProdutoService service) =>
            {
                service.Adicionar(produto);
                return Results.Created($"/produtos/{produto.Id}", produto);
            });
        }
    }
}
