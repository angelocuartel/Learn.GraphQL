using Learn.GraphQL.Data;
using Learn.GraphQL.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace Learn.GraphQL.Domain.Mutation
{
    public class UserService
    {
        private readonly DatabaseContext _databaseContext;

        public UserService(DatabaseContext databaseContext) => _databaseContext = databaseContext;

        public async Task<List<User>> GetAllAsync() => await _databaseContext.users.Include(i => i.PersonalDetail).ToListAsync();

        public async Task<long> CreateAsync(User user)
        {
            if (user is not null && user.PersonalDetail is not null)
            {
                await _databaseContext.users.AddAsync(user);

                await _databaseContext.SaveChangesAsync();

                return user.UserId;
            }

            return 0;
        }

        public async Task<bool> DeleteUserAsync(long userId)
        {
            var user = await _databaseContext.users.FirstOrDefaultAsync(i => i.UserId == userId);

            if (user is null)
            {
                return false;
            }

            _databaseContext.users.Remove(user);

            return await _databaseContext.SaveChangesAsync() > 0;
        }

        public async Task<bool> UpdateUserAsync(long userId, User user)
        {
            if (user is null || user.PersonalDetail is null)
            {
                return false;
            }

            var updatedUser = await _databaseContext.users
                                              .Include(i => i.PersonalDetail)
                                              .FirstOrDefaultAsync(u => u.UserId == userId);

            if (updatedUser is null || updatedUser.PersonalDetail is null)
            {
                return false;
            }

            updatedUser.UserName = user.UserName;
            updatedUser.Password = user.Password;
            updatedUser.PersonalDetail.FirstName = user.PersonalDetail.FirstName;
            updatedUser.PersonalDetail.LastName = user.PersonalDetail.LastName;
            updatedUser.PersonalDetail.BirthDate = user.PersonalDetail.BirthDate;

             _databaseContext.users.Update(user);

            return await _databaseContext.SaveChangesAsync() > 0;
        }
    }
}
