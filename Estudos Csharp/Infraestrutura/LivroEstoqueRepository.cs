using System.Collections.Generic;
using System.Linq;

namespace Estudos_Csharp.Infraestrutura
{
    public class LivroEstoqueRepository
    {
        private readonly DbConnection _context;

        public LivroEstoqueRepository()
        {
            _context = new DbConnection();
        }

        public void Adicionar(LivroEstoque livroEstoque)
        {
            _context.LivrosEstoque.Add(livroEstoque);
            _context.SaveChanges();
        }

        public List<LivroEstoque> RecuperarTodos()
        {
            return _context.LivrosEstoque.ToList();
        }

        public LivroEstoque RecuperarPorId(int id)
        {
            return _context.LivrosEstoque.FirstOrDefault(x => x.Id == id);
        }

        public LivroEstoque RecuperarPorIdDoLivro(int livroId)
        {
            return _context.LivrosEstoque.FirstOrDefault(x => x.LivroId == livroId);
        }

        public void Atualizar(LivroEstoque livroEstoque)
        {
            _context.LivrosEstoque.Update(livroEstoque);
            _context.SaveChanges();
        }

        public void Remover(LivroEstoque livroEstoque)
        {
            _context.LivrosEstoque.Remove(livroEstoque);
            _context.SaveChanges();
        }

        public List<LivroEstoque> ConsultarLivroPorNome(string nome)
        {
            return _context.LivrosEstoque
                .Where(le => le.Livro.Nome.Contains(nome))
                .ToList();
        }
    }
}