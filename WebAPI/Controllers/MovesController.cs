using Business.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MovesController : ControllerBase
    {
        private IMoveService _moveService;

        public MovesController(IMoveService moveService)
        {
            _moveService = moveService;
        }

        [HttpGet("getlist")]
        public IActionResult GetList()
        {
            var result = _moveService.GetList();
            if (!result.Success)
            {
                return BadRequest(result.Message);
            }
            return Ok(result);
        }

        [HttpGet("getbyid")]
        public IActionResult GetById(int moveId)
        {
            var result = _moveService.GetById(moveId);
            if (!result.Success)
            {
                return BadRequest(result.Message);
            }
            return Ok(result);
        }

        [HttpPost("add")]
        public IActionResult Add(Move move)
        {
            var result = _moveService.Add(move);
            if (!result.Success)
            {
                return BadRequest(result.Message);
            }
            return Ok(result);
        }

        [HttpPost("update")]
        public IActionResult Update(Move move)
        {
            var result = _moveService.Update(move);
            if (!result.Success)
            {
                return BadRequest(result.Message);
            }
            return Ok(result);
        }

        [HttpPost("delete")]
        public IActionResult Delete(Move move)
        {
            var result = _moveService.Delete(move);
            if (!result.Success)
            {
                return BadRequest(result.Message);
            }
            return Ok(result);
        }
    }
}
