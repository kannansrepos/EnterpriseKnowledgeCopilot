namespace Domain.Entities;

public class BaseEntity:IBaseEntity
{
    public Guid Id { get; set; } = Guid.NewGuid();
    public Guid CreatedBy { get; set; }
    public DateTime CreatedOn { get; set; }
    public Guid ModifiedBy { get; set; }
    public DateTime ModifiedOn { get; set; }
    public bool IsActive { get; set; }=true;
}