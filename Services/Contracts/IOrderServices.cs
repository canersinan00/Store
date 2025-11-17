using Entities.Models;

namespace Services.Contracts
{
    public interface IOrderServices
    {
        IQueryable<Order> Orders { get; }
        Order? GetOneOrder(int id);
        void Complate(int id);
        void SaveOrder(Order order);
        int NumberOfInProcess { get; }
    }
}