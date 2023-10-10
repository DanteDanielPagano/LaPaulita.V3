using LaPaulita.Sales.BusinessRules.Wrappers;

namespace LaPaulita.Sales.Presenters
{
    public class CreateOrderPresenter : ICreateOrderPresenter
    {

        public WrappersSalesOrder Order { get; private set; } = new WrappersSalesOrder();


        public ValueTask Handle(WrappersSalesOrder order)
        {
            Order.Errors = order.Errors;
            Order.Message = order.Message;
            Order.OrderId = order.OrderId;
            Order.ErrorNumber = order.ErrorNumber;
            return ValueTask.CompletedTask;
        }

        public ValueTask ValidationFaild(List<ValidationErrorDto> validationError)
        {
            Order.Errors = validationError;
            return ValueTask.CompletedTask;
        }
    }
}
