using dota2_heroes_webApi.Models;
using Microsoft.AspNetCore.Mvc;


namespace dota2_heroes_webApi.Controllers;

[ApiController]
public class MainController : ControllerBase
{
    private readonly ILogger<MainController> logger;
    private readonly IConfiguration configuration;
    
}