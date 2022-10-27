using Business.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserMovesController : ControllerBase
    {
        private IUserMoveService _userMoveService;

        public UserMovesController(IUserMoveService userMoveService)
        {
            _userMoveService = userMoveService;
        }

        [HttpGet("getlist")]
        public IActionResult GetList()
        {
            var result = _userMoveService.GetList();
            if (!result.Success)
            {
                return BadRequest(result.Message);
            }
            return Ok(result);
        }

        [HttpGet("getbyid")]
        public IActionResult GetById(int userMoveId)
        {
            var result = _userMoveService.GetById(userMoveId);
            if (!result.Success)
            {
                return BadRequest(result.Message);
            }
            return Ok(result);
        }

        [HttpPost("add")]
        public IActionResult Add(UserMove userMove)
        {
            var result = _userMoveService.Add(userMove);
            if (!result.Success)
            {
                return BadRequest(result.Message);
            }
            return Ok(result);
        }

        [HttpPost("update")]
        public IActionResult Update(UserMove userMove)
        {
            var result = _userMoveService.Update(userMove);
            if (!result.Success)
            {
                return BadRequest(result.Message);
            }
            return Ok(result);
        }

        [HttpPost("delete")]
        public IActionResult Delete(UserMove userMove)
        {
            var result = _userMoveService.Delete(userMove);
            if (!result.Success)
            {
                return BadRequest(result.Message);
            }
            return Ok(result);
        }
    }
}
