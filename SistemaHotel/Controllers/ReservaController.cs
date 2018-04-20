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
    public class ReservaController : Controller
    {
        String connectionString = WebConfigurationManager.ConnectionStrings["Sunset_Hotel"].ToString();
        string numeroHabitacion = "";

        public ActionResult HabitacionDisponible()
        {
            ReservaModel reservaModel = new ReservaModel(connectionString);
            List<TipoHabitacion> tiposHabitacion = reservaModel.obtenerTiposHabitacion();
            return View(tiposHabitacion);
        }//Fin de la funcion HabitacionDisponible

        [HttpPost]
        public ActionResult HabitacionDisponible(DateTime fechaLlegada, DateTime fechaSalida, int tipoHabitacion)
        {
            ReservaModel reservaModel = new ReservaModel(connectionString);
            List<Habitacion> habitacionesDisponibles = reservaModel.consultarDisponibilidad(tipoHabitacion);
            if (habitacionesDisponibles.Count > 0)
                return RedirectToAction("Reserva", "Reserva", new { idHabitacion = habitacionesDisponibles.First().Id, fechaLlegada = fechaLlegada, fechaSalida = fechaSalida });
            else
                return RedirectToAction("ResultadoReserva", "Reserva");
        }//Fin de la función HabitacionDisponible.

        public ActionResult Reserva(int idHabitacion, DateTime fechaLlegada, DateTime fechaSalida)
        {
            ReservaModel reservaModel = new ReservaModel(connectionString);
            List<string> habitacion = reservaModel.obtenerDatosHabitacion(idHabitacion);

            ViewData["numero"] = habitacion.ElementAt(0).ToString();
            ViewData["descripcion"] = habitacion.ElementAt(1).ToString();
            ViewData["imagen"] = habitacion.ElementAt(2).ToString();
            ViewData["tarifa"] = habitacion.ElementAt(3).ToString();
            numeroHabitacion = habitacion.ElementAt(0).ToString();

            return View();
        }//Fin de la función Reserva.

        [HttpPost]
        public ActionResult Reserva(string nombreReserva, string apellidoReserva, string correoReserva, string tarjetaReserva)
        {
            ReservaModel rm = new ReservaModel(connectionString);

            bool resultado = rm.RealizarReserva(nombreReserva, apellidoReserva, correoReserva, tarjetaReserva, 1);
            //bool resultado = rm.RealizarReserva(nombreReserva,apellidoReserva,correoReserva,tarjetaReserva,int.Parse(this.numero));

            if (resultado)
            {
                ViewBag.Message = "La reserva se realizó exitosamente";
            }
            else
            {
                ViewBag.Message = "La reserva no pudo realizar";
            }
            return View(resultado);
        }
    }
}