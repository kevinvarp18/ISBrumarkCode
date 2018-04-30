using SistemaHotel.Domain;
using SistemaHotel.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using System.Web.Mvc;

namespace SistemaHotel.Controllers { 
    public class AdminHomeController : Controller{
        //Atributos
        String connectionString = WebConfigurationManager.ConnectionStrings["Sunset_Hotel"].ToString();

        // GET: AdminHome
        public ActionResult AdminHome(){
            PaginaHomeModel modelo = new PaginaHomeModel(this.connectionString);
            PagHome home = modelo.obtenerDatosIndex();
            ViewData["id"] = home.IdPagina;
            ViewData["descripcion"] = home.DescripcionPagina;
            ViewData["imagen"] = home.UrlImagen;
            return View();
        }//End AdminHome()

        [HttpPost]
        public ActionResult CancelarCambios(){
            return RedirectToAction("Index", "Home");
        }//End AdminHome()

        [HttpPost]
        public ActionResult guardarCambios(int id, string descripcion, string imagen){
            PaginaHomeModel modelo = new PaginaHomeModel(this.connectionString);
            //PagHome home = new PagHome(id,descripcion,imagen);
            PagHome home = new PagHome(id, descripcion, "C:/Users/Dylan/Source/Repos/ISBrumarkCode/SistemaHotel/img/homeIMG.jpg");
            bool res = modelo.actualizaDatosIndex(home);
            if (res){
                ViewBag.Message = "funca";
                return View();
            }else{
                ViewBag.Message = "Error de conecion";
                return View(res);
            }//End if-else (res)
        }//End AdminHome()

    }//End public class AdminHomeController : Controller

}//End namespace SistemaHotel.Controllers