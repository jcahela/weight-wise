using Microsoft.AspNetCore.Mvc;
using back.Models;
using back.Services;

namespace back.Controllers;

[ApiController]
[Route("[controller]")]
public class ExerciseController : ControllerBase
{
    

    private readonly WeightwiseContext _DBContext;

    public ExerciseController(WeightwiseContext dBContext)
    {
        this._DBContext = dBContext;
    }

    [HttpGet("Exercises", Name = "getAllExercises")]
    public IActionResult getAllExercises()
    {
        var exercises = new ExerciseService(_DBContext);
        return Ok(exercises.GetAllExercises());
    }

    [HttpGet("Users", Name = "getAllUsers")]
    public IActionResult getAllUsers()
    {
        var users = new UserService(_DBContext);
        return Ok(users.GetAllUsers());
    }
}
