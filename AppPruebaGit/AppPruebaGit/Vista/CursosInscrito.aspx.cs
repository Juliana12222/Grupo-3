using appCursosP.Datos;
using appCursosP.Modelo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace appCursosP.Vista
{
    public partial class CursosInscrito : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["idUsuario"] != null)
            {
                int idUsuario = (int)Session["idUsuario"];
                CargarCursosInscrito(idUsuario);
            }
        }
        protected void CargarCursosInscrito(int idUsuario)
        {
            ClUsuarioD objUsuarioD = new ClUsuarioD();
            List<ClCurso> listaCursos = objUsuarioD.MtCargarCursosInscrito(idUsuario);

            RptCursosInscrito.DataSource = listaCursos;
            RptCursosInscrito.DataBind();
        }




    }
}