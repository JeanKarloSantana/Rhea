using Rhea.Entities.DTO;
using Rhea.Entities.Enums;
using Rhea.Entities.Shared;
using Rhea.Entities.Shared.Messages;
using Rhea.Interfaces.Domain;
using Rhea.Interfaces.Generic;
using Rhea.Interfaces.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rhea.Domain.UserManager
{
    public class UserManager : IUserManager
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IUserValidationService _userValidation;
        private ResponseDTO<string> response;

        public UserManager(IUnitOfWork unitOfWork, IUserValidationService userValidation)
        {
            _unitOfWork = unitOfWork;
            _userValidation = userValidation;
            response = new ResponseDTO<string>();
        }

        public async Task<ResponseDTO<string>> CreateUser(PostUserDto userDto)
        {
            ValidationResponse userValidation = await _userValidation.ValidateUserCretion(userDto.Email);
            if (!userValidation.IsValid)
                return response.UpdateResponse(response, "", 400, false, userValidation.Message, ""); 

            int userId = _unitOfWork.User.CreateUserByDto(userDto);

            if (userDto.UserType == (int)UserTypeEnum.PERSON) 
            { 
                _unitOfWork.Person.CreatePersonByDto(userId, userDto);
                return response.UpdateResponse(response, "", 200, true, "", UserMessages.UserCreated);
            }

            _unitOfWork.Company.CreateCompanyByDto(userId, userDto);
            
            return response.UpdateResponse(response, "", 200, true, "", UserMessages.UserCreated);
        }
    }
}
