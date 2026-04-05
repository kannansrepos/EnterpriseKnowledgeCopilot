namespace Domain.Entities;

public class Document:BaseEntity
{
    public string Title { get; set; } = null!;
    public string OriginalFileName { get; set; } = null!;
    public string StoredFileName { get; set; } = null!;
    public string ContentType { get; set; } = null!;
    public long FileSizeBytes { get; set; }
    public string StoragePath { get; set; } = null!;
    public string Status { get; set; } = "Uploaded";
}