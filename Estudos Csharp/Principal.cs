using System;
using System.Collections.Generic;
using System.Linq;
using Estudos_Csharp.Infraestrutura;

namespace Estudos_Csharp
{
    class Principal
    {
        public static void Main(string[] args)
        {
            List<Livro> LivrosEstoque = new List<Livro>
            {
                new Livro("Harry Potter", "J.K Rowling", new DateTime(1997, 6, 26), 20.00),
                new Livro("O Hobbit", "J.R.R Tolkien", new DateTime(1937, 9, 21), 15.00),
                new Livro("The Lord of the Rings", "J.R.R Tolkien", new DateTime(1954, 7, 29), 25.00),
                new Livro("O Fantasma da Ópera", "Gaston Leroux", new DateTime(2024, 11, 10), 75.00)
            };

            SalvarLivros(LivrosEstoque);

            ExibirLista(RecuperarLivros());

            /*
            Solicitante solicitante1 = new Solicitante("Augusto", "(47) 1234-56789");
            Solicitante solicitante2 = new Solicitante("Angela", "(47) 1234-56789");

            LivroLocado livroLocado1 = new LivroLocado(solicitante1, LivrosEstoque[1]);
            livroLocado1.locacao = new DateTime(2024, 11, 10);

            solicitante1.locacoes.Add(livroLocado1);

            LocarLivro(solicitante2, LivrosEstoque[1]);

            DevolverLivro(livroLocado1);

            ExibirLista(OrdenarLivroAutor(LivrosEstoque));

            ExibirLista(OrdenarLivroData(LivrosEstoque));
            */

            void SalvarLivros(List<Livro> livros)
            {
                var repository = new LivroRepository();

                foreach (Livro item in livros)
                {
                    repository.Add(item);
                }
            }

            List<Livro> RecuperarLivros()
            {
                var repository = new LivroRepository();
                return repository.GetAll();
            }

            void ExibirLista(List<Livro> lista)
            {
                Console.WriteLine("Exibindo lista!");
                foreach (var item in lista)
                {
                    Console.WriteLine($"{item.Nome}, Autor: {item.Autor}, Data de Lançamento: {item.Lancamento:dd/MM/yyyy}");
                }
            }

            /*
            void LocarLivro(Solicitante solicitante, Livro livro)
            {
                if (!LivrosEstoque.Contains(livro))
                {
                    Console.WriteLine("Não possuímos este livro");
                    return;
                }
                if (VerificarLocacao(solicitante))
                {
                    if (solicitante.Locacoes.Any(L => CalcularMulta(L) > 0))
                    {
                        Console.WriteLine("Cliente com pendências");
                        return;
                    }
                }

                LivroLocado livroLocado = new LivroLocado(solicitante, livro);
                solicitante.Locacoes.Add(livroLocado);
                LivrosEstoque.Remove(livro);
                Console.WriteLine("Livro: " + livro.Nome + " locado!");
            }

            void DevolverLivro(LivroLocado livroLocado)
            {
                if (CalcularMulta(livroLocado) > 0)
                {
                    Console.WriteLine("Multa de: " + CalcularMulta(livroLocado) + " reais!");
                }

                livroLocado.Solicitante.Locacoes.Remove(livroLocado);
                Livro livro = livroLocado.Livro;
                LivrosEstoque.Add(livro);
                Console.WriteLine("Devolução feita!");
            }

            long CalcularMulta(LivroLocado livroLocado)
            {
                Livro livro = livroLocado.Livro;
                DateTime dataLocacao = livroLocado.DataLocacao;
                DateTime dataAtual = DateTime.Now;
                TimeSpan diferenca = dataAtual - dataLocacao;
                int dias = diferenca.Days;

                if (dias < 30)
                {
                    return 0;
                }
                double multa = livro.Preco * 0.01 * dias;
                return (long)multa;
            }

            bool VerificarLocacao(Solicitante solicitante)
            {
                return solicitante.Locacoes.Any();
            }

            List<Livro> OrdenarLivroData(List<Livro> livros)
            {
                return livros.OrderByDescending(livro => livro.Lancamento).ToList();
            }

            List<Livro> OrdenarLivroAutor(List<Livro> livros)
            {
                return livros.OrderBy(livro => livro.Autor).ToList();
            }
            */
        }
    }
}
