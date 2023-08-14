using Microsoft.EntityFrameworkCore;
using TranslationManagement.Application.Common;
using TranslationManagement.Application.Files;
using TranslationManagement.Application.Notifications;
using TranslationManagement.Application.TranslationJobs.Dtos;
using TranslationManagement.Application.UnitOfWork;
using TranslationManagement.Domain.TranslationJobs;
using TranslationManagement.Domain.Translators;

namespace TranslationManagement.Application.TranslationJobs;

public class TranslationJobService : BaseService, ITranslationJobService
{
    private readonly ITranslationJobRepository translationJobRepository;
    private readonly ITranslatorRepository translatorRepository;
    private readonly IUnitOfWork unitOfWork;
    private readonly IFileParserContext fileParserContext;
    private readonly INotificationService notificationService;

    public TranslationJobService(IUnitOfWork unitOfWork, IFileParserContext fileParserContext, INotificationService notificationService, ITranslationJobRepository translationJobRepository, ITranslatorRepository translatorRepository)
    {
        this.unitOfWork = unitOfWork;
        this.fileParserContext = fileParserContext;
        this.notificationService = notificationService;
        this.translationJobRepository = translationJobRepository;
        this.translatorRepository = translatorRepository;
    }

    public async Task<List<TranslationJobDto>> GetAsync()
    {
        var result = await translationJobRepository.GetAll()
            .Select(tj =>
                new TranslationJobDto(tj.Id, tj.CustomerName, tj.Status, tj.OriginalContent, tj.TranslatedContent,
                    tj.Price))
            .ToListAsync();

        return result;
    }

    public async Task<TranslationJobDto> CreateAsync(CreateTranslationJobDto createTranslationJobDto)
    {
        ValidateDto(createTranslationJobDto);
        
        var translationJob =
            TranslationJob.Create(createTranslationJobDto.CustomerName, createTranslationJobDto.OriginalContent);

        translationJobRepository.Add(translationJob);
        await unitOfWork.CommitAsync();
        await notificationService.SendNotificationAsync($"Job created: {translationJob.Id}");

        return new TranslationJobDto(translationJob.Id, translationJob.CustomerName, translationJob.Status,
            translationJob.OriginalContent, translationJob.TranslatedContent,
            translationJob.Price);
    }
    
    public async Task<TranslationJobDto> CreateAsync(CreateTranslationJobFileDto createTranslationJobFileDto)
    {
        ValidateDto(createTranslationJobFileDto);
        
        switch (createTranslationJobFileDto.FileType)
        {
            case FileType.TXT:
                fileParserContext.SetParser(new TxtFileParser());
                break;
            case FileType.XML:
                fileParserContext.SetParser(new XmlFileParser());
                break;
            default:
                throw new Exception();
        }
        
        var createTranslationJobDto = fileParserContext.Parse(createTranslationJobFileDto.FileContent, createTranslationJobFileDto.CustomerName);
        return await CreateAsync(createTranslationJobDto);
    }

    public async Task<TranslationJobDto> UpdateStatusAsync(int jobId, UpdateTransactionJobStatusDto updateTransactionJobStatusDto)
    {
        ValidateDto(updateTransactionJobStatusDto);

        var translationJob = await translationJobRepository.GetByIdAsync(jobId);

        if (translationJob == null)
        {
            throw new Exception();
        }

        var updated = translationJob.TryUpdateStatus(updateTransactionJobStatusDto.Status);

        if (!updated)
        {
            throw new Exception();
        }

        await unitOfWork.CommitAsync();

        return new TranslationJobDto(translationJob.Id, translationJob.CustomerName, translationJob.Status,
            translationJob.OriginalContent, translationJob.TranslatedContent,
            translationJob.Price);
    }

    public async Task AssignTranslatorAsync(int jobId, int translatorId)
    {
        var translationJob = await translationJobRepository.GetByIdAsync(jobId);

        if (translationJob == null)
        {
            throw new Exception();
        }

        var translator = await translatorRepository.GetByIdAsync(translatorId);
        
        if (translator == null)
        {
            throw new Exception();
        }
        
        translationJob.AssignTranslator(translator);
        await unitOfWork.CommitAsync();
    }
}