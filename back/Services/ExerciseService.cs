using back.Models;

namespace back.Services;
public class ExerciseService
{
  private readonly WeightwiseContext _DBContext;

  public ExerciseService(WeightwiseContext dBContext)
  {
    this._DBContext = dBContext;
  }

  public IEnumerable<Exercise> GetAllExercises()
  {
    return (
      _DBContext.Exercises
        .Select(e => e)
        .OrderBy(e => e.Name)
    );
  }

  public IEnumerable<Routine> GetAllRoutines()
  {
    return (
      _DBContext.Routines
    );
  }
}
