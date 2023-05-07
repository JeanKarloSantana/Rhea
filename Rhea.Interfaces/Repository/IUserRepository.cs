using Rhea.Entities;
using Rhea.Entities.DTO;
using Rhea.Interfaces.Generic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rhea.Interfaces.Repository
{
    public interface IUserRepository : IBaseRepository<User>
    {
        int GetUserIdStatusByID(int id);
        void UpdateUserStatus(int id, int idStatus);
        int CreateUserByDto(PostUserDto userDto);
        Task<bool> IsUser(string email);
    }
}
