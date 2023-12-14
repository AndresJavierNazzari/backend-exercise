using Asp.Versioning;
using FluentValidation;
using FluentValidation.Results;
using Microsoft.AspNetCore.Mvc;
using wakuwakuApi.Models;
using wakuwakuApi.Services.Interfaces;

namespace wakuwakuApi.Controllers {
    [ApiController]
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/[controller]")]
    public class GoalController : ControllerBase {
        private readonly IValidator<GoalCreate> _validator;
        private readonly IGoalService _goalService;


        public GoalController(IValidator<GoalCreate> validator, IGoalService goalService) {
            _validator = validator;
            _goalService = goalService;
        }

        // GET: /Goal
        [HttpGet]
        [HttpHead]
        public ActionResult<IEnumerable<Goal>> GetGoals([FromQuery] int page = 1, [FromQuery] int pageSize = 10, [FromQuery] string filter = "") {
            var goals = _goalService.GetGoals(page, pageSize, filter);
            return Ok(goals);
        }

        [HttpGet("{goalId}")]
        [HttpHead]
        public ActionResult<Goal> GetGoalById(int goalId) {
            Goal goal = _goalService.GetGoalById(goalId);

            return Ok(goal);
        }

        // POST: /Goal
        [HttpPost(Name = "CreateGoal")]
        public ActionResult<Goal> CreateGoal([FromBody] GoalCreate goalCreate) {

            ValidationResult result = _validator.Validate(goalCreate);

            if(!result.IsValid) {
                return BadRequest(result.Errors[0].ErrorMessage);
            }

            Goal goal = _goalService.AddGoal(goalCreate);

            return CreatedAtRoute("CreateGoal", new { id = goal.Id }, goal);
        }

        //  PUT: /Goal/{goalId}
        [HttpPut("{goalId}")]
        public ActionResult<Goal> UpdateGoal(int goalId, [FromBody] GoalUpdate goalUpdate) {
            Goal goal = _goalService.UpdateGoal(goalId, goalUpdate);

            return Ok(goal);
        }

        // DELETE:/Goal/{goalId}
        [HttpDelete("{id}")]
        public IActionResult DeleteGoal(int id) {
            var deletedGoal = _goalService.DeleteGoalById(id);

            var response = new {
                message = $"Resource deleted: goal {id}",
                deletedGoal
            };

            return Ok(response);
        }
    }
}
