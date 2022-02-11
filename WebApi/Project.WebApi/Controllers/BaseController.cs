using Microsoft.AspNetCore.Mvc;

namespace Project.WebApi.Controllers;

public class BaseController : ControllerBase
{
    protected BaseController()
    {

    }

    protected Guid UniqueIdentifier
    {
        get
        {
            if (Request.Headers.TryGetValue(Const.UniqueIdentifierKey, out var value))
            {
                if (Guid.TryParse(value, out var uniqueIdentifier))
                {
                    return uniqueIdentifier;
                }

                throw new UnauthorizedAccessException("Unique identifier value is corrupted or incorrect.");
            }

            throw new UnauthorizedAccessException("Unique indentifier is missing");
        }
    }
}
