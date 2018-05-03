using SistemaHotel.Domain;
using System;
using System.Data;
using System.Data.SqlClient;

namespace SistemaHotel.Models
{
    public class AdminSNosotrosModel
    {
        private String connString;

        public AdminSNosotrosModel(String connString)
        {
            this.connString = connString;
        }//constructor.

        public AdminSNosotrosPag obtenerDatosSobreNosotros()
        {
            SqlConnection connection = new SqlConnection(this.connString);
            String sqlSelect = "PA_ObtenerDatosSobreNosotros";
            SqlDataAdapter sqlDataAdapterClient = new SqlDataAdapter();
            sqlDataAdapterClient.SelectCommand = new SqlCommand(sqlSelect, connection);

            DataSet dataSetPersonas = new DataSet();
            sqlDataAdapterClient.Fill(dataSetPersonas, "TSH_Pagina");
            sqlDataAdapterClient.SelectCommand.Connection.Close();

            DataRowCollection dataRow = dataSetPersonas.Tables["TSH_Pagina"].Rows;

            int idPag = 0;
            string descripcion = "";
            string urlImagen = "";

            foreach (DataRow currentRow in dataRow)
            {
                if (int.Parse(currentRow["TN_Identificador_TSH_Pagina"].ToString()) == 6)
                {
                    idPag = int.Parse(currentRow["TN_Identificador_TSH_Pagina"].ToString());
                    descripcion = currentRow["TC_Descripcion_TSH_Tipo_Habitacion"].ToString();
                    urlImagen = currentRow["TI_Imagen_TSH_Pag_Home"].ToString();
                }
                
            }//End foreach (DataRow currentRow in dataRow) 

            AdminSNosotrosPag info = new AdminSNosotrosPag(idPag, descripcion, urlImagen);

            return info;
        }// obtenerDatosSobreNosotros

        public bool actualizaDatosSobreNosotro(AdminSNosotrosPag adminSNosotrosPag)
        {
            SqlConnection connection = new SqlConnection(this.connString);
            String sqlStoredProcedure = "PA_ActualizarSobreNosotros";
            SqlCommand cmdActualizar = new SqlCommand(sqlStoredProcedure, connection);
            cmdActualizar.CommandType = System.Data.CommandType.StoredProcedure;
            cmdActualizar.Parameters.Add(new SqlParameter("@idPag", adminSNosotrosPag.IdPagina));
            cmdActualizar.Parameters.Add(new SqlParameter("@descripcion", adminSNosotrosPag.DescripcionPagina));
            cmdActualizar.Parameters.Add(new SqlParameter("@imagen", adminSNosotrosPag.UrlImagen));
            cmdActualizar.Connection.Open();
            bool res = Convert.ToBoolean(cmdActualizar.ExecuteNonQuery());
            cmdActualizar.Connection.Close();
            return res;
        }//actualizaDatosSobreNosotro

    }//class
}//namespace
