using dota2_heroes_webApi.Models;
using dota2_heroes_webApi.Source.Main.Parsers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace dota2_heroes_webApi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class MainController : ControllerBase
{
    private readonly ILogger<MainController> logger;
    private readonly IConfiguration configuration;
    private readonly ParserWorker parserWorker;
    public MainController(ILogger<MainController> logger, IConfiguration configuration)
    {
        this.configuration = configuration;
        this.logger = logger;

        parserWorker = new ParserWorker(new BuildItemsParser());
    }

    [HttpGet]
    public async Task<IActionResult> BuildSearch([FromBody] SearchString searchString)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        Build build = await parserWorker.GetBuildAsync(searchString.SearchHero);
        return Ok(JsonConvert.SerializeObject(build));
    }
}