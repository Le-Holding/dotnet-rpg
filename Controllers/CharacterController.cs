using System.Collections.Generic;
using System.Linq;
using dotnet_rpg.Models;
using Microsoft.AspNetCore.Mvc;

namespace dotnet_rpg.Controllers
{
    [ApiController] // er en Atribute og denne står for at håndter HTTP kald
    [Route("[controller]")] // How we are able to finde this specefik controller, when whant to make a web service call.
    public class CharacterController : ControllerBase // We use ControllerBase since we do not use a view
    {
        public static List<character> characters = new List<character>{
            new character(),
            new character{  Id = 1, Name = "Sam" }
        };

        [HttpGet("Getall")]
        public IActionResult Get()
        {
            return Ok(characters);
        }
        [HttpGet("{id}")]
        public IActionResult GetSingel(int id)
        {
            return Ok(characters.FirstOrDefault(x => x.Id == id));
        }

        [HttpPost]
        public IActionResult AddCharater(character newCharacter)
        {
            characters.Add(newCharacter);
            return Ok(characters);
        }
    }
}