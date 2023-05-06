using Microsoft.EntityFrameworkCore;
using Rhea.DAL.SQL;
using Rhea.Entities;
using Rhea.Entities.DTO;
using Rhea.Entities.Enums;
using Rhea.Interfaces.Repository;
using Rhea.Persistance.Generic;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rhea.Persistance.Repository
{
    public class CompanyRepository : BaseRepository<Company>, ICompanyRepository
    {
        public RheaDbContext Context { get { return context; } }

        public CompanyRepository(RheaDbContext dbContext) : base(dbContext)
        {
        }

        public Company GetCompanyById(int id) => context.Company
            .Include(x => x.User)
            .FirstOrDefault(x => x.Id == id);

        public void CreateCompanyByDto(int userId, PostUserDto userDto)
        {
            var company = new Company
            {
                Id = userId,
                Name = userDto.CompanyName,
                NormalizedName = NormalizeName(userDto.CompanyName)
            };

            Add(company);
        }

        public static string NormalizeName(string name)
        {
            string normalized = name.Trim();
            normalized = normalized.ToUpper();
            normalized = CultureInfo.CurrentCulture.TextInfo.ToTitleCase(normalized);

            return normalized;
        }
    }
}
