using RabbitMQ.Client.Events;
using RabbitMQ.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json;

namespace RabbitMqListener
{
    public class RabbitServer
    {
        public void RabbitReciever()
        {
            var factory = new ConnectionFactory() { HostName = "localhost" };

            using (var connection = factory.CreateConnection())
            using (var channel = connection.CreateModel())
            {
                channel.QueueDeclare(queue: "MyQueue",
                                     durable: false,
                                     exclusive: false,
                                     autoDelete: false,
                                     arguments: null);

                var consumer = new EventingBasicConsumer(channel);
                consumer.Received += (model, ea) =>
                {
                    var body = ea.Body.ToArray();
                    var message = JsonSerializer.Deserialize < MailModel > (Encoding.UTF8.GetString(body));
                    Console.WriteLine(" [x] Received {0} {1}", message.Email,message.Message);
                    new MailSending().MessageSend(message);
                };
                channel.BasicConsume(queue: "MyQueue",
                                     autoAck: true,
                                     consumer: consumer);
                
                Console.WriteLine(" Press [enter] to exit.");
                Console.ReadLine();
            }
        }
    }
}
