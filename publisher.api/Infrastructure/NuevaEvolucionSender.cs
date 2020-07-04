using System.Text;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using publisher.api;
using publisher.api.Infrastructure.Messaging;
using publisher.api.Infrastructure.Messaging.Options;
using RabbitMQ.Client;

namespace publisher.api.Infrastructure.Messaging
{
    public class NuevaEvolucionSender : INuevaEvolucionSender
    {
        private readonly string _hostname;
        private readonly string _queueName;
        private readonly string _username;
        private readonly string _password;

        public NuevaEvolucionSender(IOptions<RabbitMqConfiguration> rabbitMqOptions)
        {
            _hostname = rabbitMqOptions.Value.Hostname;
            _queueName = rabbitMqOptions.Value.QueueName;
            _username = rabbitMqOptions.Value.UserName;
            _password = rabbitMqOptions.Value.Password;
        }

        public void SendCustomer(EvolucionMessage customer)
        {
            var factory = new ConnectionFactory() { HostName = _hostname, UserName = _username, Password = _password };
            
            using (var connection = factory.CreateConnection())
            using (var channel = connection.CreateModel())
            {
                channel.QueueDeclare(queue: _queueName, durable: false, exclusive: false, autoDelete: false, arguments: null);

                var json = JsonConvert.SerializeObject(customer);
                var body = Encoding.UTF8.GetBytes(json);

                channel.BasicPublish(exchange: "", routingKey: _queueName, basicProperties: null, body: body);
            }
        }
    }
}
