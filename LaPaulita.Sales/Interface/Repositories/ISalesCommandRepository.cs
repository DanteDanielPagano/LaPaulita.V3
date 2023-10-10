using LaPaulita.Entity.Interfaces;
using LaPaulita.Sales.BusinessRules.Agregates;

namespace LaPaulita.Sales.BusinessRules.Interface.Repositories
{
    public interface ISalesCommandRepository : IUnitOfWork
    {
        Task CreateOrder(CreateOrder order);
    }
}
