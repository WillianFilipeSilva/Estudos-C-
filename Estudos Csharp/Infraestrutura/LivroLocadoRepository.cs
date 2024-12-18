using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Estudos_Csharp.Infraestrutura
{
    public class LivroLocadoRepository
    {
        private readonly DbConnection _context = new DbConnection();

        public void Add(LivroLocado livroLocado)
        {
            _context.LivrosLocados.Add(livroLocado);
            _context.SaveChanges();
        }

        public List<LivroLocado> GetAll()
        {
            return _context.LivrosLocados.ToList();
        }
    }
}
