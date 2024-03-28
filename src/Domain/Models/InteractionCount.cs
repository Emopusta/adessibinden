using Core.Domain.Entities;

namespace Domain.Models;
public class InteractionCount : Entity
{
    public string Name { get; set; }
    public int Count { get; set; }

}
