using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Estudos_Csharp.Infraestrutura
{
    public class SolicitanteRepository
    {
        private readonly DbConnection _context = new DbConnection();

        public void Add(Solicitante solicitante)
        {
            _context.Solicitantes.Add(solicitante);
            _context.SaveChanges();
        }

        public List<Solicitante> GetAll()
        {
            return _context.Solicitantes.ToList();
        }
    }
}
