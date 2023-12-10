using Asp.Versioning;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using wakuwakuApi.Models;
using wakuwakuApi.Services;
using wakuwakuApi.Services.Interfaces;

namespace wakuwakuApi.Controllers {
    [ApiController]
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/[controller]")]
    public class GoalController : ControllerBase {
        private readonly IGoalService _goalService;

        public GoalController(IGoalService goalService) {
            _goalService = goalService;
        }

        // GET: GoalController
        [HttpGet]
        public ActionResult<IEnumerable<Goal>> GetGoals([FromQuery] int page = 1, [FromQuery] int pageSize = 10, [FromQuery] string filter = "") {
            var goals = _goalService.GetGoals(page, pageSize, filter);
            return Ok(goals);
        }

        [HttpGet("{goalId}")]
        public ActionResult<Goal> GetGoalById(int goalId) {
            Goal goal = _goalService.GetGoalById(goalId);

            return Ok(goal);
        }

        // POST: GoalController
        [HttpPost(Name = "CreateGoal")]
        public ActionResult<Goal> CreateGoal([FromBody] GoalCreate goalCreate) {
            Goal goal = _goalService.AddGoal(goalCreate);

            return CreatedAtRoute("CreateGoal", new { id = goal.Id }, goal);
        }

        //  PUT: GoalController/5
        [HttpPut("{goalId}")]
        public ActionResult<Goal> UpdateGoal(int goalId, [FromBody] GoalUpdate goalUpdate) {
            Goal goal = _goalService.UpdateGoal(goalId, goalUpdate);

            return Ok(goal);
        }

        // DELETE: GoalController/5
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
