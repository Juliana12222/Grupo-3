using appCursosP.Datos;
using appCursosP.Logica;
using appCursosP.Modelo;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace appCursosP.Vista
{
    public partial class PrincipalPage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            if (!IsPostBack)
            {
                LblNombreUsuario.Visible = false;
                BtnCursosInscrito.Visible = false;
                CargarCarrusel();
                CargarCursos();
            }

        }

        protected void CargarCarrusel()
        {
            ClUsuarioD imagenes = new ClUsuarioD();
            List<ClPublicidad> ListaImagenes = imagenes.MtTraerImagenes();

            if (ListaImagenes.Count >= 3)
            {
                img1.ImageUrl = ListaImagenes[0].imgPublicidad;
                Img2.ImageUrl = ListaImagenes[1].imgPublicidad;
                Img3.ImageUrl = ListaImagenes[2].imgPublicidad;
            }
        }

        protected void CargarCursos()
        {
            ClUsuarioD objCursoD = new ClUsuarioD();
            List<ClCurso> listaCursos = objCursoD.MtCargarCursos();
            RptCursos.DataSource = listaCursos;
            RptCursos.DataBind();

        }
        protected void btnIngreso_Click(object sender, EventArgs e)
        {
            string usuario = txtUsuario.Text;
            string contraseña = txtContraseña.Text;

            ClDatoUsuarioL oUsuarioL = new ClDatoUsuarioL();
            bool login = oUsuarioL.MtLogin(usuario, contraseña);


            if (login)
            {
                lblMensaje.Text = "Bienvenido";
                btnLogin.Visible = false;
                btnRegistrarse.Visible = false;
                LblNombreUsuario.Visible = true;
                BtnCursosInscrito.Visible = true;
                if (Session["nombre"] != null)
                {
                    LblNombreUsuario.Text = "Bienvenido, " + Session["nombre"].ToString();
                }
                string script = @"Swal.fire({
                icon: 'success',
                title: 'Sesión iniciada correctamente',
                showConfirmButton: false,
                timer: 1000
                }).then(() => {
                var modal = bootstrap.Modal.getInstance(document.getElementById('login'));
                if (modal) modal.hide();
});";
                ScriptManager.RegisterStartupScript(this, GetType(), "LoginExitoso", script, true);


            }
            else
            {
                string script = @"Swal.fire({
                icon: 'error',
                title: 'Usuario o contraseña incorrectos',
                text: 'Usuario o Contraseña INCORRECTOS',
                confirmButtonText: 'Aceptar',
                confirmButtonColor: '#007BFF'
                }).then(() => {
                var modal = new bootstrap.Modal(document.getElementById('login'));
                modal.show();});";
                ScriptManager.RegisterStartupScript(this, GetType(), "LoginFallido", script, true);
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
            int contraseña = int.Parse(e.CommandArgument.ToString());

            ClUsuarioD oUsuarioD = new ClUsuarioD();

            bool inscripcion = oUsuarioD.MtInscribirCurso(idUsuario, contraseña);



            if (inscripcion)
            {
                ClientScript.RegisterStartupScript(this.GetType(), "inscripcionCurso",
                "Swal.fire({ icon: 'success', title: 'Inscrito...', text: 'Inscrito Correctamente, Bienvenido..', confirmButtonText: 'Aceptar',confirmButtonColor: '#007BFF' });",
                true);
            }
            else
            {
                ClientScript.RegisterStartupScript(this.GetType(), "alertaInscrito",
                "Swal.fire({ icon: 'warning', title: 'Inscripcion No Valida', text: 'Solo puede Inscribirse una Vez a un Curso', confirmButtonText: 'Aceptar',confirmButtonColor: '#007BFF' });",
                true);
            }
        }

        protected void btnDescripcion_Command(object sender, CommandEventArgs e)
        {
            int idUsuario = int.Parse(Session["idUsuario"].ToString());
            int contraseña = int.Parse(e.CommandArgument.ToString());

            ClUsuarioD oUsuarioD = new ClUsuarioD();

            bool inscripcion = oUsuarioD.MtInscribirCurso(idUsuario, contraseña);

            if (inscripcion)
            {
                ClientScript.RegisterStartupScript(this.GetType(), "incripcionCurso",
                "Swal.fire({ icon: 'success', title: 'Inscrito...', text: 'Inscrito Correctamente, Bienvenido..', confirmButtonText: 'Aceptar',confirmButtonColor: '#007BFF' });",
                true);
            }
        }

        protected void btnRegistro_Click(object sender, EventArgs e)
        {
            ClDatoUsuario NuevoRegistro = new ClDatoUsuario();
            NuevoRegistro.nombre = txtNombre.Text;
            NuevoRegistro.apellido = txtApellido.Text;
            NuevoRegistro.telefono = txtTelefono.Text;
            NuevoRegistro.email = txtEmail.Text;
            NuevoRegistro.direccion = txtDireccion.Text;
            NuevoRegistro.contraseña = txtContraseñaR.Text;

            ClUsuarioD oUsuarioD = new ClUsuarioD();
            bool registrado = oUsuarioD.MtRegistrarUsuario(NuevoRegistro);

            lblMensaje2.Text = "Registrado Satisfactoriamente";

            if (registrado)
            {

                ClientScript.RegisterStartupScript(this.GetType(), "Registrado",
                "Swal.fire({ icon: 'success', title: 'Registrado', text: 'Se ha Registrado Correctamente, Bienvenido....', confirmButtonText: 'Aceptar',confirmButtonColor: '#007BFF' });", true);
            }
        }
        protected void BtnCursosInscrito_Click(object sender, EventArgs e)
        {
            Response.Redirect("CursosInscrito.aspx");
        }


    }


}
