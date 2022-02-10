using Microsoft.AspNetCore.Mvc;

namespace Project.WebApi.Controllers
{
    public class BaseController : ControllerBase
    {
        protected Guid UniqueIdentifier
        {
            get
            {
                if (Request.Headers.TryGetValue(Const.UniqueKeyName, out var value))
                {
                    if (Guid.TryParse(value, out var uniqueIdentifier))
                    {
                        return uniqueIdentifier;
                    }
                    else
                    {
                        throw new ArgumentException(nameof(UniqueIdentifier));
                    }
                }

                throw new UnauthorizedAccessException();
            }
        }
    }
}
