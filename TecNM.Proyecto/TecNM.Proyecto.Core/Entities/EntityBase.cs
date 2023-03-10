namespace TecNM.Proyecto.Core.Entities;

public class EntityBase
{
    public int id { get; set; }
    public bool IsDeleted { get; set; }
    public string CreatedBy { get; set; }
    public DateTime CreatedTime { get; set; }
    public string UpdateBy { get; set; }
    public DateTime UpDateTime { get; set; }
}

