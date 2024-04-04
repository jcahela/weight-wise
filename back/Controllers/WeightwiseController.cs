using Microsoft.AspNetCore.Mvc;
using back.Models;
using back.Services;

namespace back.Controllers;

[ApiController]
[Route("[controller]")]
public class WeightwiseController : ControllerBase
{
    

    private readonly WeightwiseContext _DBContext;

    public WeightwiseController(WeightwiseContext dBContext)
    {
        this._DBContext = dBContext;
    }

    [HttpGet(Name = "getAllExercises")]
    public IActionResult getAllExercises()
    {
        var exercises = new ExerciseService(_DBContext);
        return Ok(exercises.GetAllExercises());
    }
}
