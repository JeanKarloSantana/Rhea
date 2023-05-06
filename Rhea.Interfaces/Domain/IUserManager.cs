using Rhea.Entities.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rhea.Interfaces.Domain
{
    public interface IUserManager
    {
        Task<ResponseDTO<string>> CreateUser(PostUserDto userDto);
    }
}
