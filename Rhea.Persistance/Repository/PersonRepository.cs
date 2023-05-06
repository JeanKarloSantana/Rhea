using Microsoft.EntityFrameworkCore;
using Rhea.DAL.SQL;
using Rhea.Entities;
using Rhea.Entities.DTO;
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
    public class PersonRepository : BaseRepository<Person>, IPersonRepository
    {
        public RheaDbContext Context { get { return context; } }

        public PersonRepository(RheaDbContext dbContext) : base(dbContext)
        {
        }

        public Person GetPersonById(int id) => context.Persons
            .Include(x => x.User)
            .FirstOrDefault(x => x.Id == id);

        public void CreatePersonByDto(int userId, PostUserDto userDto)
        {
            var person = new Person
            {
                Id = userId,
                FirstName = userDto.FirstName,
                NormalizedFirstName = NormalizeName(userDto.FirstName),
                Lastname = userDto.LastName,
                NormalizedLastname = NormalizeName(userDto.LastName),
                DateOfBirth = userDto.DateOfBirth,
            };

            Add(person);
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
