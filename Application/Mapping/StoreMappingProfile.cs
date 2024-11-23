using Application.Dto.StoreDto;
using Application.Dto.ValueObjects;
using AutoMapper;
using Domain.Entities;
using Domain.ValueObjects;

namespace Application.Mapping;

/// <summary>
/// Конфигурация маппинга для Store
/// </summary>
public class StoreMappingProfile : Profile
{
    public StoreMappingProfile()
    {
        CreateMap<Store, AddStoreResponse>()
            .ForMember(dest => dest.Address,
                opt => opt.MapFrom(src => src.Address));
        
        CreateMap<AddStoreRequest, Store>()
            .ConstructUsing(dto => new Store
            {
                Id = Guid.NewGuid(),
                Address = new Address(dto.Address.City, dto.Address.Street, dto.Address.HouseNumber),
                Phone = dto.Phone
            });
        
        CreateMap<Store, UpdateStoreResponse>()
            .ForMember(dest => dest.Address,
                opt => opt.MapFrom(src => src.Address));
        
        CreateMap<UpdateStoreRequest, Store>()
            .ConstructUsing(dto => new Store
            {
                Id = dto.Id,
                Address = new Address(dto.Address.City, dto.Address.Street, dto.Address.HouseNumber),
                Phone = dto.Phone
            });
        
        CreateMap<Store, GetByIdStoreResponse>()
            .ForMember(dest => dest.Address,
                opt => opt.MapFrom(src => src.Address));
        
        CreateMap<Store, GetAllStoreResponse>()
            .ForMember(dest => dest.Address,
                opt => opt.MapFrom(src => src.Address));
        
        CreateMap<Address, AddressDto>();
        
        CreateMap<AddressDto, Address>();
    }
}