using Contracts.Web.Common;
using Microsoft.AspNetCore.Mvc.Filters;

namespace Contracts.Web.Attributes
{
    [AttributeUsage(AttributeTargets.All)]
    public class RequiredScopeAttribute(string scope) : Attribute, IAuthorizationFilter
    {
        private readonly string _scope = scope;

        public void OnAuthorization(AuthorizationFilterContext context)
        {
            var user = context.HttpContext.User;

            var scopeClaim = user.FindFirst("scope");
            if (scopeClaim == null || !scopeClaim.Value.Split(' ').Contains(_scope))
            {
                context.Result = new CustomForbidResult($"Scope {scopeClaim} not available on user {user!.Identity!.Name}.");
            }
        }
    }
}
