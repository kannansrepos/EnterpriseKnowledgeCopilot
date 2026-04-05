using Application.Abstractions.Messaging;
using Application.Features.Documents.Commands.UploadDocument;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers;

public class SystemController : BaseApiController
{
    [HttpGet("ping")]
    public IActionResult Ping()
    {
        return Ok(new
        {
            message = "API is running",
            utcTime = DateTime.UtcNow
        });
    }
    [HttpPost("upload")]
    public async Task<IActionResult> Upload(
        [FromServices] IRequestDispatcher dispatcher,
        IFormFile file)
    {
        using var memoryStream = new MemoryStream();
        await file.CopyToAsync(memoryStream);

        var command = new UploadDocumentCommand
        {
            Title = file.FileName,
            OriginalFileName = file.FileName,
            ContentType = file.ContentType,
            FileContent = memoryStream.ToArray()
        };

        var documentId = await dispatcher.Send(command);

        return Ok(documentId);
    }
}