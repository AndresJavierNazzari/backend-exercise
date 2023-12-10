using wakuwakuApi.Exceptions;
using wakuwakuApi.Models;
using wakuwakuApi.Repositories.Interfaces;
using wakuwakuApi.Services.Interfaces;

namespace wakuwakuApi.Services {
    public class GoalService : IGoalService {
        private readonly IGoalRepository _goalRepository;

        public GoalService(IGoalRepository goalRepository) {
            _goalRepository = goalRepository;
        }

        public IEnumerable<Goal> GetGoals(int page, int pageSize, string filter) {
            var goalList = _goalRepository.GetGoals();
            var paginatedGoals = goalList.Skip((page - 1) * pageSize).Take(pageSize);

            if(!string.IsNullOrEmpty(filter)) {
                paginatedGoals =
                    paginatedGoals.Where(c => c.Description.Contains(filter, StringComparison.OrdinalIgnoreCase));
            }

            return paginatedGoals;
        }

        public Goal GetGoalById(int goalId) {
            Goal goal = _goalRepository.GetGoalById(goalId);

            return goal;
        }

        public Goal AddGoal(GoalCreate goalCreate) {
            Goal createdGoal = _goalRepository.AddGoal(goalCreate);

            return createdGoal;
        }

        public Goal UpdateGoal(int goalId, GoalUpdate goalUpdate) {
            Goal updatedGoal = _goalRepository.UpdateGoal(goalId, goalUpdate);

            return updatedGoal;
        }

        public Goal DeleteGoalById(int goalId) {
            Goal goal = _goalRepository.DeleteGoalById(goalId);
            NotFoundException.ThrowIfNull(goal);

            return goal;
        }   
    }
}
