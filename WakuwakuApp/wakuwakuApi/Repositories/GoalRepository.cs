using System;
using wakuwakuApi.Exceptions;
using wakuwakuApi.Models;
using wakuwakuApi.Persistence.Interfaces;
using wakuwakuApi.Repositories.Interfaces;

namespace wakuwakuApi.Repositories;
public class GoalRepository : IGoalRepository {
    private readonly IInMemoryPersistenceService _context;

    public GoalRepository(IInMemoryPersistenceService context) {
        ArgumentNullException.ThrowIfNull(context);
        _context = context;
    }
    public IEnumerable<Goal> GetGoals() {
        var goalsList = _context.Goals ?? throw new Exception();
        NotFoundException.ThrowIfNull(goalsList);

        return goalsList;

    }

    public Goal GetGoalById(int goalId) {
        var goalsList = _context.Goals;

        Goal? goal = goalsList.FirstOrDefault(g => g.Id == goalId);

        NotFoundException.ThrowIfNull(goal);

        return goal;
    }
    public Goal AddGoal(GoalCreate goalCreate) {
        var goalsList = _context.Goals;

        Goal createdGoal = new Goal( goalCreate.Description, goalCreate.DateOfCreation, goalCreate.Deadline, goalCreate.Status);

        goalsList.Add(createdGoal);

        return createdGoal;
    }
    public Goal UpdateGoal(int goalId, GoalUpdate goalUpdate) {
        var goalsList = _context.Goals;
        Goal? existingGoal = goalsList.FirstOrDefault(g => g.Id == goalId);
        NotFoundException.ThrowIfNull(existingGoal);

        existingGoal.Description = goalUpdate.Description;
        existingGoal.DateOfCreation = goalUpdate.DateOfCreation;
        existingGoal.Deadline = goalUpdate.Deadline;
        existingGoal.Status = goalUpdate.Status;

        return existingGoal;
    }
    public Goal DeleteGoalById(int goalId) {
        var goalsList = _context.Goals;
        Goal? deletedGoal = goalsList.FirstOrDefault(g => g.Id == goalId);

        NotFoundException.ThrowIfNull(deletedGoal);
        goalsList.Remove(deletedGoal);

        return deletedGoal;
    }

}

