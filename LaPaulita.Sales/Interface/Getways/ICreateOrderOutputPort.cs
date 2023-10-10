using LaPaulita.Sales.BusinessRules.Wrappers;

namespace LaPaulita.Sales.BusinessRules.Interface.Getways
{
    public interface ICreateOrderOutputPort
    {
        ValueTask Handle(WrappersSalesOrder order);
    }
}
