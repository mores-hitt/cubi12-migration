using System.Text.Json;
using ApiGateway.Src.Clients.Interfaces;
using ApiGateway.Src.DTOs.Resources;

namespace ApiGateway.Src.Clients
{
    public class LegacyServiceClient : ILegacyServiceClient
    {
        private readonly HttpClient _httpClient;

        private readonly string _baseUrl = "http://localhost:80/api/Resources";

        public LegacyServiceClient(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<List<SubjectResourceDto>> GetAllSubjectResources()
        {
            var response = await _httpClient.GetAsync(_baseUrl);
            response.EnsureSuccessStatusCode();

            switch (response.StatusCode)
            {
                case System.Net.HttpStatusCode.Unauthorized:
                    throw new UnauthorizedAccessException();
                case System.Net.HttpStatusCode.OK:
                    var content = await response.Content.ReadAsStringAsync();
                    return JsonSerializer.Deserialize<List<SubjectResourceDto>>(content, new JsonSerializerOptions 
                    {
                        PropertyNameCaseInsensitive = true
                    }) ?? new List<SubjectResourceDto>();
                default:
                    return new List<SubjectResourceDto>();
            }
        }

        public async Task<List<ResourceDto>> GetSubjectResourceById(int id)
        {
            var response = await _httpClient.GetAsync($"{_baseUrl}/{id}");
            response.EnsureSuccessStatusCode();

            switch (response.StatusCode)
            {
                case System.Net.HttpStatusCode.Unauthorized:
                    throw new UnauthorizedAccessException();
                case System.Net.HttpStatusCode.OK:
                    var content = await response.Content.ReadAsStringAsync();
                    return JsonSerializer.Deserialize<List<ResourceDto>>(content, new JsonSerializerOptions
                    {
                        PropertyNameCaseInsensitive = true
                    }) ?? new List<ResourceDto>();
                default:
                    return new List<ResourceDto>();
            }
        }
    }
}