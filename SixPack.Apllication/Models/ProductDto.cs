namespace SixPack.Domain.Entity;
public class ProductDto
{
    public string Title { get; set; }
    public string Color { get; set; }
    public int Price { get; set; }
    public string? Desc { get; set; }
    public string? Slag { get; set; }
    public int CategoryID { get; set; }
    public ProdcutImageDto? IndexImage { get; set; }
    public List<ProdcutImageDto>? Images { get; set; }
}
