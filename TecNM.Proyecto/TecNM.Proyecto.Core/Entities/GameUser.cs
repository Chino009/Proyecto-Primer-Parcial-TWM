namespace TecNM.Proyecto.Core.Entities;

public class GameUser: EntityBase
{
    public string idUser { get; set; }
    public string Name { get; set; }
    public string User { get; set; }
    public string Password { get; set; }
    public string Address { get; set; }
    public string country { get; set; }
    public string phone { get; set; }
}