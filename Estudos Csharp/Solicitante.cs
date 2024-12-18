using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Estudos_Csharp
{

    [Table("Solicitantes")]
    public class Solicitante
    {

        public Solicitante() { }

        public Solicitante(string nome, string telefone)
        {

            if (string.IsNullOrEmpty(nome))
            {
                throw new ArgumentException("Nome é obrigatório!", nameof(nome));
            }

            if (string.IsNullOrEmpty(telefone))
            {
                throw new ArgumentException("Telefone é obrigatório!", nameof(telefone));
            }

            Nome = nome;
            Telefone = telefone;
            Locacoes = new List<LivroLocado>();
        }

        [Key]
        public int Id { get; private set; }

        [Required]
        [MaxLength(100)]
        public string Nome { get; set; }

        [Required]
        [MaxLength(15)]
        public string Telefone { get; set; }

        public List<LivroLocado> Locacoes { get; set; }
    }
}