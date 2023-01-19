using System.ComponentModel;

namespace Core.Persistence.Repositories;

public class Entity
{
    public int Id { get; set; }

    public bool IsDeleted { get; set; }

    public Entity()
    {
    }

    public Entity(int id, bool isDeleted) : this()
    {
        Id = id;
        IsDeleted = isDeleted;
    }
}