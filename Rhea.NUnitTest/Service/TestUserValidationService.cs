using NUnit.Framework;
using Rhea.Entities;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rhea.NUnitTest.Service
{
    public class TestUserValidationService
    {
        private Person[] personArr;

        [SetUp] 
        public void SetUp() 
        {
            personArr = new Person[1]
            {
                new Person { Id = 1, FirstName = "Andrew", NormalizedFirstName = "ANDREW", Lastname = "Cruz", NormalizedLastname = "CRUZ", DateOfBirth = new DateTime(2000, 16, 5) }

            };
        }
    }
}
