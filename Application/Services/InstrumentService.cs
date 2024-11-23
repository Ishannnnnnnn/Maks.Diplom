using Application.Dto.InstrumentDto;
using Application.Interfaces;
using AutoMapper;
using Domain.Entities;

namespace Application.Services;

public class InstrumentService
{
    private readonly IInstrumentRepository _instrumentRepository;
    private readonly GoogleCloudService _googleCloudService;
    private readonly IMapper _mapper;

    public InstrumentService(
        IInstrumentRepository instrumentRepository,
        IMapper mapper,
        GoogleCloudService googleCloudService)
    {
        _instrumentRepository = instrumentRepository;
        _googleCloudService = googleCloudService;
        _mapper = mapper;
    }

    /// <summary>
    /// Создание Instrument
    /// </summary>
    /// <param name="instrumentRequest">Instrument на создание.</param>
    /// <param name="fileStream">Стрим файла.</param>
    /// <param name="fileName">Название файла.</param>
    /// <param name="contentType">Тип файла.</param>
    /// <param name="cancellationToken">Токен отмены.</param>
    /// <returns>Созданный Instrument.</returns>
    public async Task<AddInstrumentResponse> AddAsync(
        AddInstrumentRequest instrumentRequest,
        Stream fileStream,
        string fileName,
        string contentType,
        CancellationToken cancellationToken)
    {
        var instrument = _mapper.Map<Instrument>(instrumentRequest);
        instrument.ImageUrl = await _googleCloudService.UploadFileAsync(fileStream, fileName, contentType);
        
        var createdInstrument = await _instrumentRepository.AddAsync(instrument, cancellationToken);
        await _instrumentRepository.SaveChangesAsync(cancellationToken);
        return _mapper.Map<AddInstrumentResponse>(createdInstrument);
    }

    /// <summary>
    /// Удаление Instrument
    /// </summary>
    /// <param name="id">Идентификатор.</param>
    /// <param name="cancellationToken">Токен отмены.</param>
    public async Task DeleteAsync(Guid id, CancellationToken cancellationToken)
    {
        var instrument = await GetByIdOrThrowAsync(id, cancellationToken);
        await _googleCloudService.DeleteFileAsync(instrument.ImageUrl.Split("/").Last());
        
        await _instrumentRepository.DeleteAsync(instrument, cancellationToken); 
        await _instrumentRepository.SaveChangesAsync(cancellationToken);
    }

    /// <summary>
    /// Обновление Instrument
    /// </summary>
    /// <param name="instrumentRequest">Instrument на обновление.</param>
    /// <param name="cancellationToken">Токен отмены.</param>
    /// <returns>Обновленный Instrument.</returns>
    public async Task<UpdateInstrumentResponse> UpdateAsync(
        UpdateInstrumentRequest instrumentRequest,
        CancellationToken cancellationToken)
    {
        var instrument = await GetByIdOrThrowAsync(instrumentRequest.Id, cancellationToken);

        instrument.Update(
            instrumentRequest.Name,
            instrumentRequest.Category,
            instrumentRequest.Price);
        
        await _instrumentRepository.UpdateAsync(instrument, cancellationToken);
        await _instrumentRepository.SaveChangesAsync(cancellationToken);
        
        return _mapper.Map<UpdateInstrumentResponse>(instrument);
    }

    /// <summary>
    /// Получение Instrument по идентификатору
    /// </summary>
    /// <param name="id">Идентификатор.</param>
    /// <param name="cancellationToken">Токен отмены.</param>
    /// <returns>Instrument.</returns>
    public async Task<GetByIdInstrumentResponse> GetByIdAsync(Guid id, CancellationToken cancellationToken)
    {
        var instrument = await GetByIdOrThrowAsync(id, cancellationToken);
        return _mapper.Map<GetByIdInstrumentResponse>(instrument);
    }

    /// <summary>
    /// Получение всех Instrument
    /// </summary>
    /// <param name="cancellationToken">Токен отмены.</param>
    /// <returns>Список всех Instrument.</returns>
    public async Task<List<GetAllInstrumentResponse>> GetAllAsync(CancellationToken cancellationToken)
    {
        var instruments = await _instrumentRepository.GetAllAsync(cancellationToken);
        return _mapper.Map<List<GetAllInstrumentResponse>>(instruments);
    }

    /// <summary>
    /// Метод проверки на наличие объекта
    /// </summary>
    /// <param name="id">Идентификатор.</param>
    /// <param name="cancellationToken">Токен отмены.</param>
    /// <returns>Instrument.</returns>
    private async Task<Instrument> GetByIdOrThrowAsync(Guid id, CancellationToken cancellationToken)
    {
        var instrument = await _instrumentRepository.GetByIdAsync(id, cancellationToken);
        if (instrument != null)
            return instrument;
        
        return null;
    }
}