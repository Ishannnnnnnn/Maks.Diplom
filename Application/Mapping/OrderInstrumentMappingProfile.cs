using Application.Dto.OrderInstrumentDto;
using AutoMapper;
using Domain.Entities;

namespace Application.Mapping;

/// <summary>
/// Конфигурация маппинга для OrderInstrument
/// </summary>
public class OrderInstrumentMappingProfile : Profile
{
    public OrderInstrumentMappingProfile()
    {
        CreateMap<OrderInstrument, AddOrderInstrumentResponse>();
        
        CreateMap<AddOrderInstrumentRequest, OrderInstrument>()
            .ConstructUsing(dto => new OrderInstrument
            {
                Id = Guid.NewGuid(),
                OrderId = dto.OrderId,
                Order = dto.Order,
                InstrumentId = dto.InstrumentId,
                Instrument = dto.Instrument,
                Amount = dto.Amount,
                Price = dto.Price
            });

        CreateMap<OrderInstrument, GetByIdOrderInstrumentResponse>();

        CreateMap<OrderInstrument, GetAllOrderInstrumentResponse>();
    }
}