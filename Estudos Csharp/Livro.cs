using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Estudos_Csharp
{

    [Table("Livros")]
    public class Livro
    {

        public Livro() { }

        public Livro(string nome, string autor, DateTime lancamento, double preco)
        {

            if (string.IsNullOrEmpty(nome))
            {
                throw new Exception("Nome é obrigatório!");
            }

            if (string.IsNullOrEmpty(autor))
            {
                throw new Exception("Autor é obrigatório!");
            }

            Nome = nome;
            Autor = autor;
            Lancamento = DateTime.SpecifyKind(lancamento, DateTimeKind.Utc);
            Preco = preco;
        }

        [Key]
        public int Id { get; private set; }
        public String Nome { get; set; }
        public String Autor { get; set; }
        public DateTime Lancamento { get; set; }
        public double Preco { get; set; }
    }
}
