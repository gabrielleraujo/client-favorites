namespace Newme.ClientFavorites.Application.InputModels.ShoopingCart
{
    public class DeleteShoopingCartInputModel
	{
        public Guid ClientId { get; set; }
        public Guid ProductId { get; set; }
	}
}