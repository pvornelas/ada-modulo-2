namespace _03_IEnumerable_ICollection.Models;

public class Transacao
{
    public Guid Id { get; set; }
    public decimal Valor { get; set; }
    public string Categoria { get; set; } = default!;
    public DateTime Data { get; set; }
}