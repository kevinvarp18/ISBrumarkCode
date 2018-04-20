using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SistemaHotel.Domain {
    public class TipoHabitacion {
        private int id;
        private float tarifa;
        private string descripcion;
        private int cantidadPersonas;

        public TipoHabitacion() {
            this.id = 0;
            this.tarifa = 0;
            this.descripcion = "";
            this.cantidadPersonas = 0;
        }//Fin del constructor.

        public TipoHabitacion(int id, float tarifa, string descripcion, int cantidadPersonas) {
            this.id = id;
            this.tarifa = tarifa;
            this.descripcion = descripcion;
            this.cantidadPersonas = cantidadPersonas;
        }//Fin del constructor sobrecargado.

        public int Id {
            get {
                return this.id;
            }//Get.

            set {
                this.id = value;
            }//Set.
        }//Método accesor Id.

        public float Tarifa {
            get {
                return this.tarifa;
            }//Get

            set {
                this.tarifa = value;
            }//Set
        }//Método accesor Tarifa.

        public String Descripcion {
            get {
                return this.descripcion;
            }//Get

            set {
                this.descripcion = value;
            }//Set
        }//Método accesor Descripcion.

        public int CantidadPersonas {
            get {
                return this.cantidadPersonas;
            }//Get

            set {
                this.cantidadPersonas = value;
            }//Set
        }//Método accesor CantidadPersonas.
    }//Fin de la clase.
}//Fin del namespace.