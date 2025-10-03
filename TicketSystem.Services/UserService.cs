using AutoMapper;
using TicketSystem.Core.DTOs;
using TicketSystem.Core.Models;
using TicketSystem.Core.Interfaces;
using TicketSystem.Data.Repositories;
using BCrypt.Net;

namespace TicketSystem.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;

        public UserService(IUserRepository usertRepository, IMapper mapper)
        {
            _userRepository = usertRepository;
            _mapper = mapper;
        }

        public async Task<UserViewDto> CreateUser(UserCreateDto userCreateDto)
        {
            // Map DTO to the database model
            var user = _mapper.Map<User>(userCreateDto);

            // Hashing befor store 
            user.PasswordHash = BCrypt.Net.BCrypt.HashPassword(userCreateDto.Password);

            // Add to repository and save changes
            await _userRepository.AddAsync(user);

            // Map the result back to a View DTO
            var userViewDto = _mapper.Map<UserViewDto>(user);
            return userViewDto;
        }

        public async Task<UserViewDto> GetUserById(int id)
        {
            var user = await _userRepository.GetUserByIdAsync(id);
            var userViewDto = _mapper.Map<UserViewDto>(user);
            return userViewDto;
        }

        public async Task<IEnumerable<UserViewDto>> GetAllUsers()
        {
            var users = await _userRepository.GetAllUsersAsync();
            var userViewDto = _mapper.Map<IEnumerable<UserViewDto>>(users);
            return userViewDto;
        }

        public async Task<bool> DeleteUser(int id)
        {
            var user = await _userRepository.GetByIdAsync(id);
            if (user == null)
            {
                return false;
            }
            _userRepository.Delete(user);
            await _userRepository.SaveChangesAsync();
            return true;
        }

        public async Task<User?> GetUserByEmailAsync(string email)
        {
            return await _userRepository.GetByEmailAsync(email);
        }
    }
}
