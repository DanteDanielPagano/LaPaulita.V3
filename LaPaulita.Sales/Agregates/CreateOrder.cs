using LaPaulita.Sales.BusinessRules.DTOs;
using LaPaulita.Sales.BusinessRules.ValueObject;

namespace LaPaulita.Sales.BusinessRules.Agregates
{
    public class CreateOrder : OrderHeader
    {
        //**********************************************************************
        // Esto si lo hago con una clase que es preparada por nosotros para ser
        // inmutable.
        //**********************************************************************


        // Campo 
        readonly List<OrderDetail> records = new List<OrderDetail>();
        // Propiedad
        public IReadOnlyList<OrderDetail> Details => records;

        public void AddDetail(OrderDetail record)
        {
            var ExistingOrderDetail = records.FirstOrDefault(r => r.ProductId == record.ProductId);
            if (ExistingOrderDetail != default)
            {
                records.Add(new OrderDetail(record.ProductId, record.ProductPrice,
                    (short)(record.ProductQuantity + ExistingOrderDetail.ProductQuantity)));
                records.Remove(ExistingOrderDetail);
            }
            else
            {
                records.Add(record);
            }
        }

        public void AddRecord(int productId, decimal productPrice, short productQuantity)
        {
            AddDetail(new OrderDetail(productId, productPrice, productQuantity));
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
