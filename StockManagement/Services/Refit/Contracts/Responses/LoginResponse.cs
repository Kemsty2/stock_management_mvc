using System;
using System.Collections.Generic;

namespace StockManagement.Services.Refit.Contracts.Responses
{
    public class LoginResponse
    {
        public Guid Id { get; set; }
        public string Name { get; set; }

        public string Username { get; set; }
        public string Email { get; set; }

        public string Token { get; set; }

        public ICollection<Role> Roles { get; set; }
    }
}