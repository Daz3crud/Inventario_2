using Inventario_2.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Diagnostics;

namespace Inventario_2.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
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

        [HttpGet]
        public IActionResult PruebaGratuita()
        {
            // Página de formulario de prueba gratuita
            return View();
        }

        [HttpPost]
        public IActionResult ProcesarFormulario(string nombre, string correo)
        {
            // Aquí debes manejar la lógica para procesar la información del formulario
            // Puedes guardar los datos en la base de datos, enviar un correo, etc.

            // Por ahora, solo redirigiremos a una página de agradecimiento
            return RedirectToAction("Agradecimiento");
        }

        public IActionResult Agradecimiento()
        {
            // Página de agradecimiento, puedes personalizarla según tus necesidades
            return View();
        }
    }
}
// En tu controlador o en un nuevo controlador
public class TuControlador : Controller
{
    [HttpPost]
    [Route("/ProcesarFormulario")]
    public IActionResult ProcesarFormulario(string nombre, string correo)
    {
        // Aquí procesas los datos del formulario
        // Puedes redirigir a otra página o hacer lo que sea necesario
        return View();
    }
}
