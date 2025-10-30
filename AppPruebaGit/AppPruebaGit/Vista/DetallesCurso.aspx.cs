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
    public partial class DetallesCurso : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {


            if (!IsPostBack)
            {
                if (Request.QueryString["idCurso"] != null)
                {
                    int idCurso = int.Parse(Request.QueryString["idCurso"]);
                    cargarCurso(idCurso);
                }
            }
        }

        protected void cargarCurso(int idCurso)
        {
            ClUsuarioD oUsuarioD = new ClUsuarioD();
            ClCurso curso = oUsuarioD.MtCargarCursoD(idCurso);
            if (curso != null)
            {
                List<ClCurso> listaCursos = new List<ClCurso>() { curso }; ;
                PaginaDetalles.DataSource = listaCursos;
                PaginaDetalles.DataBind();
            }


        }

        protected void btnInscripcion_Command(object sender, CommandEventArgs e)
        {
            if (Session["idUsuario"] == null)
            {
                string script = "Swal.fire({ icon: 'warning', title: 'Inicia sesión', text: 'Debes iniciar sesión para inscribirte en un curso.', confirmButtonColor: '#007BFF' });";
                ClientScript.RegisterStartupScript(this.GetType(), "alertaSesion", script, true);
                return;
            }
            int idUsuario = int.Parse(Session["idUsuario"].ToString());
            int idCurso = int.Parse(e.CommandArgument.ToString());

            ClUsuarioD oUsuarioD = new ClUsuarioD();

            bool inscripcion = oUsuarioD.MtInscribirCurso(idUsuario, idCurso);

            if (inscripcion)
            {
                ClientScript.RegisterStartupScript(this.GetType(), "inscripcionCurso",
                "Swal.fire({ icon: 'success', title: 'Inscrito...', text: 'Te has inscrito correctamente en el curso, Bienvenido...', confirmButtonText: 'Aceptar',confirmButtonColor: '#007BFF' });",
           true);
            }
            else
            {
                ClientScript.RegisterStartupScript(this.GetType(), "alertaInscrito",
                "Swal.fire({ icon: 'warning', title: 'Inscripcion No Valida', text: 'Solo puede Inscribirse una Vez a un Curso', confirmButtonText: 'Aceptar',confirmButtonColor: '#007BFF' });",
                true);
            }
        }
    }
}