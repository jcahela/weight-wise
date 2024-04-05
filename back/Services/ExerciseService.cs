using back.Models;

namespace back.Services;
public class ExerciseService
{
  private readonly WeightwiseContext _DBContext;

  public ExerciseService(WeightwiseContext dBContext)
  {
    this._DBContext = dBContext;
  }

  public IEnumerable<Dtos.ExerciseDto> GetAllExercises()
  {
    return (
      _DBContext.Exercises
        .OrderBy(e => e.Name)
        .Select(e => e.ToDto())
        .ToList()
    );
  }

  public IEnumerable<Routine> GetAllRoutines()
  {
    return (
      _DBContext.Routines
    );
  }
}
