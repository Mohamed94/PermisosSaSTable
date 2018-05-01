using ClienteTablaCoches.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ClienteTablaCoches.Controllers
{
    public class CochesController : Controller
    {
        ModeloCoches modelo;
        public CochesController()
        {
            this.modelo = new ModeloCoches();
        }
        [AcceptVerbs(HttpVerbs.Post | HttpVerbs.Get)]
        public ActionResult Index(String marca)
        {
            if (marca != null)
            {
                List<Coches> lista = modelo.BuscarMarca(marca);
                if (lista == null)
                {
                    ViewBag.Mensaje = "No existen en la BBDD coches de esa marca";
                    return View();
                }
                return View(lista);
            }
            return View();
            
        }
        public ActionResult Delete(String id, String marca)
        {
            modelo.EliminarCoche(id, marca);
            return RedirectToAction("Index", new {marca =marca });
        }
        //public ActionResult Create()
        //{           
        //    return View();
        //}
        //[HttpPost]
        //public ActionResult Create(String RowKey, String PartitionKey, String Modelo,String Tipo,String Coste)
        //{
        //    modelo.InsertarCoche(RowKey, PartitionKey, Modelo, Tipo, Coste);
        //    return RedirectToAction("Index");
        //}
    }
}