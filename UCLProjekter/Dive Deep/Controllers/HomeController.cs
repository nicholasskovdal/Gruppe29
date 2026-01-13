using Microsoft.AspNetCore.Mvc;

namespace Dive_Deep.Controllers
{
    public class HomeController : Controller //HomeController class er afledet fra Controller Base class. Denne Base Class komme fra AspNetCore.Mvc namespace
    {
        //IActionResult er et interface der repræsenterer alle returtyper for alle action metoder. Det er en abstract af alle mulige returtyper 
        public IActionResult Index() //default metode. Alle action metoder bruges til at håndtere request
        {
            return View();
        }
    }
}
//Hvis vi skal følge vores MapControllerRoute pattern i program.cs - Så er Home vores navm på controllern -> Navnet på vores action method er Index.
//Så vores pattern til at mappe til denne action methode er /Home/Index