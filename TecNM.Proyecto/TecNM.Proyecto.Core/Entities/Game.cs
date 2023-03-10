namespace TecNM.Proyecto.Core.Entities;

public class Game : EntityBase
{
    public string idGame { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public double Price { get; set; }
    public string Image { get; set; }
    public int Stock { get; set; }
    public string Console { get; set; }
    public bool SuccessList { get; set; }
    public string idCategory { get; set; }

}