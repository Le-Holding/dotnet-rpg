using System.Collections.Generic;
using System.Linq;
using dotnet_rpg.Models;
using dotnet_rpg.Services.CharacterService;
using Microsoft.AspNetCore.Mvc;

namespace dotnet_rpg.Controllers
{
    [ApiController] // er en Atribute og denne står for at håndter HTTP kald
    [Route("[controller]")] // How we are able to finde this specefik controller, when whant to make a web service call.
    public class CharacterController : ControllerBase // We use ControllerBase since we do not use a view
    {
        private readonly ICharacterService _characterService;
        public CharacterController(ICharacterService characterService)
        {
            _characterService = characterService;
        }

        [HttpGet("Getall")]
        public IActionResult Get()
        {
            return Ok(_characterService.GetAllCharacters());
        }
        [HttpGet("{id}")]
        public IActionResult GetSingel(int id)
        {
            return Ok(_characterService.GetCharacterByID(id));
        }

        [HttpPost]
        public IActionResult AddCharater(Character newCharacter)
        {
            return Ok(_characterService.AddCharacter(newCharacter));
        }
    }
}