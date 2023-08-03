namespace Newme.ClientFavorites.Application.Commands
{
	public abstract class WishlistCommand : Command
	{
        protected WishlistCommand(Guid clientId)
        {
            ClientId = clientId;
        }

        public Guid ClientId { get; protected set; }
    }
}