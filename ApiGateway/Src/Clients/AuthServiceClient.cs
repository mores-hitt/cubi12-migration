using System.Text.Json;
using ApiGateway.Src.Clients.Interfaces;
using ApiGateway.Src.DTOs.Auth;
using System.Text;

namespace ApiGateway.Src.Clients
{
    public class AuthServiceClient : IAuthServiceClient
    {
        private readonly HttpClient _httpClient;

        private readonly string _baseUrl;

        public AuthServiceClient(HttpClient httpClient,string baseUrl)
        {
            _httpClient = httpClient;
            _baseUrl = baseUrl;
        }

        public async Task<LoginResponseDto> PostLogin(LoginRequestDto loginCredential)
        {
            var content = new StringContent(JsonSerializer.Serialize(loginCredential), Encoding.UTF8, "application/json");
            var response = await _httpClient.PostAsync($"{_baseUrl}/api/Auth/login", content);

            if (!response.IsSuccessStatusCode)
            {
                var errorContent = await response.Content.ReadAsStringAsync();
                throw new HttpRequestException($"Error en la solicitud de inicio de sesión: {errorContent}");
            }

            var responseContent = await response.Content.ReadAsStringAsync();
            return JsonSerializer.Deserialize<LoginResponseDto>(responseContent, new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            }) ?? new LoginResponseDto();
        }

        public async Task<LoginResponseDto> PostRegister(RegisterStudentDto registerStudent)
        {
            var content = new StringContent(JsonSerializer.Serialize(registerStudent), Encoding.UTF8, "application/json");
            var response = await _httpClient.PostAsync($"{_baseUrl}/api/auth/register", content);

            if (!response.IsSuccessStatusCode)
            {
                var errorContent = await response.Content.ReadAsStringAsync();
                throw new HttpRequestException($"Error en la solicitud de registro de usuario: {errorContent}");
            }

            var responseContent = await response.Content.ReadAsStringAsync();
            return JsonSerializer.Deserialize<LoginResponseDto>(responseContent, new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            }) ?? new LoginResponseDto();
        }

        public async Task ChangePassword(UpdatePasswordDto updatePassword, string token)
        {
            if(await ValidateToken(token))
            {
                throw new UnauthorizedAccessException("Token no válido");
            }
            var content = new StringContent(JsonSerializer.Serialize(updatePassword), Encoding.UTF8, "application/json");
            var request = new HttpRequestMessage(HttpMethod.Put, $"{_baseUrl}/api/auth/update-password")
            {
                Content = content
            };
            request.Headers.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", token);

             var response = await _httpClient.SendAsync(request);

            if (!response.IsSuccessStatusCode)
            {
                var errorContent = await response.Content.ReadAsStringAsync();
                throw new HttpRequestException($"Error: {response.StatusCode}, Content: {errorContent
                }");
            }
        }

        public async Task<bool> ValidateToken(string token)
        {
            var request = new HttpRequestMessage(HttpMethod.Post, $"{_baseUrl}/api/auth/validate-token")
            {
                Content = new StringContent(JsonSerializer.Serialize(new { token }), Encoding.UTF8, "application/json")
            };

            var response = await _httpClient.SendAsync(request);

            Console.WriteLine(response.StatusCode);

            if (response.IsSuccessStatusCode)
            {
                Console.WriteLine("Token is valid");
                return true;
            }
            else if (response.StatusCode == System.Net.HttpStatusCode.Unauthorized)
            {
                Console.WriteLine("Token is invalid");
                return false;
            }
            else
            {
                Console.WriteLine("la logica esta mal");
                return false;
            }
        }
    }
}