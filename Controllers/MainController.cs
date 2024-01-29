using dota2_heroes_webApi.Models;
using dota2_heroes_webApi.Source.Main.Parsers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace dota2_heroes_webApi.Controllers;

[ApiController]
[Route("api/")]
public class MainController : ControllerBase
{
    private readonly ILogger<MainController> _logger;
    private readonly IConfiguration _configuration;
    private readonly ParserWorker _parserWorker;
    public MainController(ILogger<MainController> logger, IConfiguration configuration)
    {
        _configuration = configuration;
        _logger = logger;

        _parserWorker = new ParserWorker(new BuildItemsParser());
    }

    [Route("/api/get")]
    [HttpGet]
    public async Task<IActionResult> BuildSearch([FromQuery] string name)
    {
        // if (!ModelState.IsValid)
            // return BadRequest(ModelState);

        Build build = await _parserWorker.GetBuildAsync(name);
        return Ok(JsonConvert.SerializeObject(build));
    }
}