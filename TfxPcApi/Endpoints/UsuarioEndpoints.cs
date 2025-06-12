using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using TfxPcApi.Models;
using TfxPcApi.Services;

namespace TfxPcApi.Endpoints
{
    public static class UsuarioEndpoints
    {
        public static void Map(WebApplication app)
        {
            app.MapPost("/usuarios/cadastrar", (Usuario usuario, UsuarioService service) =>
            {
                service.Cadastrar(usuario);
                return Results.Created($"/usuarios/{usuario.Id}", usuario);
            });

            app.MapPost("/usuarios/login", (LoginRequest request, UsuarioService service) =>
            {
                var usuario = service.Login(request.Email, request.Senha);
                if (usuario == null)
                    return Results.Unauthorized();

                return Results.Ok(usuario);
            });
        }
    }
}
