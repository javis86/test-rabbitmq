﻿namespace subscriber.api.Infrastructure.Messaging.Options
{
    public class RabbitMqConfiguration
    {
        public string Hostname { get; set; }

        public string QueueName { get; set; }

        public string UserName { get; set; }

        public string Password { get; set; }
    }
}