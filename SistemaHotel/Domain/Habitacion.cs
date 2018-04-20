using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SistemaHotel.Domain {
    public class Habitacion {
        private int id;
        private int numeroHabitacion;
        private int tipoHabitacion;
        private int estado;
        private int borrado;
        private string descripcion;
        private string urlImagen;

        public Habitacion() {
            this.id = 0;
            this.numeroHabitacion = 0;
            this.tipoHabitacion = 0;
            this.estado = 0;
            this.borrado = 0;
            this.descripcion = "";
            this.urlImagen = "";
        }//Fin del constructor.

        public Habitacion(int id, int numeroHabitacion, int tipoHabitacion, int estado, int borrado, string descripcion, string urlImagen) {
            this.id = id;
            this.numeroHabitacion = numeroHabitacion;
            this.tipoHabitacion = tipoHabitacion;
            this.estado = estado;
            this.borrado = borrado;
            this.descripcion = descripcion;
            this.urlImagen = urlImagen;
        }//Fin del constructor sobrecargado.

        public int Id {
            get {
                return this.id;
            }//Get.

            set {
                this.id = value;
            }//Set.
        }//Método accesor Id.

        public int NumeroHabitacion {
            get {
                return this.numeroHabitacion;
            }//Get

            set {
                this.numeroHabitacion = value;
            }//Set
        }//Método accesor NumeroHabitacion.

        public int TipoHabitacion {
            get {
                return this.tipoHabitacion;
            }//Get

            set {
                this.tipoHabitacion = value;
            }//Set
        }//Método accesor TipoHabitacion.

        public int Estado {
            get {
                return this.estado;
            }//Get

            set {
                this.estado = value;
            }//Set
        }//Método accesor Estado.

        public int Borrado {
            get {
                return this.borrado;
            }//Get

            set {
                this.borrado = value;
            }//Set
        }//Método accesor Estado.

        public string Descripcion {
            get {
                return this.descripcion;
            }//Get

            set {
                this.descripcion = value;
            }//Set
        }//Método accesor Estado.

        public string UrlImagen {
            get {
                return this.urlImagen;
            }//Get

            set {
                this.urlImagen = value;
            }//Set
        }//Método accesor Estado.
    }//Fin de la clase Habitacion.
}//Fin del namespace.