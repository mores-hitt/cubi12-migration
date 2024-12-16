using MassTransit;
using Shared.Library.Messages;
using user_microservice.Src.Services.Interfaces;
using user_microservice.Src.Repositories.Interfaces;
using user_microservice.Src.Exceptions;

namespace user_microservice.Src.Consumers
{
    public class UpdatePasswordConsumer : IConsumer<UpdatePasswordMessage>
    {
        private readonly IUnitOfWork _unitOfWork;

        public UpdatePasswordConsumer(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task Consume(ConsumeContext<UpdatePasswordMessage> context)
        {
            var message = context.Message;
            Console.WriteLine($"Received message: {message.Id}");
            var user = await _unitOfWork.UsersRepository.GetByID(message.Id);
            if(user is null)
            {
                throw new EntityNotFoundException($"User with id: {message.Id} not found");
            }
            user.HashedPassword = message.Password;
            await _unitOfWork.UsersRepository.Update(user);
            return;
        }
    }
}