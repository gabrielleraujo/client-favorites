using System.Net;
using FluentValidation.Results;
using Microsoft.AspNetCore.Mvc;
using Newme.ClientFavorites.Application.InputModels.ShoopingCart;
using Newme.ClientFavorites.Application.Services;
using Newme.ClientFavorites.Application.ViewModels.ShoopingCart;

namespace Newme.ClientFavorites.API.Controllers;

[ApiController]
[ApiVersion("1.0")]
[ApiExplorerSettings(GroupName = "v1")]
[Route("api/v{version:apiVersion}/shooping-cart")]
public class ShoopingCartController : ControllerBase
{
    private readonly IShoopingCartService _service;

    public ShoopingCartController(IShoopingCartService service)
    {
        _service = service;
    }
    
    [HttpGet]
    [ProducesResponseType(typeof(ReadShoppingCartViewModel), (int)HttpStatusCode.OK)]
    [ProducesResponseType((int)HttpStatusCode.NotFound)]
    [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
    public async Task<ActionResult> GetAsync(Guid clientId)
    {
        var response = await _service.GetAsync(clientId);
        return response == null ? NotFound() : Ok(response);
    }


    [HttpGet("calculate-discount-coupon")]
    [ProducesResponseType(typeof(ReadShoppingCartViewModel), (int)HttpStatusCode.OK)]
    [ProducesResponseType(typeof(string), (int)HttpStatusCode.BadRequest)]
    [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
    public async Task<ActionResult> CalculateDiscountCouponAsync([FromQuery] CalculateDiscountCouponInputModel inputModel)
    {
        var response = await _service.CalculateDiscountCouponAsync(inputModel);
        return response.IsT0 ? Ok(response.Value) : BadRequest(response.Value);
    }

    [HttpPost("insert")]
    [ProducesResponseType(typeof(void), (int)HttpStatusCode.NoContent)]
    [ProducesResponseType(typeof(ValidationResult), (int)HttpStatusCode.BadRequest)]
    [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
    public async Task<ActionResult> UpsertAsync([FromBody] InsertShoopingCartInputModel inputModel)
    {
        var response = await _service.UpsertAsync(inputModel);
        return response.Errors.Count == 0 ? NoContent() : BadRequest(response);
    }

    [HttpDelete("clean")]        
    [ProducesResponseType(typeof(void), (int)HttpStatusCode.NoContent)]
    [ProducesResponseType(typeof(ValidationResult), (int)HttpStatusCode.BadRequest)]
    [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
    public async Task<IActionResult> CleanAsync([FromQuery] Guid clientId)
    {
        var response = await _service.CleanAsync(clientId);
        return response.Errors.Count == 0 ? NoContent() : BadRequest(response);
    }
}
