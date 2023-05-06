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
    public interface ICompanyRepository : IBaseRepository<Company>
    {
        Company GetCompanyById(int id);
        void CreateCompanyByDto(int userId, PostUserDto userDto);
    }
}
