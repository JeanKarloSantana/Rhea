using Microsoft.AspNetCore.Mvc;
using Rhea.Entities.DTO;
using Rhea.Interfaces.Domain;
using Rhea.Interfaces.Generic;

namespace Rhea.Controllers
{
    public class UserController : Controller
    {
        private readonly IUserManager _userManager;
        private readonly IUnitOfWork  _unitOfWork;

        public UserController(IUserManager eventManager, IUnitOfWork unitOfWork)
        {
            _userManager = eventManager;
            _unitOfWork = unitOfWork;
        }

        [HttpPost("CreateUser")]
        public async Task<IActionResult> CreateEvent(PostUserDto userDto)
        {
            try
            {
                ResponseDTO<string> response = await _userManager.CreateUser(userDto);
                _unitOfWork.Complete();
                return StatusCode(response.StatusCode, response.Succeed ? response.Message : response.Errors);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex);
            }
        }
    }
}
