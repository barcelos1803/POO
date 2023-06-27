using System.Linq.Expressions;
using AutoMapper;
using Domain.Entities;
using Domain.Interfaces;
using Domain.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace Domain.Controllers
{
    [ApiController]
    [Route("api/user")]
    public class UserController : ControllerBase
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;

        public UserController(IUserRepository userRepository, IMapper mapper)
        {
            _userRepository = userRepository;
            _mapper = mapper;
        }

        [HttpDelete("{id:int}")]
        public IActionResult DeleteUser(int id)
        {
            bool deleted = _userRepository.Delete(id);

            if (deleted)
            {
                return HttpMessageOk();
            }
            else
            {
                return HttpMessageError("Failed to delete user.");
            }
        }

        [HttpGet]
        public async Task<IActionResult> GetAllUsersAsync()
        {
            var users = await _userRepository.GetAllAsync();
            var userViewModels = _mapper.Map<IList<UserViewModel>>(users);
            return HttpMessageOk(userViewModels);
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetUserByIdAsync(int id)
        {
            var user = await _userRepository.GetByIdAsync(id);

            if (user != null)
            {
                var userViewModel = _mapper.Map<UserViewModel>(user);
                return HttpMessageOk(userViewModel);
            }
            else
            {
                return HttpMessageError("User not found.");
            }
        }

        [HttpPost]
        public IActionResult SaveUser(UserViewModel model)
        {
            var user = _mapper.Map<User>(model);
            _userRepository.Save(user);
            return HttpMessageOk();
        }
        [HttpPut("{id:int}")]
        public IActionResult UpdateUser(int id, UserViewModel userViewModel)
        {
            var user = _mapper.Map<User>(userViewModel);
            user.Id = id;
            _userRepository.Update(user);
            return HttpMessageOk();
        }

        private IActionResult HttpMessageOk(dynamic data = null)
        {
            if (data == null)
            {
                return NoContent();
            }
            else
            {
                return Ok(new
                {
                    data
                });
            }
        }

        private IActionResult HttpMessageError(string message = "")
        {
            return BadRequest(new
            {
                message
            });
        }
    }
}
