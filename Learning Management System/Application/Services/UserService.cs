using AutoMapper;
using Learning_Management_System.Application.DTOs.UserDTO;
using Learning_Management_System.Application.Iservices;
using Learning_Management_System.Core.Entities;
using Learning_Management_System.Core.Exceptions;
using Learning_Management_System.Core.Interfaces;
using Learning_Management_System.Infrastructure.Caching;
using Microsoft.AspNetCore.Identity;

namespace Learning_Management_System.Application.Services
{
    public class UserService : IUserService
    {
        IMapper _mapper;
        IUserRepository _repository;
        ICacheService _cacheService;
        UserManager<User> _userManager;

        private const string CacheKey_All = "users";
        private const string CacheKey_Prefix = "user_";

        public UserService(IMapper mapper, IUserRepository repository, ICacheService cacheService, UserManager<User> userManager)
        {
            _mapper = mapper;
            _repository = repository;
            _cacheService = cacheService;
            _userManager = userManager;
        }

        public async Task<UserResponseDto> UpdateAsync(long userId, UpdateUserProfileDto dto)
        {
          

            var user = await _repository.GetByIdAsync(userId) ??
                throw new NotFoundException("user not found");
            _mapper.Map(dto, user);
            _repository.Update(user);
            await _repository.Save();
            await _cacheService.RemoveAsync(CacheKey_All);
            await _cacheService.RemoveAsync(CacheKey_Prefix + userId);
            return _mapper.Map<UserResponseDto>(user);

        }
        public async Task<UserResponseDto> UpdateAdmiAsync(long id,AdminUserDto dto)
        {

            var user = await _repository.GetById(id) ??
                throw new NotFoundException("user not found");
            _mapper.Map(dto, user);
            _repository.Update(user);
            await _repository.Save();
            await _cacheService.RemoveAsync(CacheKey_All);
            await _cacheService.RemoveAsync(CacheKey_Prefix + id);
            return _mapper.Map<UserResponseDto>(user);

        }


        public async Task<UserResponseDto> GetUserById(long id)
        {
            var cached = await _cacheService.GetAsync<UserResponseDto>(CacheKey_Prefix + id);
            if (cached != null)
                return cached;
            var user = await _repository.GetById(id) ??
                throw new NotFoundException("user not found");
            var result = _mapper.Map<UserResponseDto>(user);
            await _cacheService.SetAsync(CacheKey_Prefix + id, result, TimeSpan.FromMinutes(10));

            return result;
        }
        public async Task<UserResponseDto> GetUserByName(string Name)
        {
            var cached = await _cacheService.GetAsync<UserResponseDto>(CacheKey_Prefix + Name);
            if (cached != null)
                return cached;
            var user = await _repository.GetByName(Name) ??
                throw new NotFoundException("user not found");
            var result = _mapper.Map<UserResponseDto>(user);
            await _cacheService.SetAsync(CacheKey_Prefix + Name, result, TimeSpan.FromMinutes(10));

            return result;

        }
    }
}


