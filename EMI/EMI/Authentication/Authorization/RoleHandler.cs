using Microsoft.AspNetCore.Authorization;
using System.Data;
using static EMI.Transversal.Enums.Enums;

namespace EMI.Authentication.Authorization
{
    public class RoleHandler : AuthorizationHandler<AuthorizeRoleRequirement>
    {
        protected override Task HandleRequirementAsync(AuthorizationHandlerContext context, AuthorizeRoleRequirement requirement)
        {
            if (context.User.IsInRole(RoleTypesEnum.Admin.ToString()))
            {
                context.Succeed(requirement);
            }
            else if (context.User.IsInRole(RoleTypesEnum.User.ToString()))
            {

                var httpMethod = context.Resource as HttpContext;
                if (httpMethod != null && httpMethod.Request.Method == "GET")
                {
                    context.Succeed(requirement);
                }
            }

            return Task.CompletedTask;
        }
    }
}
