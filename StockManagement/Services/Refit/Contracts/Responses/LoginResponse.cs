namespace StockManagement.Services.Refit.Contracts.Responses
{
    public class LoginResponse
    {
        public string Token{get;set;}
        public User UserInfo {get;set;}
    }
}