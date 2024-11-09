using Application.Dto.InstrumentDto;
using AutoMapper;
using Domain.Entities;

namespace Application.Mapping;

/// <summary>
/// Конфигурация маппинга для Instrument
/// </summary>
public class InstrumentMappingProfile : Profile
{
    public InstrumentMappingProfile()
    {
        CreateMap<Instrument, AddInstrumentResponse>();
        
        CreateMap<AddInstrumentRequest, Instrument>()
            .ConstructUsing(dto => new Instrument
            {
                Id = Guid.NewGuid(),
                Name = dto.Name,
                Category = dto.Category,
                Price = dto.Price
            });

        CreateMap<Instrument, UpdateInstrumentResponse>();
        
        CreateMap<UpdateInstrumentRequest, Instrument>()
            .ConstructUsing(dto => new Instrument
            {
                Id = dto.Id,
                Name = dto.Name,
                Category = dto.Category,
                Price = dto.Price
            });

        CreateMap<Instrument, GetByIdInstrumentResponse>();

        CreateMap<Instrument, GetAllInstrumentResponse>();
    }
}