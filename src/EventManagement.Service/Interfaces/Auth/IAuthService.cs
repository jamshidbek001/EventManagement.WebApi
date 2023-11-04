﻿using EventManagement.Service.Dtos.Auth;

namespace EventManagement.Service.Interfaces.Auth
{
    public interface IAuthService
    {
        public Task<(bool Result, int cachedMinutes)> RegisterAsync(RegisterDto dto);
    }
}