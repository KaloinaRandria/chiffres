using chiffre.Models;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;

namespace chiffre.Controllers;
[Route("[controller]")]
[ApiController]
[EnableCors("AllowAllOrigins")]
public class IndexController : ControllerBase
{
    [HttpGet]
    public IActionResult GetMessage()
    {
        var data = new { hello = "Welcome to Mada" };
        return Ok(data);
    }
    [HttpGet("kdj")]
    public IActionResult GetKdj()
    {
        var data = new { kdj = new TestModels().getName() };
        return Ok(data);
    }
    
    [HttpGet("number")]
    public IActionResult GetNumberRandom()
    {
        var data = new { nb = new Chiffre().RandomNumber(1000) };
        return Ok(data);
    }
    
    [HttpGet("sevenRandom")]
    public IActionResult GetSevenRandom()
    {
        var data = new { sevenNb = new Chiffre().RandomSevenNumber(100,7) };
        return Ok(data);
    }
}