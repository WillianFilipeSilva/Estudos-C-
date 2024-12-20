using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Estudos_Csharp
{
    [Table("LocacoesFinalizadas")]
    public class LocacaoFinalizada
    {
        public LocacaoFinalizada() { }

        public LocacaoFinalizada(Solicitante solicitante, LivroLocado livroLocado, long multa)
        {
            if (solicitante == null)
                throw new Exception("Solicitante é obrigatório!");

            if (livroLocado == null)
                throw new Exception("LivroLocado é obrigatório!");

            Solicitante = solicitante;
            LivroLocado = livroLocado;
            DataDevolucao = DateTime.UtcNow;
            Multa = multa;
        }

        [Key]
        public int Id { get; set; }

        public int SolicitanteId { get; set; }
        [ForeignKey("SolicitanteId")]
        public Solicitante Solicitante { get; set; }

        public int LivroLocadoId { get; set; }
        [ForeignKey("LivroLocadoId")]
        public LivroLocado LivroLocado { get; set; }

        public DateTime DataDevolucao { get; set; }
        public long Multa { get; set; }
    }
}