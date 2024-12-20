using System.Collections.Generic;
using System.Linq;

namespace Estudos_Csharp.Infraestrutura
{
    public class LivroLocadoRepository
    {
        private readonly DbConnection _context;

        public LivroLocadoRepository()
        {
            _context = new DbConnection();
        }

        public void Adicionar(LivroLocado livroLocado)
        {
            _context.LivrosLocados.Add(livroLocado);
            _context.SaveChanges();
        }

        public List<LivroLocado> RecuperarTodos()
        {
            return _context.LivrosLocados.ToList();
        }

        public LivroLocado RecuperarPorId(int id)
        {
            return _context.LivrosLocados.FirstOrDefault(x => x.Id == id);
        }

        public void Atualizar(LivroLocado livroLocado)
        {
            _context.LivrosLocados.Update(livroLocado);
            _context.SaveChanges();
        }

        public void Remover(LivroLocado livroLocado)
        {
            _context.LivrosLocados.Remove(livroLocado);
            _context.SaveChanges();
        }
    }
}