namespace Newme.ClientFavorites.Domain.Messaging
{
    public interface IMessageBusServer
    {
        void Publish(object data, string routingKey);
    }
}
