using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Data;


namespace SistemaHotel.Models {
    public class ReservaModel {
        private String connString;

        public ReservaModel(String connString) {
            this.connString = connString;
        }//Fin del constructor.

        public bool RealizarReserva(string nombreReserva, string apellidoReserva, string correoReserva, string tarjetaReserva) {
            SqlConnection connection = new SqlConnection(this.connString);
            String sqlStoredProcedure = "sp_realizarReserva";
            SqlCommand cmdInsertar = new SqlCommand(sqlStoredProcedure, connection);
            cmdInsertar.CommandType = System.Data.CommandType.StoredProcedure;
            cmdInsertar.Parameters.Add(new SqlParameter("@nombre", nombreReserva));
            cmdInsertar.Parameters.Add(new SqlParameter("@apellidos", apellidoReserva));
            cmdInsertar.Parameters.Add(new SqlParameter("@correo", correoReserva));
            cmdInsertar.Parameters.Add(new SqlParameter("@tarjeta", tarjetaReserva));
            
            cmdInsertar.Connection.Open();
            bool res = Convert.ToBoolean(cmdInsertar.ExecuteNonQuery());
            cmdInsertar.Connection.Close();

            return res;
        }

        public List<string> obtenerDatosHabitacion(int idHabitacion) {
            SqlConnection connection = new SqlConnection(this.connString);
            String sqlSelect = "sp_Obtener_Datos_Habitacion";
            SqlDataAdapter sqlDataAdapterClient = new SqlDataAdapter();
            sqlDataAdapterClient.SelectCommand = new SqlCommand(sqlSelect, connection);
            sqlDataAdapterClient.SelectCommand.CommandType = System.Data.CommandType.StoredProcedure;
            sqlDataAdapterClient.SelectCommand.Parameters.Add(new SqlParameter("@id", idHabitacion));

            DataSet dataSetPersonas = new DataSet();
            sqlDataAdapterClient.Fill(dataSetPersonas, "TSH_Habitacion");
            sqlDataAdapterClient.SelectCommand.Connection.Close();

            DataRowCollection dataRow = dataSetPersonas.Tables["TSH_Habitacion"].Rows;
            List<string> habitacion = new List<string>();

            foreach (DataRow currentRow in dataRow) {
                string numeroHab = currentRow["TN_Numero_Habitacion_TSH_Habitacion"].ToString();
                string descripcion = currentRow["TC_Descripcion_TSH_Habitacion"].ToString(); ;
                string imagen = currentRow["TI_Imagen_TSH_Habitacion"].ToString(); ;
                string tarifa = currentRow["TN_Tarifa_TSH_Tipo_Habitacion"].ToString(); ;                

                habitacion.Add(numeroHab);               
                habitacion.Add(descripcion);
                habitacion.Add(imagen);
                habitacion.Add(tarifa);                

            }//foreach
            return habitacion;
        }//obternerEstudiantes
    }
}