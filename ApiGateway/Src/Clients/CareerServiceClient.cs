using System.Threading.Tasks;
using Grpc.Net.Client;
using Shared.Library.Protos;
using ApiGateway.Src.Clients.Interfaces;
using System.Threading.Channels;

namespace ApiGateway.Src.Clients
{
    public class CareerServiceClient : ICareerServiceClient
    {
        private readonly CareerGrpc.CareerGrpcClient _client;

        public CareerServiceClient()
        {
            _client = new CareerGrpc.CareerGrpcClient(GrpcChannel.ForAddress("http://localhost:5375"));
        }

        public async Task<Careers> GetCareersAsync()
        {
            return _client.GetAll(new Empty());
        }
    }
}