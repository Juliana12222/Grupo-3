using System.Data.SqlClient;

namespace appCursosP.Datos
{
    public class ClConexion
    {
        SqlConnection oConex;

        public ClConexion()
        {
            oConex = new SqlConnection("Data Source=.;Initial Catalog=bdCursos;Integrated Security=True;");
        }

        public SqlConnection MtAbrirConexion()
        {
            oConex.Open();
            return oConex;
        }

        public void MtCerrarConexion()
        {
            oConex.Close();
        }


    }
}