using wakuwakuApi.Models;

namespace wakuwakuApi.Services.Interfaces {
    public interface IGoalService {
        IEnumerable<Goal> GetGoals(int page, int pageSize, string filter);
        Goal GetGoalById(int goalId);
        Goal AddGoal(GoalCreate goalCreate);
        Goal UpdateGoal(int goalId, GoalUpdate goalUpdate);
        Goal DeleteGoalById(int goalId);
    }
}
