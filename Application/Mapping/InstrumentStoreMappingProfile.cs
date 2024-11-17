using Application.Dto.InstrumentStoreDto;
using AutoMapper;
using Domain.Entities;

namespace Application.Mapping;

/// <summary>
/// Конфигурация маппинга для InstrumentStore
/// </summary>
public class InstrumentStoreMappingProfile : Profile
{
    public InstrumentStoreMappingProfile()
    {
        CreateMap<InstrumentStore, AddInstrumentStoreResponse>();
        
        CreateMap<AddInstrumentStoreRequest, InstrumentStore>()
            .ConstructUsing(dto => new InstrumentStore
            {
                Id = Guid.NewGuid(),
                InstrumentId = dto.InstrumentId,
                StoreId = dto.StoreId,
                Amount = dto.Amount
            });
        
        CreateMap<InstrumentStore, UpdateInstrumentStoreResponse>();
        
        CreateMap<UpdateInstrumentStoreRequest, InstrumentStore>()
            .ConstructUsing(dto => new InstrumentStore
            {
                Id = dto.Id,
                InstrumentId = dto.InstrumentId,
                StoreId = dto.StoreId,
                Amount = dto.Amount
            });

        CreateMap<InstrumentStore, GetByIdInstrumentStoreResponse>();
        
        CreateMap<InstrumentStore, GetAllByStoreIdInstrumentStoreResponse>();

        CreateMap<InstrumentStore, GetAllInstrumentStoreResponse>();
    }
}