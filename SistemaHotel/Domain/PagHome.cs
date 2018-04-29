using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SistemaHotel.Domain{
    public class PagHome{
        //Atributos
        private int idPagina;
        private string descripcionPagina;
        private string urlImagen;        

        public PagHome() {
            this.idPagina = 0;
            this.descripcionPagina = "";
            this.urlImagen = "";
        }//End constructor default 

        public PagHome(int idPagina,string descripcionPagina,string urlImagen){
            this.idPagina = idPagina;
            this.descripcionPagina = descripcionPagina;
            this.urlImagen = urlImagen;
        }//End constructor sobrecargado

        public String toString() {
            return "PagHome{ Id:"+this.idPagina+", descripcion:"+this.descripcionPagina+", urlImagen:"+this.urlImagen+"}";
        }//End toString

        public int IdPagina{
            get{
                return idPagina;
            }//End get
            set{
                idPagina = value;
            }//End set
        }//End dPagina

        public string DescripcionPagina{
            get{
                return descripcionPagina;
            }//End get
            set{
                descripcionPagina = value;
            }//End set
        }//End DescripcionPagina

        public string UrlImagen{
            get{
                return urlImagen;
            }//End get
            set{
                urlImagen = value;
            }//End set
        }//End UrlImagen

    }//End public class PagHome

}//End namespace SistemaHotel.Domain