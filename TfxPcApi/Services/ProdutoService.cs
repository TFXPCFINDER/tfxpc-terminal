using System.Collections.Generic;
using TfxPcApi.Models;

namespace TfxPcApi.Services
{
    public class ProdutoService
    {
        private static List<Produto> produtos = new();
        private static int proximoId = 1;

        public ProdutoService()
        {
            // Produtos iniciais (carregados ao iniciar o serviço)
            if (produtos.Count == 0)
            {
                Adicionar(new Produto
                {
                    Nome = "PC Gamer Ryzen 5 5600 + RTX 3060",
                    Descricao = "Ryzen 5 5600, 16GB RAM, RTX 3060",
                    Preco = 3600,
                    Estoque = 5
                });

                Adicionar(new Produto
                {
                    Nome = "Notebook Gamer Dell G15",
                    Descricao = "5530, i5-13450HX, RTX 3050, 16GB RAM, SSD 512GB",
                    Preco = 5900,
                    Estoque = 5
                });

                Adicionar(new Produto
                {
                    Nome = "Monitor Gamer AOC DESTINY 25pol 240Hz",
                    Descricao = "0.5ms FreeSync Premium 25G3ZM",
                    Preco = 1300,
                    Estoque = 5
                });
            }
        }

        public void Adicionar(Produto produto)
        {
            produto.Id = proximoId++;
            produtos.Add(produto);
        }

        public List<Produto> Listar()
        {
            return produtos;
        }

        public Produto? ObterPorId(int id)
        {
            return produtos.FirstOrDefault(p => p.Id == id);
        }

        public void AtualizarEstoque(int produtoId, int quantidadeVendida)
        {
            var produto = ObterPorId(produtoId);
            if (produto != null)
            {
                produto.Estoque -= quantidadeVendida;
            }
        }
    }
}
