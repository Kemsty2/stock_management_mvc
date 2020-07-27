using Microsoft.AspNetCore.Authorization;

namespace StockManagement.Security
{
    public class CustomUserRequireClaim : IAuthorizationRequirement
    {
        public string ClaimType { get; }

        public CustomUserRequireClaim(string claimType)
        {
            ClaimType = claimType;
        }
    }
}