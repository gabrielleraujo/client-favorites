using System.Net;
using FluentValidation.Results;
using Microsoft.AspNetCore.Mvc;
using Newme.ClientFavorites.Application.InputModels.Wishlist;
using Newme.ClientFavorites.Application.Services;
using Newme.ClientFavorites.Application.ViewModels.ShoopingCart;

namespace Newme.ClientFavorites.API.Controllers;

[ApiController]
[ApiVersion("1.0")]
[ApiExplorerSettings(GroupName = "v1")]
[Route("api/v{version:apiVersion}/wishlist")]
public class WishlistController : ControllerBase
{
    private readonly IWishlistService _service;

    public WishlistController(IWishlistService service)
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

    [HttpPost]
    [ProducesResponseType(typeof(void), (int)HttpStatusCode.NoContent)]
    [ProducesResponseType(typeof(ValidationResult), (int)HttpStatusCode.BadRequest)]
    [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
    public async Task<ActionResult> UpsertAsync([FromBody] AddWishlistInputModel inputModel)
    {
        var response = await _service.AddAsync(inputModel);
        return response.Errors.Count == 0 ? NoContent() : BadRequest(response);
    }

    [HttpDelete("delete")]        
    [ProducesResponseType(typeof(void), (int)HttpStatusCode.NoContent)]
    [ProducesResponseType(typeof(ValidationResult), (int)HttpStatusCode.BadRequest)]
    [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
    public async Task<IActionResult> DeleteAsync([FromQuery] DeleteWishlistInputModel inputModel)
    {
        var response = await _service.DeleteAsync(inputModel);
        return response.Errors.Count == 0 ? NoContent() : BadRequest(response);
    }
}
