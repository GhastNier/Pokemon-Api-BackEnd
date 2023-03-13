using BackEnd.Services;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace BackEnd.Controllers;
[ApiController]
[Route("[controller]")]
[SwaggerTag("PkmnPokedex Data")]
public class PokedexController : ControllerBase
{
    private readonly  PokedexService _service;
    public PokedexController(PokedexService service) =>
        _service = service;

    [HttpGet("/dex/")]
    [Tags("PkmnPokedex Infos")]
    public async Task<OkObjectResult> GetAllDexNames()
    {
        var pkmn = await _service.GetAsync();
        return Ok(pkmn);
    }
}