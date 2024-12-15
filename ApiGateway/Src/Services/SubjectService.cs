using ApiGateway.Src.Services.Interfaces;
using ApiGateway.Src.Clients.Interfaces;
using Shared.Library.Protos;

namespace ApiGateway.Src.Services
{
    public class SubjectService : ISubjectService
    {
        private readonly ISubjectServiceClient _subjectServiceClient;

        public SubjectService(ISubjectServiceClient subjectServiceClient)
        {
            _subjectServiceClient = subjectServiceClient;
        }

        public async Task<List<ApiGateway.Src.DTOs.Subjects.SubjectDto>> GetAll()
        {
            var response = await _subjectServiceClient.GetAllAsync();
            if (response == null)
            {
                return new List<ApiGateway.Src.DTOs.Subjects.SubjectDto>();
            }
            return response.Subjects.Select(s => new ApiGateway.Src.DTOs.Subjects.SubjectDto
            {
                Id = s.Id,
                Code = s.Code,
                Name = s.Name,
                Department = s.Department,
                Credits = s.Credits,
                Semester = s.Semester
            }).ToList();
        }

        public async Task<List<ApiGateway.Src.DTOs.Subjects.SubjectRelationshipDto>> GetAllRelationships()
        {
            var response = await _subjectServiceClient.GetAllRelationshipsAsync();
            if (response == null)
            {
                return new List<ApiGateway.Src.DTOs.Subjects.SubjectRelationshipDto>();
            }
            return response.Relationships.Select(r => new ApiGateway.Src.DTOs.Subjects.SubjectRelationshipDto
            {
                Id = r.Id,
                SubjectCode = r.SubjectCode,
                PreSubjectCode = r.PreSubjectCode
            }).ToList();
        }

        public async Task<Dictionary<string, List<string>>> GetAllPrerequisites()
        {
            var response = await _subjectServiceClient.GetAllPrerequisitesAsync();
            if (response == null)
            {
                return new Dictionary<string, List<string>>();
            }

            return response.Prerequisites.ToDictionary(p => p.Key, p => p.Value.PreSubjectCode.ToList());
        }

        public async Task<Dictionary<string, List<string>>> GetAllPostRequisites()
        {
            var response = await _subjectServiceClient.GetAllPostRequisitesAsync();
            if (response == null)
            {
                return new Dictionary<string, List<string>>();
            }
            
            return response.PostRequisites.ToDictionary(p => p.Key, p => p.Value.PostSubjectCode.ToList());
    
        }
    }
}