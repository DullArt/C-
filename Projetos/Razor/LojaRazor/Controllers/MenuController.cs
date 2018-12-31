using System;

namespace LojaRazor.Controllers
{
    public class MenuController: Controller
    {
        public IActionResult Index()
        {
            DepartamentosDAO departamentosDAO = new DepartamentosDAO();
            ViewBag.Departamentos = departamentosDAO.Lista();
        }
    }
}
