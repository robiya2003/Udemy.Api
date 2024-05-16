using AutoService.Domain.Entities.Models;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Win32;
using Udemy.Domain.DTOS;
using Udemy.Domain.MODELS;

namespace Udemy.Api.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class RegistratsiyaController : ControllerBase
    {
        private readonly UserManager<UserModel> _userManager;
        public RegistratsiyaController(UserManager<UserModel> userManager)
        {
            _userManager = userManager;
        }
        [HttpPost]
        public async Task<ResponceModel> CreateUser(UserDto userDto)
        {
            if (!ModelState.IsValid)
            {
                throw new Exception();
            }
            var user=new UserModel()
            {
                UserName=userDto.Username, Email=userDto.Email,
               FirstName=userDto.Firstname, LastName=userDto.Lastname,
              Role="User"
            };

            var result = await _userManager.CreateAsync(user, userDto.Password);

            if (!result.Succeeded)
                throw new Exception();

            await _userManager.AddToRoleAsync(user, "User");
            return new ResponceModel()
            {
                Message="User Created"
            };
        }

    }
}
