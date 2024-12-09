using Career.Src.Models;
using Shared.Library.Protos;
using Google.Protobuf.Collections;

namespace Career.Src.Services.Interfaces
{
    public interface ICareersService
    {
        public Task<RepeatedField<Shared.Library.Protos.Career>> GetAll();

    }
}