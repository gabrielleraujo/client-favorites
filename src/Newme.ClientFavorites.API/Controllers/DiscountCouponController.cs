using System.Net;
using FluentValidation.Results;
using Microsoft.AspNetCore.Mvc;
using Newme.ClientFavorites.Application.InputModels.ShoopingCart;
using Newme.ClientFavorites.Application.Services;

namespace Newme.ClientFavorites.API.Controllers;

[ApiController]
[ApiVersion("1.0")]
[ApiExplorerSettings(GroupName = "v1")]
[Route("api/v{version:apiVersion}/discount-coupon")]
public class DiscountCouponController : ControllerBase
{
    private readonly IDiscountCouponService _service;

    public DiscountCouponController(IDiscountCouponService service)
    {
        _service = service;
    }

    [HttpPost]
    [ProducesResponseType(typeof(void), (int)HttpStatusCode.NoContent)]
    [ProducesResponseType(typeof(ValidationResult), (int)HttpStatusCode.BadRequest)]
    [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
    public async Task<ActionResult> RegisterAsync([FromBody] RegisterDiscountCouponInputModel inputModel)
    {
        var response = await _service.RegisterAsync(inputModel);
        return response.Errors.Count == 0 ? NoContent() : BadRequest(response);
    }
}
