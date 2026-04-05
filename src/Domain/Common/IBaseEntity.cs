namespace Domain.Entities;

public interface IBaseEntity
{
    public Guid Id { get; set; }
    public Guid CreatedBy { get; set; }
    public DateTime CreatedOn { get; set; }
    public Guid ModifiedBy { get; set; }
    public DateTime ModifiedOn { get; set; }
    public bool IsActive { get; set; }
}