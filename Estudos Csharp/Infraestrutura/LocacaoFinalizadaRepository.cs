using System.Collections.Generic;
using System.Linq;

namespace Estudos_Csharp.Infraestrutura
{
    public class LocacaoFinalizadaRepository
    {
        private readonly DbConnection _context;

        public LocacaoFinalizadaRepository()
        {
            _context = new DbConnection();
        }

        public void Adicionar(LocacaoFinalizada locacaoFinalizada)
        {
            _context.LocacoesFinalizadas.Add(locacaoFinalizada);
            _context.SaveChanges();
        }

        public List<LocacaoFinalizada> RecuperarTodos()
        {
            return _context.LocacoesFinalizadas.ToList();
        }

        public LocacaoFinalizada RecuperarPorId(int id)
        {
            return _context.LocacoesFinalizadas.FirstOrDefault(x => x.Id == id);
        }

        public void Atualizar(LocacaoFinalizada locacaoFinalizada)
        {
            _context.LocacoesFinalizadas.Update(locacaoFinalizada);
            _context.SaveChanges();
        }

        public void Remover(LocacaoFinalizada locacaoFinalizada)
        {
            _context.LocacoesFinalizadas.Remove(locacaoFinalizada);
            _context.SaveChanges();
        }
    }
}