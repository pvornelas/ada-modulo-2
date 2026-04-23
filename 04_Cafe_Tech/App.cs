using _04_Cafe_Tech.Services;
using _04_Cafe_Tech.Utils;

namespace _04_Cafe_Tech;

public class App
{
    private readonly CardapioService _cardapioService;
    private readonly CarrinhoService _carrinhoService;
    private readonly CozinhaService _cozinhaService;

    public App()
    {
        _cardapioService = new CardapioService();
        _cozinhaService = new CozinhaService();
        _carrinhoService = new CarrinhoService();
    }

    public async Task RunAsync()
    {
        while (true)
        {
            Console.Clear();
            ConsoleHelper.ExibirCabecalho("Cafe Tech");

            Console.WriteLine("1. Fazer pedido");
            Console.WriteLine("2. Sair");

            int opcao = ConsoleHelper.LerOpcao("Escolha uma opcao: ");

            switch (opcao)
            {
                case 1:
                    var cafesPedido = FazerPedido();
                    await FinalizarPedidoAsync(cafesPedido);
                    ConsoleHelper.AguardarContinuacao();
                    break;
                case 2:
                    Console.WriteLine("Obrigado por visitar o Cafe Tech! Volte sempre!");
                    return;
                default:
                    Console.WriteLine("Opcao invalida.");
                    ConsoleHelper.AguardarContinuacao();
                    break;
            }
        }
    }

    public ICollection<string> FazerPedido()
    {
        var cafesPedido = new List<string>();

        while (true)
        {
            Console.Clear();
            ConsoleHelper.ExibirCabecalho("Fazer Pedido");

            _cardapioService.ExibirCardapio();

            int codigoProduto = ConsoleHelper.LerOpcao("Digite o codigo do produto para adicionar ao carrinho: ");

            if (!_cardapioService.TryObterProduto(codigoProduto, out var nome, out var preco))
            {
                Console.WriteLine("Produto nao encontrado.");
                ConsoleHelper.AguardarContinuacao();
                continue;
            }

            _carrinhoService.AdicionarPreco(preco);
            cafesPedido.Add(nome);
            Console.WriteLine($"{nome} adicionado ao carrinho por {preco:C2}.");

            var desejaAdicionarMais = ConsoleHelper.LerConfirmacao("Deseja adicionar mais itens? (s/n): ");
            if (!desejaAdicionarMais)
                break;
        }        

        return cafesPedido;
    }

    public async Task FinalizarPedidoAsync(IEnumerable<string> cafesPedido)
    {
        if (!_carrinhoService.TemItens())
        {
            Console.WriteLine("O carrinho esta vazio.");
            return;
        }

        _carrinhoService.ExibirResumo();

        var confirmaPagamento = ConsoleHelper.LerConfirmacao("Confirma o pagamento? (s/n): ");
        if (!confirmaPagamento)
        {
            Console.WriteLine("Pagamento cancelado.");
            return;
        }

        ICollection<Task> preparos = new List<Task>();
        foreach (var cafe in cafesPedido)
        {
            var tarefa = _cozinhaService.PrepararCafeAsync(cafe);
            preparos.Add(tarefa);
        }
           
        var querNoticias = ConsoleHelper.LerConfirmacao("Gostaria de ler as noticias enquanto espera? (s/n): ");
        if (querNoticias)
        {
            ConsoleHelper.ExibirNoticias();
        }

        await Task.WhenAll(preparos);

        _carrinhoService.LimparCarrinho();
    }
}
