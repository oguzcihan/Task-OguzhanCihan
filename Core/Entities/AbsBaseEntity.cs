namespace Core.Entities;

public abstract class AbsBaseEntity
{
    public int Id { get; set; }
    public DateTime CreatedDate { get; set; }
    public DateTime? UpdatedDate { get; set; }

    public AbsBaseEntity()
    {
    }

    public AbsBaseEntity(int id) : this()
    {
        Id = id;
    }
}