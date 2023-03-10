namespace TecNM.Proyecto.Core.Entities;

public class OrderDetail: EntityBase
{
    public string idOrderDetail { get; set; }
    public string idOrder { get; set; }
    public string idGame { get; set; }
    public int Quantity { get; set; }
}