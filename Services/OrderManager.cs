using Entities.Models;
using Repositories.Contracts;
using Services.Contracts;

namespace Services
{
    public class OrderManager : IOrderServices
    {
        private readonly IRepositoryManager _meneger;

        public OrderManager(IRepositoryManager meneger)
        {
            _meneger = meneger;
        }

        public IQueryable<Order> Orders => _meneger.Order.Orders;

        public int NumberOfInProcess => _meneger.Order.NumberOfInProcess;

        public void Complate(int id)
        {
            _meneger.Order.Complate(id);
            _meneger.Save();
        }

        public Order? GetOneOrder(int id)
        {
            return _meneger.Order.GetOneOrder(id);
        }

        public void SaveOrder(Order order)
        {
            _meneger.Order.SaveOrder(order);
        }
    }
}