using MassTransit;
using Shared.Library.Messages;

namespace user_microservice.Src.Consumers
{
    public class UpdatePasswordConsumer : IConsumer<UpdatePasswordMessage>
    {
        public Task Consume(ConsumeContext<UpdatePasswordMessage> context)
        {
            var message = context.Message;
            Console.WriteLine($"Received message: {message.Id}");
            return Task.CompletedTask;
        }
    }
}