namespace Application.Features.Documents.Commands.UploadDocument;

public sealed class UploadDocumentResponse
{
    public Guid DocumentId { get; set; }
    public string Title { get; set; } = default!;
    public string OriginalFileName { get; set; } = default!;
    public string StoredFileName { get; set; } = default!;
    public string ContentType { get; set; } = default!;
    public long FileSizeBytes { get; set; }
    public string Status { get; set; } = default!;
    public DateTime UploadedAtUtc { get; set; }
}