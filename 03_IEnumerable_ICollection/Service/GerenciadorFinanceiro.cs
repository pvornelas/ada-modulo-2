using _03_IEnumerable_ICollection.Models;

namespace _03_IEnumerable_ICollection.Service;

public static class GerenciadorFinanceiro
{
    public static IEnumerable<Transacao> FiltrarFraudes(IEnumerable<Transacao> transacoes)
    {
        return transacoes.Where(t => t.Valor > 10000);
    }

    public static IEnumerable<Transacao> FiltrarPorCategoria(IEnumerable<Transacao> transacoes, string categoria)
    {
        return transacoes.Where(t => t.Categoria.Equals(categoria, StringComparison.InvariantCultureIgnoreCase));
    }

    public static IEnumerable<Transacao> OrdenarPorDataDecrescente(IEnumerable<Transacao> transacoes)
    {
        return transacoes.OrderByDescending(t => t.Data);
    }

    public static decimal CalcularSaldoTotal(IEnumerable<Transacao> transacoes)
    {
        return transacoes.Sum(t => t.Valor);
    }
}
