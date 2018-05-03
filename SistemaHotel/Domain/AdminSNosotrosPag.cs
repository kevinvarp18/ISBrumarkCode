using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SistemaHotel.Domain
{
    public class AdminSNosotrosPag
    {
        private int idPagina;
        private string descripcionPagina;
        private string urlImagen;


        public AdminSNosotrosPag(int idPagina, string descripcionPagina, string urlImagen)
        {
            this.idPagina = idPagina;
            this.descripcionPagina = descripcionPagina;
            this.urlImagen = urlImagen;
        }//constructor

        public AdminSNosotrosPag()
        {
            this.idPagina = 0;
            this.descripcionPagina = "";
            this.urlImagen = "";
        }//default 

        public int IdPagina
        {
            get
            {
                return idPagina;
            }//get
            set
            {
                idPagina = value;
            }//set
        }//dPagina

        public string DescripcionPagina
        {
            get
            {
                return descripcionPagina;
            }// get
            set
            {
                descripcionPagina = value;
            }//set
        }//DescripcionPagina

        public string UrlImagen
        {
            get
            {
                return urlImagen;
            }//End get
            set
            {
                urlImagen = value;
            }//End set
        }//End UrlImagen


        public String toString()
        {
            return "AdminSNosotrosPag{ Id:" + this.idPagina + ", descripcion:" + this.descripcionPagina + ", urlImagen:" + this.urlImagen + "}";
        }//toString


    }//class



}//name space