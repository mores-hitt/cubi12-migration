using MassTransit;
using Shared.Library.Messages;

namespace user_microservice.Src.Consumers
{
    public class CreateUserConsumer : IConsumer<UserCreatedMessage>
    {
        public Task Consume(ConsumeContext<UserCreatedMessage> context)
        {
            var message = context.Message;
            Console.WriteLine($"Received message: {message.Name}");
            return Task.CompletedTask;
        }
    }
}