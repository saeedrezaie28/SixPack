namespace SixPack.Domain;
public class Product
{
    public int ID { get; set; }
    public string Title { get; set; }
    public string Color { get; set; }
    public int Price { get; set; }
    public string Desc { get; set; }
    public string Slag { get; set; }
    public int CategoryID { get; set; }
    public Category Category { get; set; }
    public List<Comment> Comments { get; set; }
    public List<ProdcutImage> Images { get; set; }
}
