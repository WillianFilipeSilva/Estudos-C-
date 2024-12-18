using System.Collections.Generic;
using System.Linq;
using Estudos_Csharp;
using Microsoft.EntityFrameworkCore;

namespace Estudos_Csharp.Infraestrutura
{
    public class LivroRepository
    {
        private readonly DbConnection _context;

        public LivroRepository()
        {
            _context = new DbConnection();
        }

        public void Add(Livro livro)
        {
            _context.Livros.Add(livro);
            _context.SaveChanges();
        }

        public List<Livro> GetAll()
        {
            return _context.Livros.ToList();
        }
    }
}
