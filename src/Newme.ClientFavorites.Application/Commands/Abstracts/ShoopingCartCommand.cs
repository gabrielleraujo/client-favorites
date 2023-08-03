namespace Newme.ClientFavorites.Application.Commands
{
    public abstract class ShoopingCartCommand : Command
    {
        protected ShoopingCartCommand(Guid clientId)
        {
            ClientId = clientId;
        }

        public Guid ClientId { get; set; }
    }
}
