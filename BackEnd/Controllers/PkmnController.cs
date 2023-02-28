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
    public async Task<IActionResult> GetPokemonPageAsync(int page)
    {
        var (results, totalCount) = await _mainService.GetListByPagesAsync(page);
        var count = results.Count;
        var totalPages = (int)Math.Ceiling((double)totalCount / 5);

        var response = new
        {
            Page = page,
            TotalPages = totalPages,
            TotalCount = totalCount,
            Count = count,
            Results = results
        };

        return Ok(response);
    }
    // [HttpPost]
    // public async Task<ActionResult> Post(PokemonMain newPkmn)
    // {
    //     await _mainService.CreateAsync(newPkmn);
    //     return CreatedAtAction(nameof(Get), new { natDex = newPkmn.NatDex }, newPkmn);
    // }

    [HttpPut("{natDex:int}/update/favorite")]
    public async Task<ActionResult> UpdateFavAsync(int natDex)
    {
        //updatePkm.Favorite = !pkmn.Favorite;
        await _mainService.UpdateFavAsync(natDex);
        return NoContent();
    }

    // GET: api/pkmn/{natDex}/favorite
    [HttpGet("{natDex}/favorite")]
    public async Task<ActionResult> GetFavorite(int natDex)
    {
        var pkmnMain = await _mainService.GetFavorite(natDex);
        return Ok(pkmnMain.Favorite);
    }
}