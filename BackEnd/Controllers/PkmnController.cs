using BackEnd.Models;
using BackEnd.Services;
using Microsoft.AspNetCore.Mvc;

namespace BackEnd.Controllers;

[ApiController]
[Route("[controller]")]
public class PkmnController : ControllerBase
{
    private readonly PkmnMainService _mainService;

    public PkmnController(PkmnMainService mainService) =>
        _mainService = mainService;

    [HttpGet("{natDex:int}")]
    public async Task<IActionResult> Get(int natDex)
    {
        var pkmn = await _mainService.GetAsync(natDex);
        if (pkmn == null)
        {
            return NotFound();
        }

        return Ok(pkmn);
    }

    [HttpGet]
    public async Task<OkObjectResult> GetPokemonPageAsync(int page)
    {
        var results = await _mainService.GetListByPagesAsync(page);
        return Ok(results);
    }
    // [HttpPost]
    // public async Task<ActionResult> Post(PokemonBasics newPkmn)
    // {
    //     await _mainService.CreateAsync(newPkmn);
    //     return CreatedAtAction(nameof(Get), new { natDex = newPkmn.NatDex }, newPkmn);
    // }

    [HttpPut("{natDex:int}/update/favorite")]
    public async Task<ActionResult> UpdateFavAsync(int natDex)
    {
        var updatedPkmn = await _mainService.UpdateFavAsync(natDex);
        return Ok(updatedPkmn);
    }

    // GET: api/pkmn/{natDex}/favorite
    [HttpGet("{natDex:int}/favorite")]
    public async Task<ActionResult> GetFavorite(int natDex)
    {
        var pkmnMain = await _mainService.GetFavAsync(natDex);
        return Ok(pkmnMain);
    }
    //GET: api/pkmn/{eggGroupId}
    [HttpGet("/eggGroup/{id:int}")]
    public async Task<ActionResult> GetEggGroupById(int id)
    {
        var pkmnEggGroup = await _mainService.GetEggGroupName(id);
        return Ok(pkmnEggGroup);
    }
}