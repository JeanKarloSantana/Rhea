using Microsoft.EntityFrameworkCore;
using Rhea.DAL.SQL;
using Rhea.Entities;
using Rhea.Entities.DTO;
using Rhea.Entities.Enums;
using Rhea.Interfaces.Repository;
using Rhea.Persistance.Generic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rhea.Persistance.Repository
{
    public class UserRepository : BaseRepository<User>, IUserRepository
    {
        public RheaDbContext Context { get { return context; } }

        public UserRepository(RheaDbContext dbContext) : base(dbContext)
        {
        }

        public int CreateUserByDto(PostUserDto userDto)
        {
            var user = new User
            {
                IdUserType = userDto.UserType,
                IdUserStatus = (int)UserStatusEnum.AVAILABLE,
                Email = userDto.Email
            };

            Add(user);
            context.SaveChanges();
            return user.Id;
        }

        public int GetUserIdStatusByID(int id) => context.Users
            .Where(x => x.Id == id)
            .Select(x => x.IdUserStatus)
            .FirstOrDefault();

        public void UpdateUserStatus(int id, int idStatus)
        {
            User user = Get(id);
            user.IdUserStatus = idStatus;
        }

        public async Task<bool> IsUser(string email) => await context.Users.AnyAsync(x => x.Email == email);
    }
}
