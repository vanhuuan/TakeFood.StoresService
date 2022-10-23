namespace StoreService.Model.Entities.Food;

public class Food:ModelMongoDB
{
    public string Name { get; set; }
    public string StoreId { get; set; }
    public Double Price { get; set; }
    public string Category { get; set; }
    public string ImgUrl { get; set; }
    public string Description { get; set; }
    public bool State { get; set; }
}
