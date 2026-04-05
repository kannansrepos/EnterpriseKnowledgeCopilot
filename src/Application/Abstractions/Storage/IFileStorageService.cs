namespace Application.Abstractions.Storage;

public interface IFileStorageService
{
    Task<(string StoredFileName, string StoragePath)> SaveAsync(
        byte[] fileContent,
        string originalFileName,
        CancellationToken cancellationToken);
}