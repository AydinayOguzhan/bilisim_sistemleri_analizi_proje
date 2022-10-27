using Business.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserDietsController : ControllerBase
    {
        private IUserDietService _userDietService;

        public UserDietsController(IUserDietService userDietService)
        {
            _userDietService = userDietService;
        }

        [HttpGet("getlist")]
        public IActionResult GetList()
        {
            var result = _userDietService.GetList();
            if (!result.Success)
            {
                return BadRequest(result.Message);
            }
            return Ok(result);
        }

        [HttpGet("getbyid")]
        public IActionResult GetById(int userDietId)
        {
            var result = _userDietService.GetById(userDietId);
            if (!result.Success)
            {
                return BadRequest(result.Message);
            }
            return Ok(result);
        }

        [HttpPost("add")]
        public IActionResult Add(UserDiet userDiet)
        {
            var result = _userDietService.Add(userDiet);
            if (!result.Success)
            {
                return BadRequest(result.Message);
            }
            return Ok(result);
        }

        [HttpPost("update")]
        public IActionResult Update(UserDiet userDiet)
        {
            var result = _userDietService.Update(userDiet);
            if (!result.Success)
            {
                return BadRequest(result.Message);
            }
            return Ok(result);
        }

        [HttpPost("delete")]
        public IActionResult Delete(UserDiet userDiet)
        {
            var result = _userDietService.Delete(userDiet);
            if (!result.Success)
            {
                return BadRequest(result.Message);
            }
            return Ok(result);
        }
    }
}
