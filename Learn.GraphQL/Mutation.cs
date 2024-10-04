using Learn.GraphQL.ApplicationService.Interface;
using Learn.GraphQL.Domain;
using Learn.GraphQL.Domain.Inputs;

namespace Learn.GraphQL
{
    public class Mutation
    {
        private readonly IUserRepository<User> _userRepository;
        public Mutation(IUserRepository<User> userRepository) => _userRepository = userRepository;

        public async Task<long> CreateUserAsync(User user)
        {
            return await _userRepository.AddAsync(user);
        }

        public async Task<bool> UpdateUserAsync(long userId, UserDto userDto)
        {
            var mappedUser = MapUserDtoToUser(userDto);

            return await _userRepository.UpdateAsync(userId, mappedUser);
        }

        public async Task<bool> DeleteUserAsync(long userId) => await _userRepository.DeleteAsync(userId);

        private User MapUserDtoToUser(UserDto userDto)
        => new User
        {
            UserName = userDto.UserName,
            Password = userDto.Password,
            PersonalDetail = new PersonalDetail
            {
                FirstName = userDto.PersonalDetail.FirstName,
                LastName = userDto.PersonalDetail.LastName,
                BirthDate = userDto.PersonalDetail.DateOfBirth
            }
        };


    }
}
