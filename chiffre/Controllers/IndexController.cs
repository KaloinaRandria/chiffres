using chiffre.Models;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http.HttpResults;
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

    [HttpGet("nb/{number}")]
    public IActionResult GetNumber([FromRoute] string number)
    {
        var data = new { nombre = number };
        return Ok(data);
    }

    [HttpGet("nb/{sevenNumberJson}")]
    public IActionResult GetSevenNumber([FromRoute] string sevenNumberJson)
    {
        var data = new { nombreSept = sevenNumberJson };
        return Ok(data);
    }
    
    [HttpGet("sevenRandom")]
    public IActionResult GetSevenRandom()
    {
        var data = new { sevenNb = new Chiffre().RandomSevenNumber(100,7) };
        return Ok(data);
    }

    [HttpGet("genererJoueur")]
    public IActionResult GenererJoueurController()
    {
        Joueur[] joueurs = new Joueur().GenererJoueur();
        var data = new  { j = joueurs };
        return Ok(data);
    }
    
    [HttpGet("reponseEnvoye/{validation}/{number}")]
    public IActionResult ReponseEnvoye([FromRoute] string validation , [FromRoute] string number)
    {
        Joueur joueur = new Joueur();
        Joueur[] joueurs = joueur.JoueurValiderChoix(validation, number);
        var data = new { players = joueurs, tour = joueur.JoueurTour(joueurs) };
        return Ok(data);
    }

    [HttpGet("checkCombinaison/{validation}/{number}/{combinaison}/{sevenRandomJson}")]
    public IActionResult CheckCombinaison([FromRoute] string validation , [FromRoute] string number , [FromRoute] string combinaison , [FromRoute] string sevenRandomJson)
    {
        int gagnant = new Joueur().GetGagnant(validation, number, combinaison, sevenRandomJson.Trim());
        var data = new { winner = gagnant };
        return Ok(data);
    }
}