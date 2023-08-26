namespace Core.Persistence.Repositories;

public class Entity<T>
{
    public T Id { get; set; }

    public Entity()
    {
    }

    public Entity(T id) : this()
    {
        Id = id;
    }
}