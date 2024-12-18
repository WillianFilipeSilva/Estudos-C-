using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Estudos_Csharp
{
    internal class Livro
    {
        private long id { get; set; }
        private String nome { get; set; }
        private String autor { get; set; }
        private DateTime lancamento { get; set; }
        private double preco { get; set; }
        public Livro(string nome, string autor, DateTime lancamento, double preco)
        {
            this.nome = nome;
            this.autor = autor;
            this.lancamento = lancamento;
            this.preco = preco;
        }
    }
}
