using SistemaHotel.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using System.Web.Mvc;


namespace SistemaHotel.Controllers { 
    public class ReservaController : Controller {
        String connectionString = WebConfigurationManager.ConnectionStrings["Sunset_Hotel"].ToString();

        public ActionResult HabitacionDisponible() {
            return View();
        }
        
        // GET: Reserva
        [HttpGet]
        public ActionResult Reserva(int idHabitacion) {
            ReservaModel rm = new ReservaModel(connectionString);
            List<string> habitacion = rm.obtenerDatosHabitacion(idHabitacion);

            //for (int i = 0; i < 4; i++) {
            //    ViewBag.Message += habitacion.ElementAt(i).ToString() + " ";
            //}
            
            ViewData["numero"] = habitacion.ElementAt(0).ToString();
            ViewData["descripcion"] = habitacion.ElementAt(1).ToString();
            ViewData["imagen"] = habitacion.ElementAt(2).ToString();
            ViewData["tarifa"] = habitacion.ElementAt(3).ToString();
            return View();
        }
            
        [HttpPost]
        public ActionResult Reserva(string nombreReserva, string apellidoReserva, string correoReserva, string tarjetaReserva) {
            ReservaModel rm = new ReservaModel(connectionString);

            bool resultado = rm.RealizarReserva(nombreReserva,apellidoReserva,correoReserva,tarjetaReserva);

            if (resultado) { 
                ViewBag.Message = "La reserva se realizó exitosamente";
            }else{
                ViewBag.Message = "La reserva no pudo realizar";
            }
            return View(resultado);
        }
    }
}