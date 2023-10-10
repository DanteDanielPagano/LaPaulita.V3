using LaPaulita.Sales.BusinessRules.Wrappers;

namespace LaPaulita.Sales.Presenters
{
    public class CreateOrderPresenter : ICreateOrderPresenter
    {
        //public int OrderId { get; private set; }

        //public List<ValidationErrorDto> ErrorsList { get; private set; }

        public WrappersSalesOrder Order { get; private set; } = new WrappersSalesOrder();

        //public ValueTask Handle(int orderId)
        //{
        //    OrderId = orderId;
        //    return ValueTask.CompletedTask;
        //}

        public ValueTask Handle(WrappersSalesOrder order)
        {
            Order.Errors = order.Errors;
            Order.Message = order.Message;
            Order.OrderId = order.OrderId;
            Order.Errors = order.Errors;
            return ValueTask.CompletedTask;
        }

        public ValueTask ValidationFaild(List<ValidationErrorDto> validationError)
        {
            Order.Errors = validationError;
            return ValueTask.CompletedTask;
        }
    }
}
