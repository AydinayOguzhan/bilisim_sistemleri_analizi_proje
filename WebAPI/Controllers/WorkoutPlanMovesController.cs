using Business.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WorkoutPlanMovesController : ControllerBase
    {
        private IWorkoutPlanMoveService _workoutPlanMoveService;

        public WorkoutPlanMovesController(IWorkoutPlanMoveService workoutPlanMoveService)
        {
            _workoutPlanMoveService = workoutPlanMoveService;
        }

        [HttpGet("getlist")]
        public IActionResult GetList()
        {
            var result = _workoutPlanMoveService.GetList();
            if (!result.Success)
            {
                return BadRequest(result.Message);
            }
            return Ok(result);
        }

        [HttpGet("getbyid")]
        public IActionResult GetById(int workoutPlanMoveId)
        {
            var result = _workoutPlanMoveService.GetById(workoutPlanMoveId);
            if (!result.Success)
            {
                return BadRequest(result.Message);
            }
            return Ok(result);
        }

        [HttpPost("add")]
        public IActionResult Add(WorkoutPlanMove workoutPlanMove)
        {
            var result = _workoutPlanMoveService.Add(workoutPlanMove);
            if (!result.Success)
            {
                return BadRequest(result.Message);
            }
            return Ok(result);
        }

        [HttpPost("update")]
        public IActionResult Update(WorkoutPlanMove workoutPlanMove)
        {
            var result = _workoutPlanMoveService.Update(workoutPlanMove);
            if (!result.Success)
            {
                return BadRequest(result.Message);
            }
            return Ok(result);
        }

        [HttpPost("delete")]
        public IActionResult Delete(WorkoutPlanMove workoutPlanMove)
        {
            var result = _workoutPlanMoveService.Delete(workoutPlanMove);
            if (!result.Success)
            {
                return BadRequest(result.Message);
            }
            return Ok(result);
        }
    }
}
