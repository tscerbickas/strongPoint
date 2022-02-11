namespace Project.WebApi.DataAccess.Entities;

public abstract class Entity
{
    public Guid Id { get; protected set; }
    public DateTime ModifiedDate { get; protected set; }

    protected void NewEntry()
    {
        Id = Guid.NewGuid();
        ModifiedDate = DateTime.Now;
    }
}
