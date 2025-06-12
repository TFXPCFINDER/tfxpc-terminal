using System.Collections.Generic;
using TfxPcApi.Models;

namespace TfxPcApi.Services
{
    public class UsuarioService
    {
        private static List<Usuario> usuarios = new();
        private static int proximoId = 1;

        public void Cadastrar(Usuario usuario)
        {
            usuario.Id = proximoId++;
            usuarios.Add(usuario);
        }

        public Usuario? Login(string email, string senha)
        {
            return usuarios.FirstOrDefault(u => u.Email == email && u.Senha == senha);
        }

        public Usuario? ObterPorId(int id)
        {
            return usuarios.FirstOrDefault(u => u.Id == id);
        }
    }
}
