namespace TecNM.Proyecto.Core.Entities;

public class Order: EntityBase
{
    public string idOrder { get; set; }
    public string idUser { get; set; }
    public double Ammount { get; set; }
    public string orderAddress { get; set; } 
    public DateTime orderDate { get; set; }
}