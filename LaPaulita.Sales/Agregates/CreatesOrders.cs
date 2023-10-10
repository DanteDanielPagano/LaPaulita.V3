using LaPaulita.Sales.BusinessRules.DTOs;
using LaPaulita.Sales.BusinessRules.ValueObject;

namespace LaPaulita.Sales.BusinessRules.Agregates
{
    public class CreatesOrders : OrderHeader
    {
        //**********************************************************************
        // Esto si lo hago con una clase tipo record inmutable.
        //**********************************************************************

        readonly List<OrdersDetails> records = new List<OrdersDetails>();
        public IReadOnlyList<OrdersDetails> Details => records;

        /// <summary>
        /// Método que agrega un nuevo record a <c>OrdersDetails</c> de una orden de compra
        /// <c>OrderHeader</c>.
        /// Si el nuevo record a agregar tiene un <c>ProductId</c> que ya existe en 
        /// <c>OrdersDetails</c>, solo se modifica la cantidad del producto adicinando al 
        /// valor existente la nueva cantidad.
        /// </summary>
        /// <param name="record">Objeto que contiene los datos del nuevo registro a agregar.</param>
        public void AddRecord(OrdersDetails record)
        {
            var ExistingOrderDetail = records.FirstOrDefault(r => r.ProductId == record.ProductId);
            if (ExistingOrderDetail != default)
            {
                // Con with creamos una copia del objetoque esta a su izquierda pero con
                // las propiedades con valores modificado (entre la llaves)
                // Es decir agrega a la lista records una copia del objeto ExistingOrderDetail
                // pero modificando el valor de la propiedad ProductQuantity, asignandole como valor
                // lo que tiene ExistingOrderDetail.ProductQuantity sumado a lo que tiene
                // record.ProductQuantity

                records.Add(ExistingOrderDetail with
                {
                    ProductQuantity = (short)(ExistingOrderDetail.ProductQuantity + record.ProductQuantity)
                });
                records.Remove(ExistingOrderDetail);
            }
            else
            {
                records.Add(record);
            }
        }

        public void AddRecord(int _productId, decimal productPrice, short productQuantity)
        {
            AddRecord(new OrdersDetails(_productId, productPrice, productQuantity));
        }

        public static CreateOrder From(OrderHeaderDto orderHeaderDto)
        {
            // Aqui realizamos el mapeo de las propiedades del DTO con la Entidad.
            CreateOrder createOrder = new CreateOrder
            {
                ClientId = orderHeaderDto.ClientId,
                ShippingAddress = orderHeaderDto.ShippingAddress,
                ShippingCity = orderHeaderDto.ShippingCity,
                ShippingCountry = orderHeaderDto.ShippingCountry,
                ShippingZip = orderHeaderDto.ShippingZip
            };

            foreach (var item in orderHeaderDto.OrderDetails)
            {
                createOrder.AddRecord(item.ProductId, item.ProductPrice, item.ProductQuantty);
            }
            return createOrder;
        }
    }
}
