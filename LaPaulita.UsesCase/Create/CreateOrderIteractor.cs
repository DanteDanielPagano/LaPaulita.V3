using LaPaulita.Sales.BusinessRules.Agregates;
using LaPaulita.Sales.BusinessRules.Interface.Presenters;
using LaPaulita.Sales.BusinessRules.Interface.Repositories;
using LaPaulita.Sales.BusinessRules.Wrappers;
using LaPaulita.UserCase.Specifications;

namespace LaPaulita.Sales.UsesCase.Create
{
    /// <summary>
    /// <b>Use Case Interactor</b>. Es el elemento que contiene el código con la lógica de
    /// negocios que resuelve un caso de uso. Este elemento implementa la abstracción
    /// representada por el elemento <i>Use Case Input Port</i>. En términos de programación
    /// orientada a objetos, el <b>Interactor</b> es una clase que implementa una
    /// Interface o clase abstracta <i>(InputPort)</i>.
    /// </summary>
    public class CreateOrderIteractor : ICreateOrderInputPort
    {
        //readonly ICreateOrderOutputPort _outputPort;
        readonly ISalesCommandRepository _repository;
        readonly ICreateOrderPresenter _presenter;

        public CreateOrderIteractor(ICreateOrderOutputPort outputPort, ISalesCommandRepository repository, ICreateOrderPresenter presenter)
        {
            //_outputPort = outputPort;
            _repository = repository;
            _presenter = presenter;
        }

        public async Task Handle(OrderHeaderDto createOrderDto)
        {
            // Instanciamos un objeto del tipo List<ValidationErrorDto> y le asignamos
            // lo que nos devuelva el método privado ValidateOrder.

            List<ValidationErrorDto> validationErrors = new List<ValidationErrorDto>();
            validationErrors = ValidateOrder(createOrderDto);
            WrappersSalesOrder order = new();
            // Consultamos si la lista validationErrors posee algún elemento.
            if (validationErrors.Count > 0)
            {
                // Si la lista poseía algún elemento, es que hay por lo menos un error
                // Entonses retormaos el OutputPort al presentador con la lista de errores.

                order.Errors = validationErrors;
                await _presenter.Handle(order);
                return;
            }

            // Si no hay errores contiunuamos con la ejecución del código y
            // creamos la orden, luego guardamos los cambios y finalmente retornamos
            // el Id del registro creado.

            CreateOrder createOrder = CreateOrder.From(createOrderDto);
            try
            {
                await _repository.CreateOrder(createOrder);
                await _repository.SaveChange();
                order.OrderId = createOrder.Id;
            }
            catch (Exception ex)
            {
                order.Message = ex.Message;
            }
            finally
            {
                await _presenter.Handle(order);
            }

        }
        /// <summary>
        /// Método que valida los datos de la Orden de compra antes de ser presistida
        /// en la base de datos.
        /// <br/> <br/>
        /// <i>Posteriormente deberemos realizar la validación de la existencia de los
        /// datos que debene existir previamente a la orden de compra, como el id del
        /// cliente o el id del producto.</i>
        /// </summary>
        /// <param name="createOrderDto">Objeto que contiene las propiedades a validar</param>
        /// <returns>La lista de propiedades que no cumplen con la validación 
        /// y la descripción del error específico.</returns>
        private List<ValidationErrorDto> ValidateOrder(OrderHeaderDto createOrderDto)
        {
            var specification = new OrderHeaderSpecification(createOrderDto);

            return specification.IsValid();
        }
    }
}
