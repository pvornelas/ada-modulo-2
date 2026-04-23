using _03_IEnumerable_ICollection.Models;
using _03_IEnumerable_ICollection.Service;

namespace _03_IEnumerable_ICollection;

class Program
{
    static void Main(string[] args)
    {   
        Console.Clear();

        var listaTransacoes = new List<Transacao>
        {
            new Transacao { Id = Guid.NewGuid(), Valor = 5000m, Categoria = "Saque", Data = new DateTime(2026, 1, 10) },
            new Transacao { Id = Guid.NewGuid(), Valor = 15000m, Categoria = "Depósito", Data = new DateTime(2026, 2, 5) },
            new Transacao { Id = Guid.NewGuid(), Valor = 2000m, Categoria = "Pagamento", Data = new DateTime(2026, 3, 15) },
            new Transacao { Id = Guid.NewGuid(), Valor = 8000m, Categoria = "Saque", Data = new DateTime(2026, 3, 20) },
            new Transacao { Id = Guid.NewGuid(), Valor = 12000m, Categoria = "Saque", Data = new DateTime(2025, 12, 25) },
            new Transacao { Id = Guid.NewGuid(), Valor = 3000m, Categoria = "Saque", Data = new DateTime(2025, 11, 30) },
            new Transacao { Id = Guid.NewGuid(), Valor = 7000m, Categoria = "Depósito", Data = new DateTime(2025, 10, 10) },
            new Transacao { Id = Guid.NewGuid(), Valor = 2500m, Categoria = "Pagamento", Data = new DateTime(2025, 10, 15) },
            new Transacao { Id = Guid.NewGuid(), Valor = 9000m, Categoria = "Pagamento", Data = new DateTime(2025, 9, 20) },
            new Transacao { Id = Guid.NewGuid(), Valor = 11000m, Categoria = "Depósito", Data = new DateTime(2025, 8, 25) }
        };

        var arrayTransacoes = listaTransacoes.ToArray();

        Console.WriteLine("Transações:");
        ImprimirRelatorio(listaTransacoes);

        var fraudes = GerenciadorFinanceiro.FiltrarFraudes(listaTransacoes);
        Console.WriteLine("\nTransações suspeitas fraudes:");
        ImprimirRelatorio(fraudes);

        var saques = GerenciadorFinanceiro.FiltrarPorCategoria(arrayTransacoes, "saque");
        Console.WriteLine("\nTransações de Saque:");
        ImprimirRelatorio(saques);

        var transacoesOrdenadas = GerenciadorFinanceiro.OrdenarPorDataDecrescente(arrayTransacoes);
        Console.WriteLine("\nTransações ordenadas por data decrescente:");
        ImprimirRelatorio(transacoesOrdenadas);

        var saldoTotal = GerenciadorFinanceiro.CalcularSaldoTotal(listaTransacoes);
        Console.WriteLine($"\nSaldo total das transações: {saldoTotal:C2}");
    }

    static void ImprimirRelatorio(IEnumerable<Transacao> transacoes)
    {
        using var enumerator = transacoes.GetEnumerator();
        while (enumerator.MoveNext())
        {
            var transacao = enumerator.Current;
            Console.WriteLine($"Id: {transacao.Id}, "+
                              $"Valor: {transacao.Valor:C2}, " + 
                              $"Categoria: {transacao.Categoria}, " +
                              $"Data: {transacao.Data:dd/MM/yyyy}");
        }
    }
}
