using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Estudos_Csharp
{
    [Table("LivrosEstoque")]
    public class LivroEstoque
    {
        public LivroEstoque() { }

        public LivroEstoque(Livro livro, int quantidade)
        {
            if (livro == null)
                throw new Exception("Livro é obrigatório!");

            if (quantidade < 0)
                throw new Exception("Quantidade não pode ser negativa!");

            Livro = livro;
            Quantidade = quantidade;
        }

        [Key]
        public int Id { get; set; }

        public int LivroId { get; set; }

        [ForeignKey("LivroId")]
        public Livro Livro { get; set; }

        public int Quantidade { get; set; }
    }
}