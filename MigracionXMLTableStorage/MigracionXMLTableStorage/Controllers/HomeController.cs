using MigracionXMLTableStorage.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MigracionXMLTableStorage.Controllers
{
    public class HomeController : Controller
    {
        ModeloHome modelo;
        public HomeController()
        {
            this.modelo = new ModeloHome();
        }
        public ActionResult Index()
        {
            modelo.CrearTabla();
            //ViewBag.Message = "Creada correctamente";
            return View();
        }
        //[HttpPost]
        //public ActionResult Index(String algo)
        //{
        //    modelo.CrearTabla();
        //    //ViewBag.Message = "Creada correctamente";
        //    return View();
        //}

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}