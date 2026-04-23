namespace _04_Cafe_Tech.Services;

public class CozinhaService
{
    public async Task PrepararCafeAsync(string nomeCafe)
    {
        Console.WriteLine($"Iniciando preparo de {nomeCafe}...");
        await Task.Delay(3000);
        Console.WriteLine($"{nomeCafe} esta pronto!");
    }
}
