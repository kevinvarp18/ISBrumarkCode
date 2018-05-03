using SistemaHotel.Domain;
using SistemaHotel.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Web;
using System.Web.Configuration;
using System.Web.Mvc;

namespace SistemaHotel.Controllers {
    public class ReservaController : Controller {
        String connectionString = WebConfigurationManager.ConnectionStrings["Sunset_Hotel"].ToString();
        string numeroHabitacion = "";

        public ActionResult HabitacionDisponible() {
            ReservaModel reservaModel = new ReservaModel(connectionString);
            List<TipoHabitacion> tiposHabitacion = reservaModel.obtenerTiposHabitacion();
            return View(tiposHabitacion);
        }//Fin de la funcion HabitacionDisponible

        [HttpPost]
        public ActionResult HabitacionDisponible(DateTime fechaLlegada, DateTime fechaSalida, int tipoHabitacion) {
            ReservaModel reservaModel = new ReservaModel(connectionString);
            List<Habitacion> habitacionesDisponibles = reservaModel.consultarDisponibilidad(tipoHabitacion);
            if (habitacionesDisponibles.Count > 0)
                return RedirectToAction("Reserva", "Reserva", new { idHabitacion = habitacionesDisponibles.First().Id, fechaLlegada = fechaLlegada, fechaSalida = fechaSalida });
            else
                return RedirectToAction("ResultadoReserva", "Reserva", new { nombreCliente = "", correoElectronico = "", numeroReserva = "", resultadoReserva = "2" });
        }//Fin de la función HabitacionDisponible.

        public ActionResult Reserva(int idHabitacion, DateTime fechaLlegada, DateTime fechaSalida) {
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
        public ActionResult Reserva(string nombreReserva, string apellidoReserva, string correoReserva, string tarjetaReserva, int numeroHabitacion) {
            ReservaModel reservaModel = new ReservaModel(connectionString);
            bool resultado = reservaModel.RealizarReserva(nombreReserva, apellidoReserva, correoReserva, tarjetaReserva, numeroHabitacion);

            if (resultado) {
                MailMessage email = new MailMessage();
                email.To.Add(new MailAddress(correoReserva));
                email.From = new MailAddress("sunsethotelinfo@gmail.com");
                email.Subject = "Asunto ( " + DateTime.Now.ToString("dd / MMM / yyy hh:mm:ss") + " ) ";
                email.Body = "Prueba";
                email.IsBodyHtml = true;
                email.Priority = MailPriority.Normal;
                SmtpClient smtp = new SmtpClient();
                smtp.Host = "smtp.gmail.com";
                smtp.Port = 587;
                smtp.EnableSsl = false;
                smtp.UseDefaultCredentials = false;
                smtp.Credentials = new NetworkCredential("sunsethotelinfo@gmail.com", "sunsethotel1123");
                smtp.Send(email);
                email.Dispose();

                return RedirectToAction("ResultadoReserva", "Reserva", new { nombreCliente = nombreReserva + " " + apellidoReserva, correoElectronico = correoReserva, numeroReserva = "abc" , resultadoReserva = "1"});
            }else{
                ViewBag.Message = "La reserva no se pudo realizar";
                return View(resultado);
            }//Fin del if.
        }//Fin de la función Reserva.

        public ActionResult ResultadoReserva(string nombreCliente, string correoElectronico, string numeroReserva, string resultadoReserva) {
            ViewData["Cliente"] = nombreCliente;
            ViewData["Correo"] = correoElectronico;
            ViewData["NumeroReserva"] = numeroReserva;
            ViewData["Resultado"] = resultadoReserva;
            return View();
        }//Fin de la función ResultadoReserva.
    }//Fin de la clase ReservaController.
}//Fin del namespace.