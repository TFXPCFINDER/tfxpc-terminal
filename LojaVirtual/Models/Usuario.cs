using System;
using System.Collections.Generic;
using System.Linq;

namespace LojaVirtual.Models
{
    public class Usuario
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Email { get; set; }
        public string Senha { get; set; } // Obs: em projeto real, nunca guardar senha como texto puro
        public string Endereco { get; set; }
        public List<Pedido> Pedidos { get; set; } = new List<Pedido>();

        public Usuario(int id, string nome, string email, string senha, string endereco)
        {
            Id = id;
            Nome = nome;
            Email = email;
            Senha = senha;
            Endereco = endereco;
        }

        public void AdicionarPedido(Pedido pedido)
        {
            Pedidos.Add(pedido);
        }
    }
}
