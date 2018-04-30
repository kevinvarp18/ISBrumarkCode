using SistemaHotel.Domain;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace SistemaHotel.Models{
    public class PaginaHomeModel{
        //Atributos
        private String connString;

        public PaginaHomeModel(String connString){
            this.connString = connString;
        }//End del constructor.

        public PagHome obtenerDatosIndex() {
            SqlConnection connection = new SqlConnection(this.connString);
            String sqlSelect = "PA_ObtenerDatosIndex";
            SqlDataAdapter sqlDataAdapterClient = new SqlDataAdapter();
            sqlDataAdapterClient.SelectCommand = new SqlCommand(sqlSelect, connection);

            DataSet dataSetPersonas = new DataSet();
            sqlDataAdapterClient.Fill(dataSetPersonas, "TSH_Pagina");
            sqlDataAdapterClient.SelectCommand.Connection.Close();

            DataRowCollection dataRow = dataSetPersonas.Tables["TSH_Pagina"].Rows;

            int idPag = 0;
            string descripcion = "";
            string urlImagen = "";

            foreach (DataRow currentRow in dataRow) { 
                idPag = int.Parse(currentRow["TN_Identificador_TSH_Pagina"].ToString());
                descripcion = currentRow["TC_Descripcion_TSH_Tipo_Habitacion"].ToString();
                urlImagen = currentRow["TI_Imagen_TSH_Pag_Home"].ToString();
            }//End foreach (DataRow currentRow in dataRow) 

            PagHome home = new PagHome(idPag,descripcion,urlImagen);
                        
            return home;
        }//End obtenerDatosIndex

        public bool actualizaDatosIndex(PagHome pagHome) { 
            SqlConnection connection = new SqlConnection(this.connString);
            String sqlStoredProcedure = "PA_ActualizaPagHome";
            SqlCommand cmdInsertar = new SqlCommand(sqlStoredProcedure, connection);
            cmdInsertar.CommandType = System.Data.CommandType.StoredProcedure;
            cmdInsertar.Parameters.Add(new SqlParameter("@idPag", pagHome.IdPagina));
            cmdInsertar.Parameters.Add(new SqlParameter("@descripcion", pagHome.DescripcionPagina));
            cmdInsertar.Parameters.Add(new SqlParameter("@imagen", pagHome.UrlImagen));
            cmdInsertar.Connection.Open();
            bool res = Convert.ToBoolean(cmdInsertar.ExecuteNonQuery());
            cmdInsertar.Connection.Close();
            return res;
        }//End actualizaDatosIndex

    }//End class PaginaHomeModel

}//End namespace SistemaHotel.Models