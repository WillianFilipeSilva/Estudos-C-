using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Estudos_Csharp
{
    internal class Solicitante
    {
        private long id {  get; set; }
        private String nome {  get; set; }
        private String telefone { get; set; }
        private List<Livro> livrosLocados { get; set; }
        public Solicitante(string nome, string telefone, List<Livro> livrosLocados)
        {
            this.nome = nome;
            this.telefone = telefone;
            this.livrosLocados = livrosLocados;
        }
    }
}
