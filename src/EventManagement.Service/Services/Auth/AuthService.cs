using EventManagement.DataAccess.Interfaces.Users;
using EventManagement.Domain.Entities.Users;
using EventManagement.Domain.Exceptions.Auth;
using EventManagement.Domain.Exceptions.Users;
using EventManagement.Service.Common.Helpers;
using EventManagement.Service.Common.Security;
using EventManagement.Service.Dtos.Auth;
using EventManagement.Service.Dtos.Security;
using EventManagement.Service.Interfaces.Auth;
using EventManagement.Service.Interfaces.Common;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Caching.Memory;

namespace EventManagement.Service.Services.Auth
{
    public class AuthService : IAuthService
    {
        private readonly IUserRepository _repository;
        private readonly IMemoryCache _memoryCache;
        private readonly IFileService _fileService;
        private readonly ITokenService _tokenService;
        private const int CACHED_MINUTES_FOR_REGISTER = 60;
        private const int CACHED_MINUTES_FOR_VERIFICATION = 5;
        private const string REGISTER_CACHE_KEY = "register_";
        private const string VERIFY_REGISTER_CACHE_KEY = "verify_register_";
        private const int VERIFICATION_MAXIMUM_ATTEMPTS = 3;

        public AuthService(
            IUserRepository repository,
            IMemoryCache memoryCache,
            IFileService fileService,
            ITokenService tokenService)
        {
            this._repository = repository;
            this._memoryCache = memoryCache;
            this._fileService = fileService;
            this._tokenService = tokenService;
        }

        #pragma warning disable
        public async Task<(bool Result, int cachedMinutes)> RegisterAsync(RegisterDto dto)
        {
            var user = await _repository.GetByEmailAsync(dto.Email);
            if (user is not null) throw new UserAlreadyExistException();

            if (_memoryCache.TryGetValue(REGISTER_CACHE_KEY + dto.Email, out RegisterDto cachedRegisterDto))
            {
                cachedRegisterDto.FirstName = cachedRegisterDto.FirstName;
                _memoryCache.Remove(dto.Email);
            }

            else _memoryCache.Set(REGISTER_CACHE_KEY + dto.Email, dto,
                TimeSpan.FromMinutes(CACHED_MINUTES_FOR_REGISTER));

            return (Result: true, cachedMinutes: CACHED_MINUTES_FOR_REGISTER);
        }

        public async Task<(bool Result, int CachedVerificationMinutes)> SendCodeForRegisterAsync(string email)
        {
            if (_memoryCache.TryGetValue(email, out RegisterDto registerDto))
            {
                VerificationDto verificationDto = new VerificationDto();
                verificationDto.Attempt = 0;
                verificationDto.CreatedAt = TimeHelper.GetDateTime();
                verificationDto.Code = 11111;
                _memoryCache.Set(email, verificationDto, TimeSpan.FromMinutes(CACHED_MINUTES_FOR_VERIFICATION));
                return (Result: true, cachedVerificationMinutes: CACHED_MINUTES_FOR_VERIFICATION);
            }

            else throw new UserCacheDataExpiredException();
        }

        public async Task<(bool Result, string Token)> VerifyRegisterAsync(string email, int code)
        {
            if (_memoryCache.TryGetValue(REGISTER_CACHE_KEY + email, out RegisterDto registerDto))
            {
                if (_memoryCache.TryGetValue(VERIFY_REGISTER_CACHE_KEY + email, out VerificationDto verificationDto))
                {
                    if (verificationDto.Attempt >= VERIFICATION_MAXIMUM_ATTEMPTS)
                        throw new VerificationTooManyRequestException();

                    else if (verificationDto.Code == code)
                    {
                        verificationDto.Code = 11111;
                        var dbResult = await RegisterToDatabaseAsync(registerDto);
                        if (dbResult is true)
                        {
                            var user = await _repository.GetByEmailAsync(email);
                            string token = _tokenService.GenerateToken(user);
                            return (Result: true, token: token);
                        }
                        else return (Result: false, Token: "");
                    }
                    else
                    {
                        _memoryCache.Remove(REGISTER_CACHE_KEY + email);
                        verificationDto.Attempt++;

                        _memoryCache.Set(VERIFY_REGISTER_CACHE_KEY + email, verificationDto,
                            TimeSpan.FromMinutes(CACHED_MINUTES_FOR_VERIFICATION));

                        return (Result: false, Token: "");
                    }
                }
                else throw new VerificationCodeExpiredException();
            }
            else throw new UserCacheDataExpiredException();
        }

        private async Task<bool> RegisterToDatabaseAsync(RegisterDto registerDto)
        {
            var user = new User();
            string imagePath = await _fileService.UploadImageAsync(registerDto.Image);
            user.FirstName = registerDto.FirstName;
            user.LastName = registerDto.LastName;
            user.Email = registerDto.Email;
            user.UserName = "";
            user.ImagePath = imagePath;
            var hasherResult = PasswordHasher.Hash(registerDto.Password);
            user.PasswordHash = hasherResult.Hash;
            user.Salt = hasherResult.Salt;
            user.CreatedAt = user.UpdatedAt = TimeHelper.GetDateTime();
            var dbResult = await _repository.CreateAsync(user);

            return dbResult > 0;
        }

        public async Task<(bool Result, string Token)> LoginAsync(LoginDto loginDto)
        {
            var user = await _repository.GetByEmailAsync(loginDto.Email);
            if (user is null) throw new UserNotFoundException();
            var hasherResult = PasswordHasher.Verify(loginDto.Password, user.PasswordHash, user.Salt);
            if (hasherResult == false) throw new PasswordNotMatchException();
            var token = _tokenService.GenerateToken(user);
            return (Result: true, Token: token);
        }
    }
}