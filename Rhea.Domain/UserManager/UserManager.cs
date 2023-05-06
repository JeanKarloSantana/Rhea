using Rhea.Entities.DTO;
using Rhea.Entities.Enums;
using Rhea.Interfaces.Domain;
using Rhea.Interfaces.Generic;
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
        private ResponseDTO<string> response;

        private void updateResponse(ushort statusCode, bool succeed, string error, string message)
        {
            response.Message = message;
            response.StatusCode = statusCode;
            response.Succeed = succeed;
            response.Errors.Add(error);
        }

        public UserManager(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
            response = new ResponseDTO<string>();
        }

        public Task<ResponseDTO<string>> CreateUser(PostUserDto userDto)
        {
            int userId = _unitOfWork.User.CreateUserByDto(userDto);

            if (userDto.UserType == (int)UserTypeEnum.PERSON) 
            { 
                _unitOfWork.Person.CreatePersonByDto(userId, userDto);
                SucceedResponse();
                return Task.FromResult(response);
            }

            _unitOfWork.Company.CreateCompanyByDto(userId, userDto);

            SucceedResponse();
            return Task.FromResult(response);
        }

        public void SucceedResponse() 
        {
            updateResponse(200, true, "", "User Created");
        }
    }
}
