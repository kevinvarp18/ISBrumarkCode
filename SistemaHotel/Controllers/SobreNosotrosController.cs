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
    public class SobreNosotrosController : Controller
    {
        String connectionString = WebConfigurationManager.ConnectionStrings["Sunset_Hotel"].ToString();

        // GET: SobreNosotros
        public ActionResult SobreNosotros()
        {
            AdminSNosotrosModel modelo = new AdminSNosotrosModel(this.connectionString);
            AdminSNosotrosPag home = modelo.obtenerDatosSobreNosotros();
            ViewData["id"] = home.IdPagina;
            ViewData["descripcion"] = home.DescripcionPagina;
            ViewData["imagen"] = home.UrlImagen;
            ViewBag.Message = "nada";
            return View();
        }
    }
}