using Microsoft.AspNetCore.Mvc;
using TranslationManagement.Application.Files;
using TranslationManagement.Application.TranslationJobs;
using TranslationManagement.Application.TranslationJobs.Dtos;

namespace TranslationManagement.Api.Controllers;

[ApiController]
[Route("api/translation-jobs")]
public class TranslationJobController : ControllerBase
{
    private readonly ITranslationJobService translationJobService;

    public TranslationJobController(ITranslationJobService translationJobService)
    {
        this.translationJobService = translationJobService;
    }

    // GET: api/translation-jobs}
    [HttpGet]
    public async Task<ActionResult<List<TranslationJobDto>>> GetJobs()
    {
        var result = await translationJobService.GetAsync();

        return Ok(result);
    }

    // POST: api/translation-jobs
    [HttpPost]
    public async Task<ActionResult<TranslationJobDto>> CreateAsync(CreateTranslationJobDto request)
    {
        var result = await translationJobService.CreateAsync(request);

        return Ok(result);
    }

    // PUT: api/translation-jobs/{id}/status
    [HttpPut("{jobId:int}/status")]
    public async Task<ActionResult<TranslationJobDto>> UpdateStatusAsync(int jobId, UpdateTransactionJobStatusDto request)
    {
        var result = await translationJobService.UpdateStatusAsync(jobId, request);
        
        return Ok(result);
    }

    // I would consider to have separated endpoint for file upload and file process
    
    // POST: api/translation-jobs/from-file
    [HttpPost("from-file")]
    public async Task<ActionResult<TranslationJobDto>> CreateFromFile(IFormFile file, string customerName)
    {
        var reader = new StreamReader(file.OpenReadStream());
        var fileContent = await reader.ReadToEndAsync();
        
        if (!FileHelper.TryParseFileType(file.FileName, out var fileType))
        {
            return BadRequest();
        }

        var createTranslationJobFileDto = new CreateTranslationJobFileDto
        {
            FileType = fileType!.Value,
            FileContent = fileContent,
            CustomerName = customerName
        };

        var result = await translationJobService.CreateAsync(createTranslationJobFileDto);

        return Ok(result);
    }

    // POST: api/translation-jobs/{jobId}/translators/{translatorId}
    [HttpPost("{jobId:int}/translators/{translatorId:int}")]
    public async Task<IActionResult> AssignTranslator(int jobId, int translatorId)
    {
        // I should return some result, but skipping it for now
        await translationJobService.AssignTranslatorAsync(jobId, translatorId);
        return Ok();
    }
}