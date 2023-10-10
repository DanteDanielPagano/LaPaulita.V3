namespace LaPaulita.Entity.Interfaces
{
    public interface IUnitOfWork
    {
        Task SaveChange();
    }
}
