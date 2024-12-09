using Grpc.Core;
using Shared.Library.Protos;

using user_microservice.Src.Services.Interfaces;


namespace user_microservice.Src.Controllers
{
    public class SubjectsController : SubjectGrpc.SubjectGrpcBase
    {
        private readonly ISubjectsService _subjectsService;

        public SubjectsController(ISubjectsService subjectsService)
        {
            _subjectsService = subjectsService;
        }

        public override async Task<GetAllResponse> GetAll(Empty request, ServerCallContext context)
        {
            var subjects = await _subjectsService.GetAll();

            var response = new GetAllResponse();

            response.Subjects.AddRange(subjects);

            return response;
        }

        public override async Task<GetAllRelationshipsResponse> GetAllRelationships(Empty request, ServerCallContext context)
        {
            var relationships = await _subjectsService.GetAllRelationships();

            var response = new GetAllRelationshipsResponse();

            response.Relationships.AddRange(relationships);

            return response;
        }

        public override async Task<GetAllPrerequisitesResponse> GetAllPrerequisites(Empty request, ServerCallContext context)
        {
            var prerequisites = await _subjectsService.GetAllPrerequisites();

            var response = new GetAllPrerequisitesResponse();

            response.Prerequisites.Add(prerequisites);

            return response;
        }

        public override async Task<GetAllPostRequisitesResponse> GetAllPostRequisites(Empty request, ServerCallContext context)
        {
            var postRequisites = await _subjectsService.GetAllPostRequisites();

            var response = new GetAllPostRequisitesResponse();

            response.PostRequisites.Add(postRequisites);

            return response;
        }
    }
}