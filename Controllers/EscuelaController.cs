using Microsoft.AspNetCore.Mvc;

namespace cursoASP.Controllers
{
    public class EscuelaController : Controller
    {
        public IActionResult Index()
        {
            //si no se especifica la vista, este regresa Index
            return View();
        }
    }
}