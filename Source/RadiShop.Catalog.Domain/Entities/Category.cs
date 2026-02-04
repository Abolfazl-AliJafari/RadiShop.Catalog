namespace RadiShop.Catalog.Domain.Entities;

public class Category
{
    public Guid Id { get; init; }
    public string Title { get; private set; } = null!;
    public Category? Parent { get; private set; }
    public Guid? ParentId { get; private set; }
    public string? Path => GetPath(this);

    private string? GetPath(Category category)
    {
        if (category.ParentId is not null)
            return $"{GetPath(category.Parent!)}/{category.Title}";
        return Id == category.Id ? null : category.Title;
    }
    
    public void Update(string title) => Title = title;
    
    public static Category Create(string title, Guid? parentId = null) => new() { Title = title, ParentId = parentId };
    public ICollection<Category> Childrens { get; private set; } = null!;

}