using System.Collections.Generic;
using System.Linq;

namespace Estudos_Csharp.Infraestrutura
{
    public class SolicitanteRepository
    {
        private readonly DbConnection _context;

        public SolicitanteRepository()
        {
            _context = new DbConnection();
        }

        public void Adicionar(Solicitante solicitante)
        {
            _context.Solicitantes.Add(solicitante);
            _context.SaveChanges();
        }

        public List<Solicitante> RecuperarTodos()
        {
            return _context.Solicitantes.ToList();
        }

        public Solicitante RecuperarPorId(int id)
        {
            return _context.Solicitantes.FirstOrDefault(x => x.Id == id);
        }

        public void Atualizar(Solicitante solicitante)
        {
            _context.Solicitantes.Update(solicitante);
            _context.SaveChanges();
        }

        public void Remover(Solicitante solicitante)
        {
            _context.Solicitantes.Remove(solicitante);
            _context.SaveChanges();
        }
    }
}