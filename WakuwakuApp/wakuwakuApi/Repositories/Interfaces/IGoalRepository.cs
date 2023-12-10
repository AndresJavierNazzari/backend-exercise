using wakuwakuApi.Models;

namespace wakuwakuApi.Repositories.Interfaces;
public interface IGoalRepository {

    IEnumerable<Goal> GetGoals();
    Goal GetGoalById(int goalId);
    Goal AddGoal(Goal goal);
    Goal UpdateGoal(int goalId, Goal goal);
    Goal DeleteGoalById(int goalId);

}

