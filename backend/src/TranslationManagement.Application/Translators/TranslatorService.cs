using Microsoft.EntityFrameworkCore;
using TranslationManagement.Application.Common;
using TranslationManagement.Application.TranslationJobs.Dtos;
using TranslationManagement.Application.Translators.Dtos;
using TranslationManagement.Application.UnitOfWork;
using TranslationManagerClean.Domain.Translators;

namespace TranslationManagement.Application.Translators;

public class TranslatorService : BaseService, ITranslatorService
{
    private readonly ITranslatorRepository translatorRepository;
    private readonly IUnitOfWork unitOfWork;

    public TranslatorService(ITranslatorRepository translatorRepository, IUnitOfWork unitOfWork)
    {
        this.translatorRepository = translatorRepository;
        this.unitOfWork = unitOfWork;
    }
    
    public async Task<List<TranslatorDto>> GetAsync()
    {
        var result = await translatorRepository.GetAll()
            .Select(t => new TranslatorDto(t.Id, t.Name, t.HourlyRate))
            .ToListAsync();

        return result;
    }

    public async Task<TranslatorDto?> GetByNameAsync(string name)
    {
        var result = await translatorRepository.GetAll()
            .Select(t => new TranslatorDto(t.Id, t.Name, t.HourlyRate))
            .FirstOrDefaultAsync(t => t.Name == name);

        return result;
    }

    public async Task<TranslatorDto> CreateAsync(CreateTranslatorDto createTranslatorDto)
    {
        ValidateDto(createTranslatorDto);

        var translator = Translator.Create(createTranslatorDto.Name, createTranslatorDto.HourlyRate,
            createTranslatorDto.CreditCardNumber);

        translatorRepository.Add(translator);
        var result = await unitOfWork.CommitAsync();
        // TODO: Je toto ok?
        //return result > 0;

        return new TranslatorDto(translator.Id, translator.Name, translator.HourlyRate);
    }

    public async Task<TranslatorDto> UpdateStatusAsync(int translatorId, TranslatorStatus status)
    {
        var translator = await translatorRepository.GetByIdAsync(translatorId);

        if (translator == null)
        {
            throw new Exception();
        }

        // Check if status is null?
        translator.SetStatus(status);
        await unitOfWork.CommitAsync();

        return new TranslatorDto(translator.Id, translator.Name, translator.HourlyRate);
    }

    public async Task<List<TranslationJobDto>> GetTranslatorJobsAsync(int translatorId)
    {
        var translator = await translatorRepository.GetAll()
            .Include(t => t.TranslationJobs)
            .FirstOrDefaultAsync(t => t.Id == translatorId);

        if (translator == null)
        {
            throw new Exception();
        }

        var result = translator.TranslationJobs
            .Select(tj => new TranslationJobDto(tj.Id, tj.CustomerName, tj.Status,
                tj.OriginalContent, tj.TranslatedContent,
                tj.Price))
            .ToList();

        return result;
    }
}