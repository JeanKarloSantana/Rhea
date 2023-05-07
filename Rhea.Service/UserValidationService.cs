using Rhea.Entities.Enums;
using Rhea.Entities;
using Rhea.Interfaces.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Rhea.Interfaces.Generic;
using Rhea.Entities.Shared;
using Rhea.Entities.Shared.Messages;

namespace Rhea.Service
{
    public class UserValidationService : IUserValidationService
    {
        private readonly IUnitOfWork _unitOfWork;

        public UserValidationService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public ValidationResponse UserValidateScheduleReservation(int idUser)
        {
            var userValidation = new ValidationResponse();
            
            int userStatus = _unitOfWork.User.GetUserIdStatusByID(idUser);
            
            if (userStatus != (int)UserStatusEnum.AVAILABLE) 
                return userValidation.SetResponse(userValidation, UserMessages.NotAvailableStatus, false);

            Person person = _unitOfWork.Person.GetPersonById(idUser);
            if (person != null) 
            {
                if (CalculateAge(person.DateOfBirth) < 21) return userValidation.SetResponse(userValidation, UserMessages.UnderAge, false);
            }

            return userValidation.SetResponse(userValidation, UserMessages.ValidUser, true);
        }

        public async Task<ValidationResponse> ValidateUserCretion(string email)
        {
            var userValidation = new ValidationResponse();
            return await _unitOfWork.User.IsUser(email)
                ? userValidation.SetResponse(userValidation, UserMessages.CanCreate ,true)
                : userValidation.SetResponse(userValidation, UserMessages.UserExist, false);
        }

        private int CalculateAge(DateTime birthdate)
        {
            DateTime now = DateTime.Today;
            int age = now.Year - birthdate.Year;
            if (now < birthdate.AddYears(age))
                age--;
            return age;
        }
    }
}
