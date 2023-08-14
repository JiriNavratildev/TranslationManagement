using Microsoft.AspNetCore.Mvc;
using TranslationManagement.Application.Translators;
using TranslationManagement.Application.Translators.Dtos;

namespace TranslationManagement.Api.Controllers;

[ApiController]
[Route("api/translators")]
public class TranslatorController : ControllerBase
{
    private readonly ITranslatorService translatorService;

    public TranslatorController(ITranslatorService translatorService)
    {
        this.translatorService = translatorService;
    }
    
    // GET: api/translators/{name}
    [HttpGet("{name}")]
    public async Task<ActionResult<TranslatorDto>> GetTranslator(string name)
    {
        var result = await translatorService.GetByNameAsync(name);

        if (result == null)
        {
            return NotFound();
        }

        return Ok(result);
    }
    
    // POST: api/translators
    [HttpPost]
    public async Task<ActionResult<TranslatorDto>> CreateTranslator(CreateTranslatorDto request)
    {
        var result = await translatorService.CreateAsync(request);
        return Ok(result);
    }
    
    // PUT: api/translators/{translatorId}/status
    [HttpPut("{translatorId}/status")]
    public async Task<ActionResult<TranslatorDto>> ChangeTranslatorStatus(int translatorId, UpdateTranslatorStatusDto request)
    {
        var result = await translatorService.UpdateStatusAsync(translatorId, request.TranslatorStatus);
        return Ok(result);
    }

    // PUT: api/translators/{translatorId}/jobs
    [HttpGet("{translatorId}/jobs")]
    public async Task<ActionResult<List<TranslatorDto>>> GetTranslatorJobs(int translatorId)
    {
        var result = await translatorService.GetTranslatorJobsAsync(translatorId);
        return Ok(result);
    }
}