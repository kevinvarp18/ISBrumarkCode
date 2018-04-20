using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Data;
using SistemaHotel.Domain;

namespace SistemaHotel.Models
{
    public class ReservaModel
    {
        private String connString;

        public ReservaModel(String connString)
        {
            this.connString = connString;
        }//Fin del constructor.

        public bool RealizarReserva(string nombreReserva, string apellidoReserva, string correoReserva, string tarjetaReserva, int numero)
        {
            SqlConnection connection = new SqlConnection(this.connString);
            String sqlStoredProcedure = "sp_realizarReserva";
            SqlCommand cmdInsertar = new SqlCommand(sqlStoredProcedure, connection);
            cmdInsertar.CommandType = System.Data.CommandType.StoredProcedure;
            cmdInsertar.Parameters.Add(new SqlParameter("@nombre", nombreReserva));
            cmdInsertar.Parameters.Add(new SqlParameter("@apellidos", apellidoReserva));
            cmdInsertar.Parameters.Add(new SqlParameter("@correo", correoReserva));
            cmdInsertar.Parameters.Add(new SqlParameter("@tarjeta", tarjetaReserva));
            cmdInsertar.Parameters.Add(new SqlParameter("@numero", numero));
            cmdInsertar.Connection.Open();
            bool res = Convert.ToBoolean(cmdInsertar.ExecuteNonQuery());
            cmdInsertar.Connection.Close();
            return res;
        }//Fin de la funcion RealizarReserva.

        public List<string> obtenerDatosHabitacion(int idHabitacion)
        {
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

            foreach (DataRow currentRow in dataRow)
            {
                string numeroHab = currentRow["TN_Numero_Habitacion_TSH_Habitacion"].ToString();
                string descripcion = currentRow["TC_Descripcion_TSH_Habitacion"].ToString(); ;
                string imagen = currentRow["TI_Imagen_TSH_Habitacion"].ToString(); ;
                string tarifa = currentRow["TN_Tarifa_TSH_Tipo_Habitacion"].ToString(); ;

                habitacion.Add(numeroHab);
                habitacion.Add(descripcion);
                habitacion.Add(imagen);
                habitacion.Add(tarifa);
            }//Fin del foreach
            return habitacion;
        }//Fin de la funcion obtenerDatosHabitacion.

        public List<TipoHabitacion> obtenerTiposHabitacion()
        {
            SqlConnection connection = new SqlConnection(this.connString);
            String sqlSelect = "SP_ObtenerTipoHabitaciones";
            SqlDataAdapter sqlDataAdapterClient = new SqlDataAdapter();
            sqlDataAdapterClient.SelectCommand = new SqlCommand(sqlSelect, connection);
            sqlDataAdapterClient.SelectCommand.CommandType = System.Data.CommandType.StoredProcedure;

            DataSet dataSetPersonas = new DataSet();
            sqlDataAdapterClient.Fill(dataSetPersonas, "TSH_Tipo_Habitacion");
            sqlDataAdapterClient.SelectCommand.Connection.Close();

            DataRowCollection dataRow = dataSetPersonas.Tables["TSH_Tipo_Habitacion"].Rows;
            List<TipoHabitacion> tiposHabitaciones = new List<TipoHabitacion>();

            foreach (DataRow currentRow in dataRow)
            {
                TipoHabitacion tipoTemp = new TipoHabitacion();
                tipoTemp.Id = int.Parse(currentRow["TN_Identificador_TSH_Tipo_Habitacion"].ToString());
                tipoTemp.Descripcion = currentRow["TC_Descripcion_TSH_Tipo_Habitacion"].ToString(); ;
                tipoTemp.Tarifa = float.Parse(currentRow["TN_Tarifa_TSH_Tipo_Habitacion"].ToString()); ;
                tipoTemp.CantidadPersonas = int.Parse(currentRow["TN_Cantidad_Personas_TSH_Tipo_Habitacion"].ToString()); ;
                tiposHabitaciones.Add(tipoTemp);
            }//Fin del foreach
            return tiposHabitaciones;
        }//Fin de la funcion obtenerDatosHabitacion.

        public List<Habitacion> consultarDisponibilidad(int idTipoHabitacion)
        {
            SqlConnection connection = new SqlConnection(this.connString);
            String sqlSelect = "SP_ConsultarDisponibilidad";
            SqlDataAdapter sqlDataAdapterClient = new SqlDataAdapter();
            sqlDataAdapterClient.SelectCommand = new SqlCommand(sqlSelect, connection);
            sqlDataAdapterClient.SelectCommand.CommandType = System.Data.CommandType.StoredProcedure;
            sqlDataAdapterClient.SelectCommand.Parameters.Add(new SqlParameter("@idTipoHabitacion", idTipoHabitacion));

            DataSet dataSetPersonas = new DataSet();
            sqlDataAdapterClient.Fill(dataSetPersonas, "TSH_Habitacion");
            sqlDataAdapterClient.SelectCommand.Connection.Close();

            DataRowCollection dataRow = dataSetPersonas.Tables["TSH_Habitacion"].Rows;
            List<Habitacion> habitaciones = new List<Habitacion>();

            foreach (DataRow currentRow in dataRow)
            {
                Habitacion habitacionTemp = new Habitacion();
                habitacionTemp.Id = int.Parse(currentRow["TN_Identificador_TSH_Habitacion"].ToString());
                habitaciones.Add(habitacionTemp);
            }//Fin del foreach
            return habitaciones;
        }//Fin de la función consultarDisponibilidad.

    }//Fin de la clase ReservaModel.
}//Fin del namespace.