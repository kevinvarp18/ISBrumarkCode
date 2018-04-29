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

            foreach (DataRow currentRow in dataRow) { 
                idPag = int.Parse(currentRow["TN_Identificador_TSH_Pagina"].ToString());
                descripcion = currentRow["TC_Descripcion_TSH_Tipo_Habitacion"].ToString();
            }//End foreach (DataRow currentRow in dataRow) 

            PagHome home = new PagHome(idPag,descripcion,"");
                        
            return home;
        }//End obtenerDatosIndex

    }//End class PaginaHomeModel

}//End namespace SistemaHotel.Models