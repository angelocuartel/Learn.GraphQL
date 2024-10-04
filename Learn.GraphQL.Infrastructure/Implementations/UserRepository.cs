using Learn.GraphQL.ApplicationService.Interface;
using Learn.GraphQL.Domain;
using Microsoft.EntityFrameworkCore;

namespace Learn.GraphQL.Infrastructure.Implementations;

internal class UserRepository : IUserRepository<User>
{
    private readonly DatabaseContext _databaseContext;
    public UserRepository(DatabaseContext databaseContext) => _databaseContext = databaseContext;

    public async Task<long> AddAsync(User entity)
    {
        if (entity is not null && entity.PersonalDetail is not null)
        {
            await _databaseContext.users.AddAsync(entity);

            await _databaseContext.SaveChangesAsync();

            return entity.UserId;
        }

        return 0;
    }

    public async Task<bool> DeleteAsync(long id)
    {
        var user = await _databaseContext.users.FirstOrDefaultAsync(i => i.UserId == id);

        if (user is null)
        {
            return false;
        }

        _databaseContext.users.Remove(user);

        return await _databaseContext.SaveChangesAsync() > 0;
    }

    public async Task<List<User>> GetAllAsync()
        => await _databaseContext.users
                                 .Include(i => i.PersonalDetail)
                                 .AsNoTracking()
                                 .ToListAsync();

    public async Task<User> GetByIdAsync(int id)
    => await _databaseContext.users
                             .AsNoTracking()
                             .Include(i => i.PersonalDetail)
                             .FirstOrDefaultAsync(i => i.UserId == id) ?? new();

    public async Task<bool> UpdateAsync(long id, User entity)
    {
        if (entity is null || entity.PersonalDetail is null)
        {
            return false;
        }

        var updatedUser = await _databaseContext.users
                                          .Include(i => i.PersonalDetail)
                                          .FirstOrDefaultAsync(u => u.UserId == id);

        if (updatedUser is null || updatedUser.PersonalDetail is null)
        {
            return false;
        }

        updatedUser.UserName = entity.UserName;
        updatedUser.Password = entity.Password;
        updatedUser.PersonalDetail.FirstName = entity.PersonalDetail.FirstName;
        updatedUser.PersonalDetail.LastName = entity.PersonalDetail.LastName;
        updatedUser.PersonalDetail.BirthDate = entity.PersonalDetail.BirthDate;

        _databaseContext.users.Update(entity);

        return await _databaseContext.SaveChangesAsync() > 0;
    }
}
