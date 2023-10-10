using LaPaulita.Sales.BusinessRules.DTOs;

namespace LaPaulita.Sales.BusinessRules.Interface.Getways
{
    public interface ICreateOrderInputPort
    {
        Task Handle(OrderHeaderDto createOrderDto);
    }
}
