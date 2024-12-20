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
            var livroRepo = new LivroRepository();
            var estoqueRepo = new LivroEstoqueRepository();
            var solicitanteRepo = new SolicitanteRepository();
            var livroLocadoRepo = new LivroLocadoRepository();
            var locacaoFinalizadaRepo = new LocacaoFinalizadaRepository();

            var livro1 = new Livro("Harry Potter", "J.K Rowling", new DateTime(1997, 6, 26), 20.00);
            var livro2 = new Livro("O Hobbit", "J.R.R Tolkien", new DateTime(1937, 9, 21), 15.00);
            var livro3 = new Livro("The Lord of the Rings", "J.R.R Tolkien", new DateTime(1954, 7, 29), 25.00);
            var livro4 = new Livro("O Fantasma da Ópera", "Gaston Leroux", new DateTime(2024, 11, 10), 75.00);

            var livroEstoque1 = new LivroEstoque(livro1, 10);
            var livroEstoque2 = new LivroEstoque(livro2, 5);
            var livroEstoque3 = new LivroEstoque(livro3, 2);
            var livroEstoque4 = new LivroEstoque(livro4, 1);

            List<LivroEstoque> LivrosEstoque = new List <LivroEstoque>
            {
                livroEstoque1, livroEstoque2, livroEstoque3, livroEstoque4
            };

            SalvarListaDeLivrosEstoque(LivrosEstoque);

            var solicitante1 = new Solicitante("Augusto", "(47) 1234-56789");
            var solicitante2 = new Solicitante("Angela", "(47) 1234-56789");

            solicitanteRepo.Adicionar(solicitante1);
            solicitanteRepo.Adicionar(solicitante2);

            LocarLivro(solicitante1, livro2);
            LocarLivro(solicitante2, livro2);

            Console.WriteLine("Estoque após locações:");
            ExibirEstoque(estoqueRepo.RecuperarTodos());

            var livroLocadoAugusto = solicitante1.Locacoes.FirstOrDefault(); 
            DevolverLivro(livroLocadoAugusto);
            
            Console.WriteLine("Estoque após devolução:");
            ExibirEstoque(estoqueRepo.RecuperarTodos());

            Console.WriteLine("Busca por nome 'Lord':");
            var resultadoBusca = estoqueRepo.ConsultarLivroPorNome("Lord");
            ExibirEstoque(resultadoBusca);

            Console.WriteLine("Livros Ordenados por Autor:");
            ExibirListaDeLivros(OrdenarLivrosPorAutor(livroRepo.RecuperarTodos()));

            Console.WriteLine("Livros Ordenados por Data de Lançamento:");
            ExibirListaDeLivros(OrdenarLivroData(livroRepo.RecuperarTodos()));

            // Funções
            void SalvarListaDeLivrosEstoque(List<LivroEstoque> Lista)
            {
                foreach (var item in LivrosEstoque)
                {
                    estoqueRepo.Adicionar(item);
                }
            }

            void LocarLivro(Solicitante solicitante, Livro livro)
            {
                var est = estoqueRepo.RecuperarPorIdDoLivro(livro.Id);
                if (est == null || est.Quantidade <= 0)
                {
                    Console.WriteLine("Livro indisponível no estoque para locação!");
                    return;
                }

                if (VerificarLocacao(solicitante))
                {
                    if (solicitante.Locacoes.Any(L => CalcularMulta(L) > 0))
                    {
                        Console.WriteLine("Cliente com pendências de multa.");
                        return;
                    }
                }

                var livroLocado = new LivroLocado(solicitante, livro);
                solicitante.Locacoes.Add(livroLocado);
                livroLocadoRepo.Adicionar(livroLocado);

                est.Quantidade -= 1;
                estoqueRepo.Atualizar(est);

                Console.WriteLine("Livro: " + livro.Nome + " locado para " + solicitante.Nome);
            }

            void DevolverLivro(LivroLocado livroLocado)
            {
                long multa = CalcularMulta(livroLocado);
                if (multa > 0)
                    Console.WriteLine("Multa de: " + multa + " reais!");

                var locacaoFinalizada = new LocacaoFinalizada(livroLocado.Solicitante, livroLocado, multa);
                locacaoFinalizadaRepo.Adicionar(locacaoFinalizada);
                livroLocado.Solicitante.LocacoesFinalizadas.Add(locacaoFinalizada);

                livroLocado.Solicitante.Locacoes.Remove(livroLocado);

                var est = estoqueRepo.RecuperarPorIdDoLivro(livroLocado.LivroId);
                if (est != null)
                {
                    est.Quantidade += 1;
                    estoqueRepo.Atualizar(est);
                }

                var livroLocadoRepoAux = new LivroLocadoRepository();
                livroLocadoRepoAux.Remover(livroLocado);

                Console.WriteLine("Devolução feita!");
            }

            long CalcularMulta(LivroLocado livroLocado)
            {
                var livroCarregado = livroRepo.RecuperarPorId(livroLocado.LivroId);
                DateTime dataLocacao = livroLocado.DataLocacao;
                DateTime dataAtual = DateTime.Now;
                TimeSpan diferenca = dataAtual - dataLocacao;
                int dias = diferenca.Days;

                if (dias < 30)
                    return 0;

                double multa = livroCarregado.Preco * 0.01 * dias;
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

            List<Livro> OrdenarLivrosPorAutor(List<Livro> livros)
            {
                return livros.OrderBy(livro => livro.Autor).ToList();
            }

            void ExibirListaDeLivros(List<Livro> lista)
            {
                foreach (var item in lista)
                    Console.WriteLine($"{item.Nome}, Autor: {item.Autor}, Data: {item.Lancamento:dd/MM/yyyy}");
            }

            void ExibirEstoque(List<LivroEstoque> estoques)
            {
                foreach (var e in estoques)
                    Console.WriteLine($"Livro: {e.Livro.Nome} - Qtd: {e.Quantidade}");
            }
        }
    }
}
