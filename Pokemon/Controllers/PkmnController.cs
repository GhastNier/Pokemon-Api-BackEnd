using Microsoft.AspNetCore.Mvc;
using MongoDB.Driver;
using MongoDB.Driver.Linq;
using Pokemon.Models;
using Pokemon.Services;


namespace Pokemon.Controllers;

[ApiController]
[Route("api/[controller]")]
public class PkmnController : ControllerBase
{
    private readonly PkmnMainService _mainService;

    public PkmnController(PkmnMainService mainService) =>
        _mainService = mainService;

    [HttpGet(Name = "GetPokemon")]
    public async Task<List<PokemonMain>> Get() =>
        await _mainService.GetAsync();

    [HttpGet("{id:length(24)}")]
    public async Task<ActionResult<PokemonMain>> Get(int id)
    {
        var pkmn = await _mainService.GetAsync(id);
        if (pkmn is null)
        {
            return NotFound();
        }

        return pkmn;
    }

    [HttpPost]
    public async Task<ActionResult> Post(PokemonMain newPkmn)
    {
        await _mainService.CreateAsync(newPkmn);
        return CreatedAtAction(nameof(Get), new { natDex = newPkmn.NatDex }, newPkmn);
    }

    [HttpPut("{natDex:length(6)}")]
    public async Task<ActionResult> Update(int natDex, PokemonMain updatePkm)
    {
        var pkmn = await _mainService.GetAsync(natDex);
        if (pkmn is null)
        {
            return NotFound();
        }

        updatePkm.Favorite = !pkmn.Favorite;
        await _mainService.UpdateAsync(natDex, pkmn);
        return NoContent();
    }
}