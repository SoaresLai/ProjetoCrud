using System;
using System.ComponentModel.DataAnnotations.Schema;
using ProjetoCRUD.Data;
using ProjetoCRUD.Models;
using ProjetoCRUD.Repository;

class Program
{
    static void Main()
    {
        Database.BaseBoot();
        var repository = new ProdutoRepository();

        while (true)
        {
            Console.WriteLine("\n==============================");
            Console.WriteLine("1 - Adicionar Produto");
            Console.WriteLine("2 - Listar Produtos");
            Console.WriteLine("3 - Buscar Produto por ID");
            Console.WriteLine("4 - Atualizar Produto");
            Console.WriteLine("5 - Remover Produto");
            Console.WriteLine("0 - Sair");
            Console.WriteLine("==============================");
            Console.Write("\nEscolha uma opção: ");

            var opcao = Console.ReadLine();
            Console.Clear();

            switch (opcao)
            {
                case "1":
                    Console.Write("Nome do Produto: ");
                    var name = Console.ReadLine();
                    Console.Write("Preço do Produto: ");
                    var price = decimal.Parse(Console.ReadLine());

                    repository.Create(new Produto { Nome = name, Preco = price });
                    Console.WriteLine("Produto adicionado com sucesso!");
                    break;

                case "2":
                    var produtos = repository.ShowAll();
                    Console.WriteLine("\nLista de Produtos:");
                    foreach (var produto in produtos) 
                        Console.WriteLine($"ID: {produto.Id}, Nome: {produto.Nome}, Preço: {produto.Preco:C}");
                    break;

                case "3":
                    Console.Write("Digite o ID do Produto: ");
                    var searchID = int.Parse(Console.ReadLine());
                    var findProduct = repository.SearchId(searchID);

                    if (findProduct != null)
                        Console.WriteLine($"ID: {findProduct.Id}, Nome: {findProduct.Nome}, Preço: {findProduct.Preco}");
                    else
                        Console.WriteLine("Produto não encontrado.");
                    break;

                case "4":
                    Console.Write("ID do Produto para atualizar: ");
                    var updateId = int.Parse(Console.ReadLine());
                    Console.Write("Novo Nome: ");
                    var newName = Console.ReadLine();
                    Console.Write("Novo Preço: ");
                    var newPrice = decimal.Parse(Console.ReadLine());

                    repository.Update(new Produto { Id = updateId, Nome = newName, Preco = newPrice });
                    Console.WriteLine("Produto Atualizado com Sucesso!");
                    break;

                case "5":
                    Console.Write("ID do Produto que deseja Remover: ");
                    var removeId = int.Parse(Console.ReadLine());
                    repository.Delete(removeId);
                    Console.WriteLine("Produto Removido com Sucesso!");
                    break;

                case "0":
                    return;

                default:
                    Console.WriteLine("Opção Inválida, tente nnovamente!");
                    break;
            }
        }
    }
}