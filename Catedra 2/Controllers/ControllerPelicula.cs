using Catedra_2.Data;
using Catedra_2.Models;
using Microsoft.AspNetCore.Mvc;

namespace Catedra_2.Controllers
{
    public class ControllerPelicula : Controller
    {
        DataPelicula _GetPeli = new DataPelicula();
        // No usado
        public IActionResult List()
        {
            // Mostraremos los registros de la base de datos en una vista 
            var ObjList = _GetPeli.Shown();
            return View(ObjList);
        }

        public IActionResult Save()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Save(ModeloPelicula PeliReq)
        {
            if (!ModelState.IsValid)
                return View();

            var response = _GetPeli.SaveData(PeliReq);
            if (response)
            {
                return RedirectToAction("List");
            }
            else
            {
                return View();
            }
        }
    }
}
