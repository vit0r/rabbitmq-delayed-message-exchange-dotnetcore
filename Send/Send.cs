using System;
using RabbitMQ.Client;
using System.Text;
using System.Collections.Generic;

class Send
{
  public static void Main()
  {
    var exchangeHello = "exchangeHello";
    var delayBind = "delayBind";
    var queueName = "queueHello";

    var factory = new ConnectionFactory() { HostName = "localhost" };
    using (var connection = factory.CreateConnection())
    using (var channel = connection.CreateModel())
    {
      IDictionary<string, object> args = new Dictionary<string, object> { { "x-delayed-type", "direct" } };
      channel.ExchangeDeclare(exchangeHello, "x-delayed-message", true, false, args);

      var queue = channel.QueueDeclare(queue: queueName, durable: false, exclusive: false, autoDelete: false, arguments: null);
      channel.QueueBind(queue, exchangeHello, delayBind);

      var basicProperties = channel.CreateBasicProperties();
      basicProperties.Headers = new Dictionary<string, object> { { "x-delay", 8000 } };

      var message = String.Format("Test delay exchange - {0}", DateTime.Now.ToString());
      var body = Encoding.UTF8.GetBytes(message);

      channel.BasicPublish(exchange: exchangeHello, routingKey: delayBind, basicProperties: basicProperties, body: body);

      Console.WriteLine(" [x] Sent {0}", message);
    }

    Console.ReadLine();
  }
}