namespace Core.Domain.Entities;

public class Entity : EntityOnlyId, IEntityTimestamps
{
   
    public DateTime CreatedDate { get; set; }
    public DateTime? UpdatedDate { get; set; }
    public DateTime? DeletedDate { get; set; }

}