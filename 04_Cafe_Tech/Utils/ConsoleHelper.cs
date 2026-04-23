namespace _04_Cafe_Tech.Utils;

public static class ConsoleHelper
{
    public static void ExibirCabecalho(string titulo)
    {
        var tracos = new string('=', 30);
        Console.WriteLine($"{tracos} {titulo} {tracos}");
    }

    public static int LerOpcao(string mensagem)
    {
        while (true)
        {
            Console.Write(mensagem);

            if (int.TryParse(Console.ReadLine(), out int opcao))
                return opcao;

            Console.WriteLine("Digite um numero valido.");
        }
    }

    public static bool LerConfirmacao(string mensagem)
    {
        while (true)
        {
            Console.Write(mensagem);
            var resposta = Console.ReadLine()?.Trim();

            if (string.Equals(resposta, "s", StringComparison.InvariantCultureIgnoreCase))
                return true;

            if (string.Equals(resposta, "n", StringComparison.InvariantCultureIgnoreCase))
                return false;

            Console.WriteLine("Resposta invalida. Digite apenas 's' ou 'n'.");
        }
    }

    public static void AguardarContinuacao()
    {
        Console.WriteLine();
        Console.WriteLine("Pressione qualquer tecla para continuar...");
        Console.ReadKey();
    }

    public static void ExibirNoticias()
    {
        Console.WriteLine("=== Noticias do Dia ===");
        Console.WriteLine("- Nova cafeteria abre no centro da cidade.");
        Console.WriteLine("- Cafe Tech foi eleito o melhor cafe da regiao.");
        Console.WriteLine("- Dicas para preparar o cafe perfeito em casa.");
        Console.WriteLine("- Tendencias do mercado de cafes especiais.");
    }
}
