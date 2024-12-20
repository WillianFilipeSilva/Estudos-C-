using System.Collections.Generic;
using System.Linq;

namespace Estudos_Csharp.Infraestrutura
{
    public class LivroRepository
    {
        private readonly DbConnection _context;

        public LivroRepository()
        {
            _context = new DbConnection();
        }

        public void Adicionar(Livro livro)
        {
            _context.Livros.Add(livro);
            _context.SaveChanges();
        }

        public List<Livro> RecuperarTodos()
        {
            return _context.Livros.ToList();
        }

        public Livro RecuperarPorId(int id)
        {
            return _context.Livros.FirstOrDefault(x => x.Id == id);
        }

        public void Atualizar(Livro livro)
        {
            _context.Livros.Update(livro);
            _context.SaveChanges();
        }

        public void Remover(Livro livro)
        {
            _context.Livros.Remove(livro);
            _context.SaveChanges();
        }
    }
}