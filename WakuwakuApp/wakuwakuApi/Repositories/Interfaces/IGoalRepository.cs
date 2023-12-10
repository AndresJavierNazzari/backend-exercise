using wakuwakuApi.Models;

namespace wakuwakuApi.Repositories.Interfaces;
public interface IGoalRepository {

    IEnumerable<Goal> GetGoals();
    Goal GetGoalById(int goalId);
    Goal AddGoal(GoalCreate goalCreate);
    Goal UpdateGoal(int goalId, GoalUpdate goalUpdate);
    Goal DeleteGoalById(int goalId);
}

