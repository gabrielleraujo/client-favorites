using System.Text;
using Microsoft.Extensions.Hosting;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using Newtonsoft.Json;
using Microsoft.Extensions.DependencyInjection;
using MediatR;
using Newme.ClientFavorites.Domain.Messaging;
using Newme.ClientFavorites.Application.Subscribers.Events;
using Newme.ClientFavorites.Application.Commands.UpdateClientFavoritesAfterProductDeativated;

namespace Newme.ClientFavorites.Application.Subscribers
{
    public class DeactivatedProductSubscriber : BackgroundService
    {
        private readonly IConnection _connection;
        private readonly IModel _channel;
        private const string Queue = "client-favorites-service/catalog-deactivated-product";
        private const string RoutingKeySubscribe = "catalog-deactivated-product";
        private readonly IServiceProvider _serviceProvider;
        private const string TrackingsExchange = "client-favorites-service";
 
        public DeactivatedProductSubscriber(IServiceProvider serviceProvider)
        {
            var connectionFactory = new ConnectionFactory
            {
                HostName = "localhost"
            };
 
            _connection = connectionFactory.CreateConnection("catalog-deactivated-product-consumer");
 
            _channel = _connection.CreateModel();
 
            _channel.QueueDeclare(
                queue: Queue,
                durable: true,
                exclusive: false,
                autoDelete: false);
 
            _channel.QueueBind(Queue, TrackingsExchange, RoutingKeySubscribe);
 
            _serviceProvider = serviceProvider;
        }
 
        protected override Task ExecuteAsync(CancellationToken stoppingToken)
        {
            var consumer = new EventingBasicConsumer(_channel);
 
            consumer.Received += async (sender, eventArgs) =>
            {
                var contentArray = eventArgs.Body.ToArray();
                var contentString = Encoding.UTF8.GetString(contentArray);
                var @event = JsonConvert.DeserializeObject<DeactivatedProductReceivedEvent>(contentString);
 
                Console.WriteLine($"Message catalog-deactivated-product event is received with product id: {@event!.ProductId}");
 
                Complete(@event).Wait();
 
                _channel.BasicAck(eventArgs.DeliveryTag, false);
            };
 
            _channel.BasicConsume(Queue, false, consumer);
 
            return Task.CompletedTask;
        }
 
        public async Task Complete(DeactivatedProductReceivedEvent @event)
        {
            using var scope = _serviceProvider.CreateScope();

            var messageBus = scope.ServiceProvider.GetRequiredService<IMessageBusServer>();
            var mediator = scope.ServiceProvider.GetRequiredService<IMediator>();

            var command = new UpdateClientFavoritesAfterProductDeativatedCommand(@event);
            var response = await mediator.Send(command);
        }
    }
}
