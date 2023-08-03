namespace Newme.ClientFavorites.Domain.Entities.ShoopingCart
{
    public record ShoopingCartProduct(
        Guid ProductId,
        Guid ClientId,
        int Quantity,
        double UnitPrice);
}