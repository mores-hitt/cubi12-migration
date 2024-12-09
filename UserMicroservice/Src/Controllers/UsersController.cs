using Grpc.Core;
using Shared.Library.Protos;

using user_microservice.Src.Services.Interfaces;

namespace user_microservice.Src.Controllers
{
    public class UsersController : UserGrpc.UserGrpcBase
    {
        private readonly IUsersService _usersService;

        public UsersController(IUsersService usersService)
        {
            _usersService = usersService;
        }

        public override Task<UserDto> GetProfile(Empty request, ServerCallContext context)
        {
            return _usersService.GetProfile(context);
        }

        public override async Task<UserDto> EditProfile(EditProfileDto request, ServerCallContext context)
        {
            return await _usersService.EditProfile(request, context);
        }

        public override async Task<GetUserProgressResponse> GetUserProgress(Empty request, ServerCallContext context)
        {
            var userProgress = await _usersService.GetUserProgress(context);
            return new GetUserProgressResponse
            {
                UserProgress = { userProgress }
            };

        }
    
        public override async Task<Empty> SetUserProgress(UpdateUserProgressDto request, ServerCallContext context)
        {
            await _usersService.SetUserProgress(request, context);
            return new Empty();
        }
    
    }
}

//token:
//eyJhbGciOiJodHRwOi8vd3d3LnczLm9yZy8yMDAxLzA0L3htbGRzaWctbW9yZSNobWFjLXNoYTI1NiIsInR5cCI6IkpXVCJ9.eyJodHRwOi8vc2NoZW1hcy54bWxzb2FwLm9yZy93cy8yMDA1LzA1L2lkZW50aXR5L2NsYWltcy9lbWFpbGFkZHJlc3MiOiJmZXJuYUBob3RtYWlsLmNvbSIsImh0dHA6Ly9zY2hlbWFzLm1pY3Jvc29mdC5jb20vd3MvMjAwOC8wNi9pZGVudGl0eS9jbGFpbXMvcm9sZSI6InN0dWRlbnQiLCJleHAiOjE3MzA2OTgxNTl9.q1K_vXPCS7fabYSAtYxIDXxhGcHXEEQ61yx0EC_Cnhg

/*
TOKENS INSANOS
eyJhbGciOiJodHRwOi8vd3d3LnczLm9yZy8yMDAxLzA0L3htbGRzaWctbW9yZSNobWFjLXNoYTI1NiIsInR5cCI6IkpXVCJ9.eyJodHRwOi8vc2NoZW1hcy54bWxzb2FwLm9yZy93cy8yMDA1LzA1L2lkZW50aXR5L2NsYWltcy9lbWFpbGFkZHJlc3MiOiJmZXJuYUBob3RtYWlsLmNvbSIsImh0dHA6Ly9zY2hlbWFzLm1pY3Jvc29mdC5jb20vd3MvMjAwOC8wNi9pZGVudGl0eS9jbGFpbXMvcm9sZSI6InN0dWRlbnQiLCJleHAiOjE3Mzc2ODA1Mjh9.AukDARtv_KyLNZYuGnIJYN8y-XgSIoAQSSJB2PNdTs0
eyJhbGciOiJodHRwOi8vd3d3LnczLm9yZy8yMDAxLzA0L3htbGRzaWctbW9yZSNobWFjLXNoYTI1NiIsInR5cCI6IkpXVCJ9.eyJodHRwOi8vc2NoZW1hcy54bWxzb2FwLm9yZy93cy8yMDA1LzA1L2lkZW50aXR5L2NsYWltcy9lbWFpbGFkZHJlc3MiOiJmZXJuYUBob3RtYWlsLmNvbSIsImh0dHA6Ly9zY2hlbWFzLm1pY3Jvc29mdC5jb20vd3MvMjAwOC8wNi9pZGVudGl0eS9jbGFpbXMvcm9sZSI6InN0dWRlbnQiLCJleHAiOjE3Mzc2ODA1NjV9.OkFTKxz1FhhrDwEeJGtWiV05y3GKyD9Ry54n8UuzpEM
eyJhbGciOiJodHRwOi8vd3d3LnczLm9yZy8yMDAxLzA0L3htbGRzaWctbW9yZSNobWFjLXNoYTI1NiIsInR5cCI6IkpXVCJ9.eyJodHRwOi8vc2NoZW1hcy54bWxzb2FwLm9yZy93cy8yMDA1LzA1L2lkZW50aXR5L2NsYWltcy9lbWFpbGFkZHJlc3MiOiJmZXJuYUBob3RtYWlsLmNvbSIsImh0dHA6Ly9zY2hlbWFzLm1pY3Jvc29mdC5jb20vd3MvMjAwOC8wNi9pZGVudGl0eS9jbGFpbXMvcm9sZSI6InN0dWRlbnQiLCJleHAiOjE3Mzc2ODA1ODF9.BrpajBVuwkr5qfcrHDq8hXkg6mdHH5hqFd9KKoG_OFg
*/