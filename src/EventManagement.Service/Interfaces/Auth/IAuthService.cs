﻿using EventManagement.Service.Dtos.Auth;

namespace EventManagement.Service.Interfaces.Auth
{
    public interface IAuthService
    {
        public Task<(bool Result, int cachedMinutes)> RegisterAsync(RegisterDto dto);

        public Task<(bool Result, int CachedVerificationMinutes)> SendCodeForRegisterAsync(string email);

        public Task<(bool Result, string Token)> VerifyRegisterAsync(string email, int code);

        public Task<(bool Result, string Token)> LoginAsync(LoginDto dto);
    }
}