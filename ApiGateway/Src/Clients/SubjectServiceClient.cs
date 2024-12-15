using System.Threading.Tasks;
using Grpc.Net.Client;
using Shared.Library.Protos;
using ApiGateway.Src.Clients.Interfaces;
using System.Threading.Channels;
using Grpc.Core;
using System.Threading.Tasks;

namespace ApiGateway.Src.Clients
{
    public class SubjectServiceClient : ISubjectServiceClient
    {
        private readonly SubjectGrpc.SubjectGrpcClient _client;

        public SubjectServiceClient()
        {
            _client = new SubjectGrpc.SubjectGrpcClient(GrpcChannel.ForAddress("http://localhost:5375"));
        }

        public async Task<GetAllResponse> GetAllAsync()
        {
            return _client.GetAll(new Empty());
        }

        public async Task<GetAllRelationshipsResponse> GetAllRelationshipsAsync()
        {
            return _client.GetAllRelationships(new Empty());
        }

        public async Task<GetAllPrerequisitesResponse> GetAllPrerequisitesAsync()
        {
            return _client.GetAllPrerequisites(new Empty());
        }

        public async Task<GetAllPostRequisitesResponse> GetAllPostRequisitesAsync()
        {
            return _client.GetAllPostRequisites(new Empty());
        }
    }
}