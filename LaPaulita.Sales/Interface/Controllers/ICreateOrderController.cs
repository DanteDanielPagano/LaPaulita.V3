using LaPaulita.Sales.BusinessRules.DTOs;
using LaPaulita.Sales.BusinessRules.Wrappers;

namespace LaPaulita.Sales.BusinessRules.Interface.Controllers
{
    public interface ICreateOrderController
    {
        Task<WrappersSalesOrder> CreateOrder(OrderHeaderDto order);
    }
}
