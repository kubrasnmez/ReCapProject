using Business.Abstract;
using Core.Entities.Concreate;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private IUserService _userService;

        public UsersController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpPost("add")]
        public IActionResult Add(User user)
        {
            var result = _userService.Add(user);
            return result.Success ? (IActionResult)Ok(result) : BadRequest(result);
        }
        [HttpPost("update")]
        public IActionResult Update(User user)
        {
            var result = _userService.Update(user);
            return result.Success ? (IActionResult)Ok(result) : BadRequest(result);
        }
        public IActionResult Delete(User user)
        {
            var result = _userService.Delete(user);
            return result.Success ? (IActionResult)Ok(result) : BadRequest(result);
        }
        [HttpGet("getbyid")]
        public IActionResult GetById(int id)
        {
            var result = _userService.GetById(id);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpGet("getuserbymail")]
        public IActionResult GetUserByMail(string mail)
        {
            var result = _userService.GetByMail(mail);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

    }
        
    
}
