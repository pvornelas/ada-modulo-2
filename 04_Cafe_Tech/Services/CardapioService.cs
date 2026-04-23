namespace _04_Cafe_Tech.Services;

public class CardapioService
{
    private readonly Dictionary<int, string> _cardapio;

    public CardapioService()
    {
        _cardapio = new Dictionary<int, string>
        {
            { 1, "Cafe Expresso" },
            { 2, "Cappuccino" },
            { 3, "Latte" }
        };
    }

    public IEnumerable<KeyValuePair<int, string>> ObterCardapio() => _cardapio;

    public void ExibirCardapio()
    {
        Console.WriteLine("=== Cardapio ===");
        foreach (var item in ObterCardapio())
        {
            Console.WriteLine($"{item.Key}. {item.Value} - {ObterPrecoProduto(item.Key):C2}");
        }
    }

    public bool TryObterProduto(int codigo, out string nome, out decimal preco)
    {
        if (_cardapio.TryGetValue(codigo, out nome!))
        {
            preco = ObterPrecoProduto(codigo);
            return true;
        }

        nome = string.Empty;
        preco = 0m;
        return false;
    }

    public decimal ObterPrecoProduto(int codigo)
    {
        return codigo switch
        {
            1 => 8.50m,
            2 => 18.90m,
            3 => 15.50m,
            _ => throw new ArgumentException("Codigo de produto invalido.")
        };
    }
}
