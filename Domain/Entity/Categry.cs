namespace SixPack.Domain.Entity;

public class Category
{
    public int ID { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }
    List<Product> Products { get; set; }
}

