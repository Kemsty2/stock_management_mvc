using System.Security.Claims;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Authorization.Infrastructure;

namespace StockManagement.Security
{
    public class RolesAuthorizationHandler : AuthorizationHandler<RolesAuthorizationRequirement>
    {
        protected override Task HandleRequirementAsync(AuthorizationHandlerContext context, RolesAuthorizationRequirement requirement){
            if (context.User == null || !context.User.Identity.IsAuthenticated)  
            {  
                context.Fail();  
                return Task.CompletedTask;  
            }  
  
            var validRole = false;  
            if (requirement.AllowedRoles == null ||  
                requirement.AllowedRoles.Any() == false)  
            {  
                validRole = true;  
            }  
            else  
            {  
                var claims = context.User.Claims;  
                var userName = claims.FirstOrDefault(c => c.Type == "UserName").Value;  
                var userRoles = claims.Where(c => c.Type == ClaimTypes.Role);

                var roles = requirement.AllowedRoles;  
  
                //validRole = new Users().GetUsers().Where(p => roles.Contains(p.Role) && p.UserName == userName).Any();  
                validRole = userRoles.Where(c => roles.Contains(c.Value)).Any();
            }  
  
            if (validRole)  
            {  
                context.Succeed(requirement);  
            }  
            else  
            {  
                context.Fail();  
            }  
            return Task.CompletedTask; 
        }
    }
}