using Microsoft.AspNetCore.Mvc;
using Services.Contracts;

namespace StoreApp.Components
{
    public class UserSummaryViewComponent : ViewComponent
    {
        private readonly IServiceManager _meneger;

        public UserSummaryViewComponent(IServiceManager meneger)
        {
            _meneger = meneger;
        }
        public string Invoke()
        {
            return _meneger
                .AuthService
                .GetAllUsers()
                .Count()
                .ToString();
        }
    }
}