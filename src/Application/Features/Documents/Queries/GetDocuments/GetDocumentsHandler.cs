using Application.Abstractions.Messaging;
using Application.Abstractions.Persistence;
using Domain.Entities;

namespace Application.Features.Documents.Queries.GetDocuments;

public sealed class GetDocumentsHandler(IDocumentRepository documentRepository)
    : IRequestHandler<GetDocumentsQuery, IReadOnlyList<Document>>
{
    public async Task<IReadOnlyList<Document>> Handle(
        GetDocumentsQuery request,
        CancellationToken cancellationToken)
    {
        return await documentRepository.GetAllAsync(cancellationToken);
    }
}