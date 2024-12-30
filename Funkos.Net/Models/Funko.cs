namespace Funkos.Net.models;

public class Funko
{
    public long Id { get; set; } = 0;
    public string Name { get; set; }
    public string Categoria { get; set; }
    public Double precio { get; set; }
    public bool IsDeleted { get; set; } = false;
    public DateTime CreatedAt { get; set; } = DateTime.Now;
    public DateTime UpdatedAt { get; set; } = DateTime.Now;
}