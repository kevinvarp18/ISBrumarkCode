using SistemaHotel.Domain;
using SistemaHotel.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using System.Web.Mvc;

namespace SistemaHotel.Controllers
{
    public class AdminSNosotrosController : Controller
    {
        String connectionString = WebConfigurationManager.ConnectionStrings["Sunset_Hotel"].ToString();

        // GET: AdminSNosotros
        public ActionResult AdminSNosotros()
        {
            AdminSNosotrosModel modelo = new AdminSNosotrosModel(this.connectionString);
            AdminSNosotrosPag home = modelo.obtenerDatosSobreNosotros();
            ViewData["id"] = home.IdPagina;
            ViewData["descripcion"] = home.DescripcionPagina;
            ViewData["imagen"] = home.UrlImagen;
            return View();
        }//AdminSNosotros

        [HttpPost]
        public ActionResult guardarCambios(int id, string descripcion, string imagen)
        {
            AdminSNosotrosModel modelo = new AdminSNosotrosModel(this.connectionString);
            AdminSNosotrosPag home = new AdminSNosotrosPag(id, descripcion, "C:/Users/Dylan/Source/Repos/ISBrumarkCode/SistemaHotel/img/homeIMG.jpg");
            bool res = modelo.actualizaDatosSobreNosotro(home);
            if (res)
            {
                ViewBag.Message = "Exitoso";
                return RedirectToAction("Index", "Home");
            }
            else
            {
                ViewBag.Message = "Error";
                return RedirectToAction("Index", "Home");
            }//if-else

        }//guardarCambios

        public ActionResult CancelarCambios()
        {
            return RedirectToAction("Index", "Home");
        }//CancelarCambios



    }//class
}//namepace