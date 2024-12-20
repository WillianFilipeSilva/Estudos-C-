using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Estudos_Csharp
{
    [Table("LivrosLocados")]
    public class LivroLocado
    {
        public LivroLocado() { }

        public LivroLocado(Solicitante solicitante, Livro livro)
        {
            if (solicitante == null)
                throw new Exception("Solicitante é obrigatório!");

            if (livro == null)
                throw new Exception("Livro é obrigatório!");

            Solicitante = solicitante;
            Livro = livro;
            DataLocacao = DateTime.UtcNow;
        }

        [Key]
        public int Id { get; set; }

        public int SolicitanteId { get; set; }
        [ForeignKey("SolicitanteId")]
        public Solicitante Solicitante { get; set; }

        public int LivroId { get; set; }
        [ForeignKey("LivroId")]
        public Livro Livro { get; set; }

        public DateTime DataLocacao { get; set; }
    }
}