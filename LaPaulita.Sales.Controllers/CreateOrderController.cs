using LaPaulita.Sales.BusinessRules.Wrappers;

namespace LaPaulita.Sales.Controllers
{
    public class CreateOrderController : ICreateOrderController
    {
        readonly ICreateOrderInputPort _inputPort;
        readonly ICreateOrderPresenter _presenter;

        //public CreateOrderController(ICreateOrderInputPort inputPort, ICreateOrderPresenter presenter)
        //{
        //    _inputPort = inputPort;
        //    _presenter = presenter;
        //}
        public CreateOrderController(ICreateOrderInputPort inputPort, ICreateOrderPresenter presenter) => (_presenter, _inputPort) = (presenter, inputPort); //Expresión lamda.

        public async Task<WrappersSalesOrder> CreateOrder(OrderHeaderDto order)
        {
            await _inputPort.Handle(order);
            return _presenter.Order;

        }
    }
}
