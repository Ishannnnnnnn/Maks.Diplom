using Application.Dto.OrderDto;
using AutoMapper;
using Domain.Entities;

namespace Application.Mapping;

/// <summary>
/// Конфигурация маппинга для Order
/// </summary>
public class OrderMappingProfile : Profile
{
    public OrderMappingProfile()
    {
        CreateMap<Order, AddOrderResponse>();
        
        CreateMap<AddOrderRequest, Order>()
            .ConstructUsing(dto => new Order
            {
                Id = Guid.NewGuid(),
                StoreId = dto.StoreId,
                Store = dto.Store,
                UserId = dto.UserId,
                User = dto.User
            });

        CreateMap<Order, GetByIdOrderResponse>();
        CreateMap<Order, GetAllByUserIdResponse>();
        CreateMap<Order, GetAllOrderResponse>();
    }
}