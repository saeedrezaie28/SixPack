namespace SixPack.Domain.Entity;

public class Comment
{
    public int ID { get; set; }
    public string CommentText { get; set; }
    public int UserID { get; set; }
    //public User User { get; set; }
    public int ProductID { get; set; }
    //public Product Product { get; set; }
    public DateTime CreateTime { get; set; }
}

