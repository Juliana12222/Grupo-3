using System.Data.SqlClient;

namespace AppPruebaGrupo1Git.Datos
{
    public class ClConexion
    {
        SqlConnection oConex;

        public ClConexion()
        {
            oConex = new SqlConnection("Data Source=.;Initial Catalog=Trabajo;Integrated Security=True;Encrypt=True;Trust Server Certificate=True");
        }
        public SqlConnection MtAbrirConexiom()
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