using System.Collections.Generic;

namespace StockManagement.Services.Refit.Contracts.Responses
{
    public class User
    {
        public string Username;
        public string Fullname;
        public string Email;
        public List<string> Roles;
    }
}