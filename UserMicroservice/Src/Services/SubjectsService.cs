using Google.Protobuf.Collections;
using Shared.Library.Protos;
using user_microservice.Src.Models;
using user_microservice.Src.Repositories.Interfaces;
using user_microservice.Src.Services.Interfaces;

namespace user_microservice.Src.Services
{
    public class SubjectsService : ISubjectsService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapperService _mapperService;
        private readonly IAuthService _authService;

        public SubjectsService(IUnitOfWork unitOfWork, IMapperService mapperService
        , IAuthService authService
        )
        {
            _unitOfWork = unitOfWork;
            _mapperService = mapperService;
            _authService = authService;
        }

        public async Task<RepeatedField<SubjectDto>> GetAll()
        {
            var subjects = await _unitOfWork.SubjectsRepository.Get();

            var token = _authService.CreateToken("ferna@hotmail.com", "student");
            Console.WriteLine(token);

            return _mapperService.MapRepeatedField<Subject, SubjectDto>(subjects);
        }


        public async Task<RepeatedField<SubjectRelationshipDto>> GetAllRelationships()
        {
            var relationships = await _unitOfWork.SubjectRelationshipsRepository.Get();
            return _mapperService.MapRepeatedField<SubjectRelationship, SubjectRelationshipDto>(relationships);
        }

        public async Task<MapField<string, PrerequisiteDto>> GetAllPrerequisites()
        {
            var relationshipsList = await _unitOfWork.SubjectRelationshipsRepository.Get();
            var dictionary = new MapField<string, PrerequisiteDto>();

            relationshipsList.ForEach(r =>
            {
                if (!dictionary.ContainsKey(r.SubjectCode))
                {
                    var preRequisites = new PrerequisiteDto();
                    preRequisites.PreSubjectCode.Add(r.PreSubjectCode);

                    dictionary.Add(r.SubjectCode, preRequisites);
                } else {
                    dictionary[r.SubjectCode].PreSubjectCode.Add(r.PreSubjectCode);
                }
            });

            return dictionary;
        }

        public async Task<MapField<string, PostRequisiteDto>> GetAllPostRequisites()
        {
            var relationshipsList = await _unitOfWork.SubjectRelationshipsRepository.Get();
            var dictionary = new MapField<string, PostRequisiteDto>();

            relationshipsList.ForEach(r => 
            {
                if (!dictionary.ContainsKey(r.PreSubjectCode))
                {
                    var postRequisites = new PostRequisiteDto();
                    postRequisites.PostSubjectCode.Add(r.SubjectCode);

                    dictionary.Add(r.PreSubjectCode, postRequisites);
                } else {
                    dictionary[r.PreSubjectCode].PostSubjectCode.Add(r.SubjectCode);
                }
            });

            return dictionary;
        }
    }
}