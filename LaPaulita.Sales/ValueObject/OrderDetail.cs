namespace LaPaulita.Sales.BusinessRules.ValueObject
{
    public class OrderDetail : IEquatable<OrderDetail>
    {
        #region "Campos"
        readonly int _productId;
        readonly decimal _productPrice;
        readonly short _productQuantity;
        #endregion

        #region "Propiedades"
        //public int ProductId { get { return _productId; } }
        public int ProductId => _productId; //expresión Lambda
        public decimal ProductPrice => _productPrice;
        public short ProductQuantity => _productQuantity;
        #endregion

        #region "Cosntructor"
        public OrderDetail(int productId, decimal productPrice, short productQuantity)
        {
            _productId = productId;
            _productPrice = productPrice;
            _productQuantity = productQuantity;
        }
        #endregion

        #region"Equals and GetHashCode"
        public override bool Equals(object? obj)
        {
            return Equals(obj as OrderDetail);
        }

        public bool Equals(OrderDetail? other)
        {
            //return other is not null &&
            //       ProductId == other.ProductId &&
            //       ProductPrice == other.ProductPrice &&
            //       ProductQuantity == other.ProductQuantity;

            //***************************************************
            // Otra forma usando GetHashCode.
            //***************************************************
            if (other != null) { return GetHashCode() == other.GetHashCode(); }
            else { return false; }
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(ProductId, ProductPrice, ProductQuantity);
        }
        #endregion
    }
}

