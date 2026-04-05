using Domain.Entities;

namespace Application.Abstractions.Persistence;

public interface IDocumentRepository
{
    Task AddAsync(Document document, CancellationToken cancellationToken);
    Task<Document?> GetByIdAsync(Guid id, CancellationToken cancellationToken);
    Task<IReadOnlyList<Document>> GetAllAsync(CancellationToken cancellationToken);
}