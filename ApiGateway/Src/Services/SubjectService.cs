using ApiGateway.Src.Services.Interfaces;
using ApiGateway.Src.Clients.Interfaces;
using Shared.Library.Protos;

namespace ApiGateway.Src.Services
{
    public class SubjectService : ISubjectService
    {
        private readonly ISubjectServiceClient _subjectServiceClient;

        private readonly IAuthServiceClient _authServiceClient;

        private readonly IHttpContextAccessor _ctxAccessor;

        public SubjectService(ISubjectServiceClient subjectServiceClient, IAuthServiceClient authServiceClient, IHttpContextAccessor ctxAccessor)
        {
            _subjectServiceClient = subjectServiceClient;
            _authServiceClient = authServiceClient;
            _ctxAccessor = ctxAccessor;
        }

        public async Task<List<ApiGateway.Src.DTOs.Subjects.SubjectDto>> GetAll()
        {
            var token = ExtractToken();
            if (!await _authServiceClient.ValidateToken(token))
            {
                throw new UnauthorizedAccessException("Token invalido");
            }
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
            var token = ExtractToken();
            if (!await _authServiceClient.ValidateToken(token))
            {
                throw new UnauthorizedAccessException("Token invalido");
            }
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
            var token = ExtractToken();
            if (!await _authServiceClient.ValidateToken(token))
            {
                throw new UnauthorizedAccessException("Token invalido");
            }
            var response = await _subjectServiceClient.GetAllPrerequisitesAsync();
            if (response == null)
            {
                return new Dictionary<string, List<string>>();
            }

            return response.Prerequisites.ToDictionary(p => p.Key, p => p.Value.PreSubjectCode.ToList());
        }

        public async Task<Dictionary<string, List<string>>> GetAllPostRequisites()
        {
            var token = ExtractToken();
            if (!await _authServiceClient.ValidateToken(token))
            {
                throw new UnauthorizedAccessException("Token invalido");
            }
            var response = await _subjectServiceClient.GetAllPostRequisitesAsync();
            if (response == null)
            {
                return new Dictionary<string, List<string>>();
            }
            
            return response.PostRequisites.ToDictionary(p => p.Key, p => p.Value.PostSubjectCode.ToList());
    
        }

        public string ExtractToken()
        {
            var token = _ctxAccessor.HttpContext.Request.Headers["Authorization"].ToString()?.Split(" ").Last();
            if (string.IsNullOrEmpty(token))
            {
                throw new UnauthorizedAccessException("Token no encontrado");
            }
            return token;
        }
    }
}