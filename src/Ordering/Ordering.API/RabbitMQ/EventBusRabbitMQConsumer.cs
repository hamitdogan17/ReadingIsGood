using AutoMapper;
using EventBusRabbitMQ;
using EventBusRabbitMQ.Common;
using EventBusRabbitMQ.Events;
using MediatR;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using Ordering.Application.Commands;
using Ordering.Core.Repositories;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System;
using System.Text;

namespace Ordering.API.RabbitMQ
{
    public class EventBusRabbitMQConsumer
    {
        private readonly IRabbitMQConnection _rabbitMQConnection;
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;
        private readonly IOrderRepository _orderRepository;
        private readonly ILogger<EventBusRabbitMQConsumer> _logger;

        public EventBusRabbitMQConsumer(IRabbitMQConnection rabbitMQConnection, IMediator mediator, IMapper mapper, IOrderRepository orderRepository, ILogger<EventBusRabbitMQConsumer> logger)
        {
            _rabbitMQConnection = rabbitMQConnection;
            _mediator = mediator;
            _mapper = mapper;
            _orderRepository = orderRepository;
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }
        
        public void Consume()
        {
            var channel = _rabbitMQConnection.CreateModel();
            channel.QueueDeclare(queue: EventBusConstants.BasketCheckoutQueue, durable: false, exclusive: false, autoDelete: false, arguments: null);

            var consumer = new EventingBasicConsumer(channel);
            consumer.Received += ReceivedEvent;

            channel.BasicConsume(queue: EventBusConstants.BasketCheckoutQueue, autoAck: true, consumer: consumer);
        }

        private async void ReceivedEvent(object sender, BasicDeliverEventArgs e)
        {
            if (e.RoutingKey == EventBusConstants.BasketCheckoutQueue)
            {
                var message = Encoding.UTF8.GetString(e.Body.Span);
                var basketCheckoutEvent = JsonConvert.DeserializeObject<BasketCheckoutEvent>(message);

                var command = _mapper.Map<CheckoutOrderCommand>(basketCheckoutEvent);
                var result = await _mediator.Send(command);

                _logger.LogInformation("EventBusRabbitMQConsumer consumed successfully. Created Order Id : {newOrderId}", result);
            }
        }

        public void Disconnect()
        {
            _rabbitMQConnection.Dispose();
        }
    }
}
