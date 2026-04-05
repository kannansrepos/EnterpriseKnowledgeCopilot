namespace Domain.Entities;

public abstract class User: BaseEntity
{
    public string Name { get; set; } = null!;
    public string Email { get; set; } = null!;
    public string PasswordHash { get; set; } = null!;
    
    public ICollection<UserRole> UserRoles { get; set; } = new List<UserRole>();
    public ICollection<Document> UploadedDocuments { get; set; } = new List<Document>();
}