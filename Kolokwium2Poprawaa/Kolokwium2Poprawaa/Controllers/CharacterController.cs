using Kolokwium2Poprawaa.DTOs;
using Kolokwium2Poprawaa.Models;
using Kolokwium2Poprawaa.Services;
using Microsoft.AspNetCore.Mvc;

namespace Kolokwium2Poprawaa.Controllers;


[Route("api/[controller]")]
[ApiController]
public class CharacterController : ControllerBase
{
    private readonly IDbServices _dbService;

    public CharacterController(IDbServices dbService)
    {
        _dbService = dbService;
    }

    
    [HttpGet("characters/{characterId}")]
    public async Task<IActionResult> GetCharacterInfo(int characterId)
    {
        if (!await _dbService.DoesCharacterExist(characterId))
            return NotFound($"Character with given ID - {characterId} doesn't exist");
        
        var characterInfo = await _dbService.GetCharacterData(characterId);

        return Ok(characterInfo.Select(e => new GetCharacterInfoDTO
        {
            FirstName = e.FirstName,
            LastName = e.LastName,
            CurrentWeight = e.CurrentWeight,
            MaxWeight = e.MaxWeight,
            backpackItem = e.Backpack.Select(b => new GetBackpackItemDTO
            {
                itemName = b.Item.Name,
                itemWeight = b.Item.Weight,
                ammount = b.Amount
            }).ToList(),
            titles = e.Character_Titles.Select(t => new GetTitlesDTO
            {
                title = t.Title.Name,
                aquiredAt = t.AquiredAt
            }).ToList()
        }));
    }
}