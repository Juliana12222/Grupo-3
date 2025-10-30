using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace AppPruebaGrupo1Git.Datos
{
    public class ClConexion
    {
        SqlConnection oConex;

        public ClConexion()
        {
            oConex = new SqlConnection("");
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