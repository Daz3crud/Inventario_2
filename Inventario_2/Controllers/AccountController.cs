using Inventario_2.Models;
using Microsoft.AspNetCore.Mvc;

public class AccountController : Controller
{
    public IActionResult Login()
    {
        return View();
    }

    public IActionResult Register()
    {
        return View();
    }

    [HttpPost]
    public IActionResult Register(RegisterViewModel model)
    {
        if (ModelState.IsValid)
        {
            // Aquí puedes validar y procesar la información del formulario
            // Por ejemplo, verificar si el usuario ya existe, almacenar la información en la base de datos, etc.

            // Después de procesar, redirigir a la página de inicio (Index)
            return RedirectToAction("Index", "Home");
        }

        // Si llegamos aquí, significa que hubo un error en el modelo, volver a la vista de registro con los errores
        return View(model);
    }

    [HttpPost]
    public IActionResult Login(string username, string password)
    {
        // Verificar las credenciales (en este ejemplo, solo comparamos con valores estáticos)
        if (username == "admin" && password == "admin")
        {
            // Credenciales válidas, redirigir a la página deseada (por ejemplo, "Home")
            return RedirectToAction("Index", "Home");
        }

        // Credenciales incorrectas, mostrar mensaje de error
        ViewBag.Error = "Credenciales incorrectas";
        return View();
    }
}
