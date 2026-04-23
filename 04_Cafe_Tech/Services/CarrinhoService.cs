namespace _04_Cafe_Tech.Services;

public class CarrinhoService
{
    private readonly List<decimal> _precos;

    public CarrinhoService()
    {
        _precos = new List<decimal>();
    }

    public void AdicionarPreco(decimal preco) => _precos.Add(preco);
    public bool TemItens() => _precos.Count > 0;    
    public void ExibirResumo()
    {
        var qtdItens = _precos.Count;
        var totalBruto = _precos.Sum();
        Func<decimal, decimal> aplicarDesconto = total => total > 50m ? total * 0.9m : total;

        Console.WriteLine("==== Resumo do Pedido ==== ");
        Console.WriteLine($"Quantidade de itens: {qtdItens}");
        Console.WriteLine($"Valor Total: {totalBruto:C2}");

        decimal totalComDesconto = aplicarDesconto(totalBruto);
        if(totalComDesconto < totalBruto)
        {
            Console.WriteLine($"Total com desconto de 10%: {totalComDesconto:C2}");
        }
    }

    public void LimparCarrinho()
    {
        _precos.Clear();
    }
}
