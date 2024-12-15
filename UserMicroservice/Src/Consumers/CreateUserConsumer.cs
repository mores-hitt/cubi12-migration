using MassTransit;
using Shared.Library.Messages;
using user_microservice.Src.Repositories.Interfaces;
using user_microservice.Src.Models;

namespace user_microservice.Src.Consumers
{
    public class CreateUserConsumer : IConsumer<UserCreatedMessage>
    {
        private readonly IUnitOfWork _unitOfWork;

        public CreateUserConsumer(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task Consume(ConsumeContext<UserCreatedMessage> context)
        {
            var message = context.Message;
            Console.WriteLine($"Received message: {message.Name}");
            var user = new User
            {
                Name = message.Name,
                RUT = message.RUT,
                FirstLastName = message.FirstLastName,
                SecondLastName = message.SecondLastName,
                Email = message.Email,
                HashedPassword = message.Password,
                RoleId = message.RoleId,
                CareerId = message.CareerId,
            };
            await _unitOfWork.UsersRepository.Insert(user);

            return;
        }
    }
}