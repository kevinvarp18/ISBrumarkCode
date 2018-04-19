using SistemaHotel.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using System.Web.Mvc;


namespace SistemaHotel.Controllers
{
    public class ReservaController : Controller
    {
        String connectionString = WebConfigurationManager.ConnectionStrings["Sunset_Hotel"].ToString();
        // GET: Reserva
        public ActionResult Reserva()
        {
            return View();
        }

        public ActionResult RealizarReserva(string nombreReserva, string apellidoReserva, string correoReserva, string tarjetaReserva)
        {
            ReservaModel rm = new ReservaModel(connectionString);

            bool resultado = rm.RealizarReserva(nombreReserva,apellidoReserva,correoReserva,tarjetaReserva);

            return View();
        }
    }
}