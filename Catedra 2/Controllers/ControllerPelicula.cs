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

        public IActionResult Update(int IdPelicula)
        {
            var ObjEmployee = _GetPeli.GetDataInfo(IdPelicula);
            return View(ObjEmployee);
        }

        [HttpPost]
        public IActionResult Update(ModeloPelicula emReq)
        {
            if (!ModelState.IsValid)
                return View();

            var response = _GetPeli.UpdateData(emReq);
            if (response)
                return RedirectToAction("List");
            else
                return View();
        }

        // Metodo para Eliminar datos
        public IActionResult Delete(int PlErq)
        {
            var ObjEmployee = _GetPeli.GetDataInfo(PlErq);
            return View(ObjEmployee);
        }

        [HttpPost]
        public IActionResult Delete(ModeloPelicula PlErq)
        {
            if (!ModelState.IsValid)
                return View();

            var response = _GetPeli.DeleteData(PlErq);
            if (response)
                return RedirectToAction("List");
            else
                return View();
        }
    }
}
