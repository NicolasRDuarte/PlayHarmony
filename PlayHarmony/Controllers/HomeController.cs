using System.Diagnostics;
using System.Text.Json;
using Microsoft.AspNetCore.Mvc;
using PlayHarmony.Models;

namespace PlayHarmony.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;

    public HomeController(ILogger<HomeController> logger)
    {
        _logger = logger;
    }

    public IActionResult Index()
    {
        List<Artista> artistas = [];
        using (StreamReader leitor = new("Data\\Artista.json"))
        {
            string dados = leitor.ReadToEnd();
            artistas = JsonSerializer.Deserialize<List<Artista>>(dados);
        }
        List<Tipo> tipos = [];
        using (StreamReader leitor = new("Data\\Genero.json"))
        {
            string dados = leitor.ReadToEnd();
            tipos = JsonSerializer.Deserialize<List<Tipo>>(dados);
        }
        ViewData["Tipos"] = tipos;
        return View(artistas);
    }

    public IActionResult Privacy()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
