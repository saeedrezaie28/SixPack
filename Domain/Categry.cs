namespace SixPack.Domain;

public class Category
{
    public int ID { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }
    List<Product> Products { get; set; }
}

