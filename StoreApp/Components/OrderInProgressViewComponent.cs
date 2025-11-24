using Microsoft.AspNetCore.Mvc;
using Services.Contracts;

namespace StoreApp.Components
{
    public class OrderInProgressViewComponent : ViewComponent
    {
        private readonly IServiceManager _meneger;

        public OrderInProgressViewComponent(IServiceManager meneger)
        {
            _meneger = meneger;
        }
        public string Invoke()
        {
            return _meneger
                .OrderService
                .NumberOfInProcess
                .ToString();
        }
    }
}