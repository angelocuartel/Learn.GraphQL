using Learn.GraphQL.Data.Entities;
using Learn.GraphQL.Domain.Inputs;
using Learn.GraphQL.Domain.Mutation;

namespace Learn.GraphQL
{
    public class Mutation
    {
        private readonly UserService _userService;
        public Mutation(UserService userService) => _userService = userService;

        public async Task<long> CreateUserAsync(User user)
        {
            return await _userService.CreateAsync(user);
        }

        public async Task<bool> UpdateUserAsync(long userId, UserDto userDto)
        {
            var mappedUser = MapUserDtoToUser(userDto);

            return await _userService.UpdateUserAsync(userId, mappedUser);
        }

        public async Task<bool> DeleteUserAsync(long userId) => await _userService.DeleteUserAsync(userId);

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
