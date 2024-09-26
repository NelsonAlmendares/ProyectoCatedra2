using Catedra_2.Data;
using Microsoft.AspNetCore.Mvc;

namespace Catedra_2.Controllers
{
    public class ControllerPelicula : Controller
    {
        DataPelicula GetPeli = new DataPelicula();
        // No usado
        public IActionResult List()
        {
            // Mostraremos los registros de la base de datos en una vista 
            var ObjList = GetPeli.Shown();
            return View(ObjList);
        }
    }
}
