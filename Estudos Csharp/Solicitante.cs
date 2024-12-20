using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Estudos_Csharp
{
    [Table("Solicitantes")]
    public class Solicitante
    {
        public Solicitante()
        {
            Locacoes = new List<LivroLocado>();
            LocacoesFinalizadas = new List<LocacaoFinalizada>();
        }

        public Solicitante(string nome, string telefone)
        {
            if (string.IsNullOrEmpty(nome))
                throw new ArgumentException("Nome é obrigatório!", nameof(nome));

            if (string.IsNullOrEmpty(telefone))
                throw new ArgumentException("Telefone é obrigatório!", nameof(telefone));

            Nome = nome;
            Telefone = telefone;
            Locacoes = new List<LivroLocado>();
            LocacoesFinalizadas = new List<LocacaoFinalizada>();
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
        public List<LocacaoFinalizada> LocacoesFinalizadas { get; set; }
    }
}