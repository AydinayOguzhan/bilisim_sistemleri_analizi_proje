using Business.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReadyToUseDietFoodsController : ControllerBase
    {
        private IReadyToUseDietFoodService _readyToUseDietFoodService;

        public ReadyToUseDietFoodsController(IReadyToUseDietFoodService readyToUseDietFoodService)
        {
            _readyToUseDietFoodService = readyToUseDietFoodService;
        }

        [HttpGet("getlist")]
        public IActionResult GetList()
        {
            var result = _readyToUseDietFoodService.GetList();
            if (!result.Success)
            {
                return BadRequest(result.Message);
            }
            return Ok(result);
        }

        [HttpGet("getbyid")]
        public IActionResult GetById(int readyToUseDietFoodId)
        {
            var result = _readyToUseDietFoodService.GetById(readyToUseDietFoodId);
            if (!result.Success)
            {
                return BadRequest(result.Message);
            }
            return Ok(result);
        }

        [HttpPost("add")]
        public IActionResult Add(ReadyToUseDietFood readyToUseDietFood)
        {
            var result = _readyToUseDietFoodService.Add(readyToUseDietFood);
            if (!result.Success)
            {
                return BadRequest(result.Message);
            }
            return Ok(result);
        }

        [HttpPost("update")]
        public IActionResult Update(ReadyToUseDietFood readyToUseDietFood)
        {
            var result = _readyToUseDietFoodService.Update(readyToUseDietFood);
            if (!result.Success)
            {
                return BadRequest(result.Message);
            }
            return Ok(result);
        }

        [HttpPost("delete")]
        public IActionResult Delete(ReadyToUseDietFood readyToUseDietFood)
        {
            var result = _readyToUseDietFoodService.Delete(readyToUseDietFood);
            if (!result.Success)
            {
                return BadRequest(result.Message);
            }
            return Ok(result);
        }
    }
}
