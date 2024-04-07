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
        List<Artista> artistas = GetArtistas();
        List<Tipo> tipos = GetTipos();
        ViewData["Tipos"] = tipos;
        return View(artistas);
    }

    public IActionResult Details(int Id)
    {
        List<Artista> artistas = GetArtistas();
        List<Tipo> tipos = GetTipos();
        DetailsVM details = new() {
            Tipos = tipos,
            Atual = artistas.FirstOrDefault(p => p.Id == Id),
            Anterior = artistas.OrderByDescending(p => p.Id).FirstOrDefault(p => p.Id < Id),
            Proximo = artistas.OrderBy(p => p.Id).FirstOrDefault(p => p.Id > Id),
        };
        return View(details);
    }

    private List<Artista> GetArtistas()
    {
        using (StreamReader leitor = new("Data\\Artista.json"))
        {
            string dados = leitor.ReadToEnd();
            return JsonSerializer.Deserialize<List<Artista>>(dados);
        }
    }

     private List<Tipo> GetTipos()
    {
        using (StreamReader leitor = new("Data\\Genero.json"))
        {
            string dados = leitor.ReadToEnd();
            return JsonSerializer.Deserialize<List<Tipo>>(dados);
        }
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
