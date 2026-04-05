using Application.Abstractions.Identity;
using Application.Abstractions.Messaging;
using Application.Abstractions.Persistence;
using Application.Abstractions.Storage;
using Domain.Entities;

namespace Application.Features.Documents.Commands.UploadDocument;

public class UploadDocumentHandler
(
    IDocumentRepository documentRepository,
    IFileStorageService fileStorageService,
    ICurrentUserService currentUserService)
    : IRequestHandler<UploadDocumentCommand, UploadDocumentResponse>
{
    private readonly IDocumentRepository _documentRepository = documentRepository;
    private readonly IFileStorageService _fileStorageService = fileStorageService;
    private readonly ICurrentUserService _currentUserService =currentUserService;

    public async Task<UploadDocumentResponse> Handle(
        UploadDocumentCommand request,
        CancellationToken cancellationToken)
    {
        // 1. Input Validation
        if (!_currentUserService.IsAuthenticated)
        {
            throw new UnauthorizedAccessException("User is not authenticated.");
        }

        if (string.IsNullOrWhiteSpace(request.Title))
        {
            throw new ArgumentException("Document title is required.", nameof(request.Title));
        }

        if (string.IsNullOrWhiteSpace(request.OriginalFileName))
        {
            throw new ArgumentException("Original file name is required.", nameof(request.OriginalFileName));
        }

        if (request.FileContent is null || request.FileContent.Length == 0)
        {
            throw new ArgumentException("File content cannot be empty.", nameof(request.FileContent));
        }

        // 1. Save file
        var (storedFileName, storagePath) =
            await _fileStorageService.SaveAsync(
                request.FileContent,
                request.OriginalFileName,
                cancellationToken);
        
        // 2. Create entity
        var document = new Document
        {
            Title = request.Title,
            OriginalFileName = request.OriginalFileName,
            StoredFileName = storedFileName,
            ContentType = request.ContentType,
            FileSizeBytes = request.FileContent.Length,
            StoragePath = storagePath,
            ModifiedOn = DateTime.UtcNow,
            CreatedBy = _currentUserService.UserId
        };
        
        // 3. Save to DB
        await _documentRepository.AddAsync(document, cancellationToken);

        return new UploadDocumentResponse
        {
            DocumentId = document.Id,
            Title = document.Title,
            OriginalFileName = document.OriginalFileName,
            StoredFileName = document.StoredFileName,
            ContentType = document.ContentType,
            FileSizeBytes = document.FileSizeBytes,
            Status = document.Status,
            UploadedAtUtc = document.ModifiedOn
        };
    }
}