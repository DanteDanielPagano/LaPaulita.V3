using LaPaulita.Sales.BusinessRules.Wrappers;

namespace LaPaulita.Sales.BusinessRules.Interface.Presenters
{
    public interface ICreateOrderPresenter : ICreateOrderOutputPort
    {
        WrappersSalesOrder Order { get; }
    }
}
