using NUnit.Framework;
using Rhea.Entities;
using Rhea.Entities.Enums;
using Rhea.Persistance.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Rhea.NUnitTest.Persistance.Repository
{
    [TestFixture]
    public class TestUserRepository
    {
        private UserRepository userRepo;
        
        [SetUp] 
        public void SetUp() 
        {
            var context = new TestRheaDbContext();
            new TestEntitySeed<User>(context.GetTestDbContext(), TestData.UserArray);
            userRepo = new UserRepository(context.GetTestDbContext());
        }

        [Test]
        [TestCase(0, (int)UserStatusEnum.AVAILABLE)]
        [TestCase(2, (int)UserStatusEnum.DUE)]
        [TestCase(3, (int)UserStatusEnum.CANCELED)]
        public void GetUserIdStatusByID_ReturnIdStatus_WhenUserExist(int arrPosition, int status) 
        {
            //Arrange

            //Result
            int user = userRepo.GetUserIdStatusByID(TestData.UserArray[arrPosition].Id);

            //Assert
            Assert.That(user, Is.EqualTo(status));
        }

        [Test]
        [TestCase(0, (int)UserStatusEnum.DUE)]
        [TestCase(1, (int)UserStatusEnum.CANCELED)]
        [TestCase(2, (int)UserStatusEnum.AVAILABLE)]
        public void UpdateUserStatus_UpdateUserIdStatus_WhenUserExist(int arrPosition, int status)
        {
            //Arrange
            var context = new TestRheaDbContext();
            new TestEntitySeed<User>(context.GetTestDbContext(), TestData.UserArray);
            var userRepo = new UserRepository(context.GetTestDbContext());
            
            //Result
            userRepo.UpdateUserStatus(TestData.UserArray[arrPosition].Id, status);

            //Assert
            Assert.That(userRepo.Get(TestData.UserArray[arrPosition].Id).IdUserStatus, Is.EqualTo(status));
        }

        [Test]
        public async Task IsUser_ReturnTrueOrFalse_WhenUserEmailExist()
        {
            //Arrange
            var context = new TestRheaDbContext();
            new TestEntitySeed<User>(context.GetTestDbContext(), TestData.UserArray);
            var userRepo = new UserRepository(context.GetTestDbContext());

            //Result
            bool userExist = await userRepo.IsUser(TestData.UserArray[0].Email);
            bool userNotExist = await userRepo.IsUser("TestUser@outlook.com");

            //Assert
            Assert.That(userExist, Is.True);
            Assert.That(userNotExist, Is.False);
        }

        [Test]
        public void CreateUserByDto_AddNewUserToDatabase_ReturnId()
        {
            //Arrange
            var context = new TestRheaDbContext();
            new TestEntitySeed<User>(context.GetTestDbContext(), TestData.UserArray);
            var userRepo = new UserRepository(context.GetTestDbContext());

            //Result
            int userId = userRepo.CreateUserByDto(TestData.PostUserDtos);

            //Assert
            Assert.That(userId, Is.TypeOf<int>());
        }
    }
}
