using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;

namespace Estudos_Csharp.Infraestrutura
{
    internal class LivroRepository
    {
        public bool Add(Livro livro)
        {
            using var conn = new DbConnection();

            string query = @"INSERT INTO public.livros(
	                        nome, autor, preco, lancamento)
	                        VALUES (@nome, @autor, @preco, @lancamento);";

            var result = conn.Connection.Execute(sql: query, param: livro);

            return result == 1;
        }

        public List<Livro> GetAll()
        {
            using var conn = new DbConnection();

            string query = @"SELECT * FROM public.livros;";

            var livros = conn.Connection.Query<Livro>(sql: query);

            return livros.ToList();
        }
    }
}
