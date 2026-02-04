namespace RadiShop.Catalog.Domain.Entities;

public class Brand
{
    public Guid Id { get; init; }
    public string Title { get; private set; } = null!;
    
    public void Update(string title) => Title = title;
    
    public static Brand Create(string title) => new() { Title = title };
}