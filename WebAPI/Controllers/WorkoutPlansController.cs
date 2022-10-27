using Business.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WorkoutPlansController : ControllerBase
    {
        private IWorkoutPlanService _workoutPlanService;

        public WorkoutPlansController(IWorkoutPlanService workoutPlanService)
        {
            _workoutPlanService = workoutPlanService;
        }

        [HttpGet("getlist")]
        public IActionResult GetList()
        {
            var result = _workoutPlanService.GetList();
            if (!result.Success)
            {
                return BadRequest(result.Message);
            }
            return Ok(result);
        }

        [HttpGet("getbyid")]
        public IActionResult GetById(int workoutPlanId)
        {
            var result = _workoutPlanService.GetById(workoutPlanId);
            if (!result.Success)
            {
                return BadRequest(result.Message);
            }
            return Ok(result);
        }

        [HttpPost("add")]
        public IActionResult Add(WorkoutPlan workoutPlan)
        {
            var result = _workoutPlanService.Add(workoutPlan);
            if (!result.Success)
            {
                return BadRequest(result.Message);
            }
            return Ok(result);
        }

        [HttpPost("update")]
        public IActionResult Update(WorkoutPlan workoutPlan)
        {
            var result = _workoutPlanService.Update(workoutPlan);
            if (!result.Success)
            {
                return BadRequest(result.Message);
            }
            return Ok(result);
        }

        [HttpPost("delete")]
        public IActionResult Delete(WorkoutPlan workoutPlan)
        {
            var result = _workoutPlanService.Delete(workoutPlan);
            if (!result.Success)
            {
                return BadRequest(result.Message);
            }
            return Ok(result);
        }
    }
}
