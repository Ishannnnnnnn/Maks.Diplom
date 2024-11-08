using Application.Dto.User;
using Application.Dto.ValueObjects;
using AutoMapper;
using Domain.Entities;
using Domain.ValueObjects;

namespace Application.Mapping;

/// <summary>
/// Конфигурация маппинга для User
/// </summary>
public class UserMappingProfile : Profile
{
    public UserMappingProfile()
    {
        CreateMap<User, AddUserResponse>()
            .ForMember(dest => dest.FullName,
                opt => opt.MapFrom(src => src.FullName));
        
        CreateMap<AddUserRequest, User>()
            .ConstructUsing(dto => new User
            {
                Id = Guid.NewGuid(),
                FullName = new FullName(dto.FullName.Name, dto.FullName.Surname, dto.FullName.Patronymic),
                Nickname = dto.Nickname,
                Email = dto.Email,
                Password = dto.Password,
                Role = dto.Role,
                Balance = dto.Balance,
                Purchases = dto.Purchases,
                MoneySpend = dto.MoneySpend
            });
        
        CreateMap<User, UpdateUserResponse>()
            .ForMember(dest => dest.FullName,
                opt => opt.MapFrom(src => src.FullName));
        
        CreateMap<UpdateUserRequest, User>()
            .ConstructUsing(dto => new User
            {
                Id = dto.Id,
                FullName = new FullName(dto.FullName.Name, dto.FullName.Surname, dto.FullName.Patronymic),
                Nickname = dto.Nickname,
                Email = dto.Email,
                Password = dto.Password,
                Role = dto.Role,
                Balance = dto.Balance,
                Purchases = dto.Purchases,
                MoneySpend = dto.MoneySpend
            });
        
        CreateMap<User, GetByIdUserResponse>()
            .ForMember(dest => dest.FullName,
                opt => opt.MapFrom(src => src.FullName));
        
        CreateMap<User, GetAllUserResponse>()
            .ForMember(dest => dest.FullName,
                opt => opt.MapFrom(src => src.FullName));
        
        CreateMap<FullName, FullNameDto>();
        
        CreateMap<FullNameDto, FullName>();
    }
}