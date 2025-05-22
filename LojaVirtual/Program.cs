using System;
using System.Collections.Generic;
using System.Linq;
using LojaVirtual.Models;

namespace LojaVirtual
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Produto> produtos = new List<Produto>
            {
                new Produto(1, "PC Gamer Ryzen", "Ryzen 5, 16GB RAM, RTX 4060", 4800.00m, 10),
                new Produto(2, "Notebook i7", "Intel i7, 8GB RAM, SSD 512GB", 4200.00m, 5),
                new Produto(3, "Monitor 144Hz", "27'', Full HD", 900.00m, 8)
            };

            List<Usuario> usuarios = new List<Usuario>();
            Usuario? usuarioLogado = null;
            List<ItemPedido> carrinho = new List<ItemPedido>();

            bool executando = true;

            while (executando)
            {
                Console.Clear();
                Console.WriteLine("=== TFX_PC ===\n");

                if (usuarioLogado == null)
                {
                    Console.WriteLine("[1] Login");
                    Console.WriteLine("[2] Cadastrar novo usuário");
                    Console.WriteLine("[0] Sair");
                    Console.Write("\nEscolha: ");
                    var escolha = Console.ReadLine();

                    switch (escolha)
                    {
                        case "1":
                            Console.Write("Email: ");
                            string email = Console.ReadLine()!;
                            Console.Write("Senha: ");
                            string senha = Console.ReadLine()!;

                            usuarioLogado = usuarios.FirstOrDefault(u => u.Email == email && u.Senha == senha);
                            if (usuarioLogado == null)
                            {
                                Console.WriteLine("Usuário ou senha inválidos.");
                                Console.ReadKey();
                            }
                            break;

                        case "2":
                            Console.Write("Nome: ");
                            string nome = Console.ReadLine()!;
                            Console.Write("Email: ");
                            string novoEmail = Console.ReadLine()!;
                            Console.Write("Senha: ");
                            string novaSenha = Console.ReadLine()!;
                            Console.Write("Endereço: ");
                            string endereco = Console.ReadLine()!;

                            int novoId = usuarios.Count + 1;
                            usuarios.Add(new Usuario(novoId, nome, novoEmail, novaSenha, endereco));
                            Console.WriteLine("Usuário cadastrado com sucesso!");
                            Console.ReadKey();
                            break;

                        case "0":
                            executando = false;
                            break;
                    }
                }
                else
                {
                    Console.WriteLine($"Bem-vindo, {usuarioLogado.Nome}!\n");
                    Console.WriteLine("[1] Ver produtos");
                    Console.WriteLine("[2] Ver carrinho");
                    Console.WriteLine("[3] Finalizar pedido");
                    Console.WriteLine("[4] Ver meus pedidos");
                    Console.WriteLine("[5] Logout");
                    Console.Write("\nEscolha: ");
                    var escolha = Console.ReadLine();

                    switch (escolha)
                    {
                        case "1":
                            Console.Clear();
                            Console.WriteLine("== Produtos Disponíveis ==\n");
                            foreach (var p in produtos)
                                Console.WriteLine(p);

                            Console.Write("\nDigite o ID do produto para adicionar ao carrinho (ou 0 para voltar): ");
                            if (int.TryParse(Console.ReadLine(), out int idProduto) && idProduto > 0)
                            {
                                var produtoSelecionado = produtos.FirstOrDefault(p => p.Id == idProduto);
                                if (produtoSelecionado != null)
                                {
                                    Console.Write("Quantidade: ");
                                    if (int.TryParse(Console.ReadLine(), out int qtd) && qtd > 0 && qtd <= produtoSelecionado.Estoque)
                                    {
                                        carrinho.Add(new ItemPedido(produtoSelecionado, qtd));
                                        Console.WriteLine("Produto adicionado ao carrinho!");
                                    }
                                    else
                                    {
                                        Console.WriteLine("Quantidade inválida ou sem estoque suficiente.");
                                    }
                                }
                                else
                                {
                                    Console.WriteLine("Produto não encontrado.");
                                }
                            }
                            Console.ReadKey();
                            break;

                        case "2":
                            Console.Clear();
                            Console.WriteLine("== Carrinho ==\n");
                            if (carrinho.Count == 0)
                            {
                                Console.WriteLine("Carrinho vazio.");
                            }
                            else
                            {
                                foreach (var item in carrinho)
                                    Console.WriteLine(item);
                                Console.WriteLine($"\nTotal: R${carrinho.Sum(i => i.Subtotal)}");
                            }
                            Console.ReadKey();
                            break;

                        case "3":
                            Console.Clear();
                            if (carrinho.Count == 0)
                            {
                                Console.WriteLine("Carrinho vazio. Não é possível finalizar pedido.");
                            }
                            else
                            {
                                bool estoqueOk = true;
                                foreach (var item in carrinho)
                                {
                                    if (item.Quantidade > item.Produto.Estoque)
                                    {
                                        estoqueOk = false;
                                        Console.WriteLine($"Estoque insuficiente para {item.Produto.Nome}");
                                    }
                                }

                                if (estoqueOk)
                                {
                                    var pedido = new Pedido(usuarioLogado);
                                    foreach (var item in carrinho)
                                    {
                                        pedido.AdicionarItem(item);
                                        item.Produto.AtualizarEstoque(item.Quantidade);
                                    }
                                    usuarioLogado.AdicionarPedido(pedido);
                                    carrinho.Clear();
                                    Console.WriteLine($"\nPedido #{pedido.Id} finalizado com sucesso!");
                                    Console.WriteLine($"Total: R${pedido.Total}");
                                }
                            }
                            Console.ReadKey();
                            break;

                        case "4":
                            Console.Clear();
                            Console.WriteLine("== Meus Pedidos ==\n");
                            if (usuarioLogado.Pedidos.Count == 0)
                            {
                                Console.WriteLine("Você ainda não fez nenhum pedido.");
                            }
                            else
                            {
                                foreach (var pedido in usuarioLogado.Pedidos)
                                {
                                    Console.WriteLine(pedido);
                                    foreach (var item in pedido.Itens)
                                    {
                                        Console.WriteLine($"   {item}");
                                    }
                                }
                            }
                            Console.ReadKey();
                            break;

                        case "5":
                            usuarioLogado = null;
                            carrinho.Clear();
                            break;
                    }
                }
            }

            Console.WriteLine("Obrigado por confiar na TFX_PC.");
        }
    }
}
