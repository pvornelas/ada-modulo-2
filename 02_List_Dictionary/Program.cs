namespace _02_List_Dictionary;

class Program
{
    static void Main(string[] args)
    {
        var tracos = new string('-', 20);
        #region [Cenário A - Localizador de Correntistas]
        Console.WriteLine($"{tracos}Cenário A - Localizador de Correntistas{tracos}");
        var correntistas = new Dictionary<int, string> 
        {    
            {5001, "João"}
        };

        Console.WriteLine("Adicionando correntistas...");
        correntistas.Add(5002, "Ana");
        correntistas.Add(5003, "Carlos");
        correntistas.Add(5004, "Fernanda");

        Console.WriteLine("Exibindo correntistas adicionados:");
        foreach(var correntista in correntistas)
        {
            Console.WriteLine($"Conta: {correntista.Key}, Titular: {correntista.Value}");
        }        

        Console.WriteLine("Buscando correntista da conta 5003...");
        if(correntistas.TryGetValue(5003, out string? nomeCorrentista))
        {
            Console.WriteLine($"Titular da conta 5003: {nomeCorrentista}");
        }
        else
        {
            Console.WriteLine("Correntista não encontrado.");
        }

         Console.WriteLine("Buscando correntista da conta 00000...");
        if(correntistas.TryGetValue(00000, out string? naoExistente))
        {
            Console.WriteLine($"Titular da conta 00000: {naoExistente}");
        }
        else
        {
            Console.WriteLine("Correntista não encontrado.");
        }

        Console.WriteLine("Removendo correntista da conta 5002...");
        correntistas.Remove(5002);

        Console.WriteLine("Exibindo correntistas restantes:");
        foreach(var correntista in correntistas)
        {
            Console.WriteLine($"Conta: {correntista.Key}, Titular: {correntista.Value}");
        }
        #endregion

        #region [Cenário B - Fluxo de Caixa]
        Console.WriteLine($"{tracos}Cenário B - Fluxo de Caixa{tracos}");
        var depositos = new List<decimal>() { 
            1500.00m, 
            2000.00m, 
            750.00m 
        };

        Console.WriteLine("Registrando depósitos...");
        depositos.Add(1000.00m);
        depositos.Add(2500.00m);

        Console.WriteLine("Exibindo depósitos registrados:");
        for(int i = 0; i < depositos.Count; i++)
        {
            Console.WriteLine($"Depósito [{i + 1}]: {depositos[i]:C}");
        }

        Console.WriteLine("Removendo quarto depósito:");
        if(depositos.Count > 3)
        {
            depositos.RemoveAt(3);
        }

        Console.WriteLine("Exibindo depósitos restantes:");
        for(int i = 0; i < depositos.Count; i++)
        {
            Console.WriteLine($"Depósito [{i + 1}]: {depositos[i]:C}");
        }
        #endregion

        #region [Cenário C - Auditoria de erros]
        Console.WriteLine($"{tracos}Cenário C - Auditoria de erros{tracos}");
        int registrosProcessados = 0;
        decimal valorTotalProcessado = 0.00m;

        for (int i = 0; i < depositos.Count; i++)
        {            
            valorTotalProcessado += depositos[i];
            registrosProcessados++;
            Console.WriteLine($"Processando depósito [{i + 1}]: {depositos[i]:C}");
        }
        
        Console.WriteLine($"Registros processados: {registrosProcessados}");
        Console.WriteLine($"Valor total processado: {valorTotalProcessado:C}");

        // Versão com LINQ
        // int registrosProcessadosLinq = depositos.Count;
        // decimal valorTotalProcessadoLinq = depositos.Sum();
        // Console.WriteLine($"Registros processados: {registrosProcessadosLinq}");
        // Console.WriteLine($"Valor total processado: {valorTotalProcessadoLinq:C}");
        #endregion
    }
}
