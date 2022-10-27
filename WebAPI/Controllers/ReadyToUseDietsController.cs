using Business.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReadyToUseDietsController : ControllerBase
    {
        private IReadyToUseDietService _readyToUseDietService;

        public ReadyToUseDietsController(IReadyToUseDietService readyToUseDietService)
        {
            _readyToUseDietService = readyToUseDietService;
        }

        [HttpGet("getlist")]
        public IActionResult GetList()
        {
            var result = _readyToUseDietService.GetList();
            if (!result.Success)
            {
                return BadRequest(result.Message);
            }
            return Ok(result);
        }

        [HttpGet("getbyid")]
        public IActionResult GetById(int readyToUseDietId)
        {
            var result = _readyToUseDietService.GetById(readyToUseDietId);
            if (!result.Success)
            {
                return BadRequest(result.Message);
            }
            return Ok(result);
        }

        [HttpPost("add")]
        public IActionResult Add(ReadyToUseDiet readyToUseDiet)
        {
            var result = _readyToUseDietService.Add(readyToUseDiet);
            if (!result.Success)
            {
                return BadRequest(result.Message);
            }
            return Ok(result);
        }

        [HttpPost("update")]
        public IActionResult Update(ReadyToUseDiet readyToUseDiet)
        {
            var result = _readyToUseDietService.Update(readyToUseDiet);
            if (!result.Success)
            {
                return BadRequest(result.Message);
            }
            return Ok(result);
        }

        [HttpPost("delete")]
        public IActionResult Delete(ReadyToUseDiet readyToUseDiet)
        {
            var result = _readyToUseDietService.Delete(readyToUseDiet);
            if (!result.Success)
            {
                return BadRequest(result.Message);
            }
            return Ok(result);
        }
    }
}
