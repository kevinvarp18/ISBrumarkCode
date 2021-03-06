﻿using SistemaHotel.Domain;
using SistemaHotel.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using System.Web.Mvc;

namespace SistemaHotel.Controllers {
    public class HomeController : Controller {
        //Atributos
        String connectionString = WebConfigurationManager.ConnectionStrings["Sunset_Hotel"].ToString();

        public ActionResult Index() {
            PaginaHomeModel modelo = new PaginaHomeModel(this.connectionString);
            PagHome home = modelo.obtenerDatosIndex();
            ViewData["id"] = home.IdPagina;
            ViewData["descripcion"] = home.DescripcionPagina;
            ViewData["imagen"] = home.UrlImagen;
            ViewBag.Message = "nada";
            return View();
        }

        public ActionResult ComoLlegar() {
            return View();
        }
    }
}