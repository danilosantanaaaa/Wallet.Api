using FriendlyResult;
using FriendlyResult.Enums;

using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace Wallet.Api.Controllers;

[ApiController]
public abstract class ApiController : ControllerBase
{
    [NonAction]
    public IActionResult Problem(List<Error> errors)
    {
        if (errors.Count is 0)
        {
            return Problem();
        }

        if (errors.All(e => e.TypeError == TypeErrorEnum.Validation))
        {
            return ValidationProblem(errors);
        }

        return Problem(errors.First());
    }

    [NonAction]
    public IActionResult Problem(Error error)
    {
        var statusCode = error.TypeError switch
        {
            TypeErrorEnum.Validation => StatusCodes.Status422UnprocessableEntity,
            TypeErrorEnum.NotFound => StatusCodes.Status404NotFound,
            TypeErrorEnum.Conflict => StatusCodes.Status409Conflict,
            TypeErrorEnum.Inauthorized => StatusCodes.Status401Unauthorized,
            _ => StatusCodes.Status500InternalServerError
        };

        return Problem(
            detail: error.Description,
            statusCode: statusCode
        );
    }
    
    [NonAction]
    public IActionResult ValidationProblem(List<Error> erros)
    {
        ModelStateDictionary modelState = new ModelStateDictionary();
        foreach (Error error in erros)
        {
            modelState.AddModelError(error.Code, error.Description);
        }

        return ValidationProblem(modelState);
    }
}