using BackEnd.Services;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using static BackEnd.Models.Pokemons;
using static BackEnd.Models.PokemonViews;

namespace BackEnd.Controllers;

[ApiController]
[Route("[controller]")]
[SwaggerTag("Pokemon Data")]
public class PkmnController : ControllerBase
{
    private readonly PkmnService _service;

    public PkmnController(PkmnService service) =>
        _service = service;

    [HttpGet("{natDex:int}")]
    [Tags("Pokemon Basic Infos")]
    public async Task<IActionResult> Get(int natDex)
    {
        var pkmn = await _service.GetAsync(natDex);
        
        return Ok(pkmn);
    }

    [HttpGet]
    [Tags("Pokemon Basic Infos")]
    public async Task<OkObjectResult> GetPokemonPageAsync(int page)
    {
        var results = await _service.GetListByPagesAsync(page);
        return Ok(results);
    }

    // GET: api/pkmn/{natDex}/favorite
    [HttpGet("{natDex:int}/favorite")]
    [Tags("Pokemon Favorite Bool")]
    public async Task<ActionResult> GetFavorite(int natDex)
    {
        var pkmnMain = await _service.GetFavAsync(natDex);
        return Ok(pkmnMain);
    }

    [HttpPut("{natDex:int}/update/favorite")]
    [Tags("Pokemon Favorite Bool")]
    public async Task<ActionResult> UpdateFavAsync(int natDex)
    {
        var updatedPkmn = await _service.UpdateFavAsync(natDex);
        return Ok(updatedPkmn);
    }


    //GET: api/pkmn/{eggGroupId}
    [HttpGet("/eggGroup/{id:int}")]
    [Tags("Pokemon Egg Group Data")]
    public async Task<ActionResult> GetEggGroupById(int id)
    {
        var pkmnEggGroup = await _service.GetEggGroupName(id);
        return Ok(pkmnEggGroup);
    }

    [HttpGet("/eggGroup/listByID/{id:int?}")]
    [Tags("Pokemon Egg Group Data")]
    public async Task<ActionResult> GetEggGroupPokemonsByID(int id)
    {
        List<ListPkmn.ByGroup> pkmn;
        if (id > 0)
        {
            pkmn = await _service.GetPokemonListEggByGroupId(id);
        }
        else
        {
            return BadRequest("Either id or name parameter must be provided.");
        }

        return Ok(pkmn);
    }

    [HttpGet("/eggGroup/listByName/{name}")]
    [Tags("Pokemon Egg Group Data")]
    public async Task<ActionResult> GetEggGroupPokemonsByName(string name)
    {
        List<ListPkmn.ByGroup>? pkmn;
        if (!string.IsNullOrEmpty(name))
        {
            pkmn = await _service.GetPkmnListByEggGroupName(name);
            if (pkmn == null)
            {
                return NotFound();
            }
        }
        else
        {
            return BadRequest("Either id or name parameter must be provided.");
        }

        return Ok(pkmn);
    }

    [HttpGet("/pokemon/types/{typeId:int}")]
    [Tags("Typing")]
    public async Task<ActionResult> GetPokemonsByType(int typeId)
    {
        var pkmnTypeList = await _service.GetPkmnTypeList(typeId);
        if (pkmnTypeList == null)
        {
            return NotFound();
        }
        return Ok(pkmnTypeList);
    }
    
}