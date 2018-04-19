using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Data;


namespace SistemaHotel.Models
{
    public class ReservaModel
    {
        private String connString;

        public ReservaModel(String connString)
        {
            this.connString = connString;
        }//Fin del constructor.

        public bool RealizarReserva(string nombreReserva, string apellidoReserva, string correoReserva, string tarjetaReserva)
        {
            SqlConnection connection = new SqlConnection(this.connString);
            String sqlStoredProcedure = "sp_realizarReserva";
            SqlCommand cmdInsertar = new SqlCommand(sqlStoredProcedure, connection);
            cmdInsertar.CommandType = System.Data.CommandType.StoredProcedure;
            cmdInsertar.Parameters.Add(new SqlParameter("@nombre", nombreReserva));
            cmdInsertar.Parameters.Add(new SqlParameter("@apellidos", apellidoReserva));
            cmdInsertar.Parameters.Add(new SqlParameter("@correo", correoReserva));
            cmdInsertar.Parameters.Add(new SqlParameter("@tarjeta", tarjetaReserva));
            //cmdInsertar.Parameters.Add(new SqlParameter("@encargado ", estudiante.Encargado));
            cmdInsertar.Connection.Open();
            cmdInsertar.ExecuteNonQuery();
            cmdInsertar.Connection.Close();

            return true;
        }
    }
}