using RabbitMQ.Client.Events;
using RabbitMQ.Client;
using System.Text;

namespace RabbitMqListener
{
    internal class Program
    {
        static void Main(string[] args)
        {
            new RabbitServer().RabbitReceiver();  
        }
    }
}