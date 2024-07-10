using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Contracts.Web.Http.Common
{
    public class CustomForbidResult : ObjectResult
    {
        public CustomForbidResult(string message) : base(new { Message = message })
        {
            StatusCode = StatusCodes.Status403Forbidden;
        }
    }
}
