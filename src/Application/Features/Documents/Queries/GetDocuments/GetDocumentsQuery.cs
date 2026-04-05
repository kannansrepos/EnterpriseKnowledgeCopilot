using Application.Abstractions.Messaging;
using Domain.Entities;

namespace Application.Features.Documents.Queries.GetDocuments;

public sealed class GetDocumentsQuery : IRequest<IReadOnlyList<Document>>
{
}