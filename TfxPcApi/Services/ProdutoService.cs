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
                    Nome = "PC Gamer RTX",
                    Descricao = "Ryzen 5, 16GB RAM, RTX 3060",
                    Preco = 4800,
                    Estoque = 10
                });

                Adicionar(new Produto
                {
                    Nome = "Notebook Intel i7",
                    Descricao = "i7, 16GB RAM, SSD 512GB",
                    Preco = 3700,
                    Estoque = 5
                });

                Adicionar(new Produto
                {
                    Nome = "Monitor 144Hz",
                    Descricao = "27 polegadas Full HD",
                    Preco = 1200,
                    Estoque = 8
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
