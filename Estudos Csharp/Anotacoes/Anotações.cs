using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Estudos_Csharp.Anotacoes
{
    /*
    Ctrl + K, Ctrl + D
    Passos:
    Pressione e segure Ctrl.
    Aperte K.
    Depois, ainda segurando Ctrl, aperte D.
    */
    public class LinqExemplos
    {
        public void ExecutarExemplos()
        {
            var numeros = new List<int> { 1, 2, 3, 4, 5, 5, 3, 2 };
            var nomes = new List<string> { "Willian", "João", "Maria", "Ana", "André", "Bruna" };
            var lista1 = new List<int> { 1, 2, 3 };
            var lista2 = new List<int> { 3, 4, 5 };

            // 1. Where
            var pares = numeros.Where(n => n % 2 == 0);

            // 2. Select
            var quadrados = numeros.Select(n => n * n);

            // 3. OrderBy e OrderByDescending
            var ascendente = numeros.OrderBy(n => n);
            var descendente = numeros.OrderByDescending(n => n);

            // 4. GroupBy
            var agrupados = nomes.GroupBy(nome => nome[0]);

            // 5. Join
            var idades = new List<int> { 22, 30, 27 };
            var nomesComIdade = nomes.Join(idades, n => nomes.IndexOf(n), i => idades.IndexOf(i),
                                           (n, i) => new { Nome = n, Idade = i });

            // 6. First e FirstOrDefault
            var primeiro = numeros.First();
            var nenhum = numeros.Where(n => n > 10).FirstOrDefault();

            // 7. Single e SingleOrDefault
            var unico = numeros.Where(n => n == 3).SingleOrDefault();

            // 8. Take e Skip
            var primeiros3 = numeros.Take(3);
            var ignorar2 = numeros.Skip(2);

            // 9. Count
            var total = numeros.Count();

            // 10. Sum, Average, Max, Min
            var soma = numeros.Sum();
            var media = numeros.Average();
            var maximo = numeros.Max();
            var minimo = numeros.Min();

            // 11. Any e All
            var temPares = numeros.Any(n => n % 2 == 0);
            var todosPositivos = numeros.All(n => n > 0);

            // 12. Distinct
            var unicos = numeros.Distinct();

            // 13. Union, Intersect e Except
            var uniao = lista1.Union(lista2);
            var intersecao = lista1.Intersect(lista2);
            var diferenca = lista1.Except(lista2);

            // 14. Aggregate
            var acumulado = numeros.Aggregate((total, n) => total + n);

            // Exibindo os resultados
            Console.WriteLine("1. Where: " + string.Join(", ", pares));
            Console.WriteLine("2. Select: " + string.Join(", ", quadrados));
            Console.WriteLine("3. OrderBy: " + string.Join(", ", ascendente));
            Console.WriteLine("   OrderByDescending: " + string.Join(", ", descendente));
            Console.WriteLine("4. GroupBy:");
            foreach (var grupo in agrupados)
            {
                Console.WriteLine($"  Letra {grupo.Key}: {string.Join(", ", grupo)}");
            }
            Console.WriteLine("5. Join:");
            foreach (var item in nomesComIdade)
            {
                Console.WriteLine($"  {item.Nome} - {item.Idade}");
            }
            Console.WriteLine("6. First: " + primeiro);
            Console.WriteLine("   FirstOrDefault: " + nenhum);
            Console.WriteLine("7. SingleOrDefault: " + unico);
            Console.WriteLine("8. Take: " + string.Join(", ", primeiros3));
            Console.WriteLine("   Skip: " + string.Join(", ", ignorar2));
            Console.WriteLine("9. Count: " + total);
            Console.WriteLine("10. Sum: " + soma + ", Average: " + media + ", Max: " + maximo + ", Min: " + minimo);
            Console.WriteLine("11. Any: " + temPares + ", All: " + todosPositivos);
            Console.WriteLine("12. Distinct: " + string.Join(", ", unicos));
            Console.WriteLine("13. Union: " + string.Join(", ", uniao));
            Console.WriteLine("    Intersect: " + string.Join(", ", intersecao));
            Console.WriteLine("    Except: " + string.Join(", ", diferenca));
            Console.WriteLine("14. Aggregate: " + acumulado);
        }

        public static void Main(string[] args)
        {
            LinqExemplos exemplos = new LinqExemplos();
            exemplos.ExecutarExemplos();
            Console.ReadKey();
        }
    }
}
