using TfxPcApi.Models;

namespace TfxPcApi.Services;

public class UsuarioService
{
    private readonly List<Usuario> _usuarios = new();
    private int _proximoId = 1;

    public Usuario Cadastrar(Usuario usuario)
    {
        usuario.Id = _proximoId++;
        _usuarios.Add(usuario);
        return usuario;
    }

    public Usuario? Login(string email, string senha)
    {
        return _usuarios.FirstOrDefault(u => u.Email == email && u.Senha == senha);
    }

    public Usuario? BuscarPorId(int id)
    {
        return _usuarios.FirstOrDefault(u => u.Id == id);
    }
}
