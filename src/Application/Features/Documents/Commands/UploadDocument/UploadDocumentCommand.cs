using Application.Abstractions.Messaging;

namespace Application.Features.Documents.Commands.UploadDocument;

public sealed class UploadDocumentCommand : IRequest<UploadDocumentResponse>
{
    public string Title { get; set; } = null!;
    public string OriginalFileName { get; set; } = null!;
    public string ContentType { get; set; } = null!;
    public byte[] FileContent { get; set; } = null!;
}