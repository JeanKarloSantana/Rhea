using Rhea.Entities;
using Rhea.Entities.DTO;
using Rhea.Entities.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rhea.NUnitTest
{
    public class TestData
    {
        public static Person[] PersonArray = new Person[4]
        {
            new Person { Id = 1, FirstName = "Andrew", NormalizedFirstName = "ANDREW", Lastname = "Cruz", NormalizedLastname = "CRUZ", DateOfBirth = new DateTime(2000, 5, 16) },
            new Person { Id = 2, FirstName = "Crystal", NormalizedFirstName = "CRYSTAL", Lastname = "Santos", NormalizedLastname = "SANTOS", DateOfBirth = new DateTime(2012, 8, 8) },
            new Person { Id = 3, FirstName = "Max", NormalizedFirstName = "MAX", Lastname = "Opper", NormalizedLastname = "OPPER", DateOfBirth = new DateTime(1997, 3, 5) },
            new Person { Id = 4, FirstName = "Laura", NormalizedFirstName = "LAURA", Lastname = "Ebert", NormalizedLastname = "EBERT", DateOfBirth = new DateTime(1992, 9, 21) }
        };

        public static User[] UserArray = new User[4]
        {
            new User { Id = 1, Email = "AndrewCrux@outlook.com", IdUserType = 1, IdUserStatus = 1 },
            new User { Id = 2, Email = "CrystalSantos@outlook.com", IdUserType = 1, IdUserStatus = 1 },
            new User { Id = 3, Email = "MaxOpper@outlook.com", IdUserType = 1, IdUserStatus = 2 },
            new User { Id = 4, Email = "LauraEbert@outlook.com", IdUserType = 1, IdUserStatus = 3 }
        };

        public static PostUserDto PostUserDtos = new PostUserDto
        {
            UserType = (int)UserTypeEnum.PERSON,
            Email = "AlexSmith@outlook.com",
        };
        
    }
}
