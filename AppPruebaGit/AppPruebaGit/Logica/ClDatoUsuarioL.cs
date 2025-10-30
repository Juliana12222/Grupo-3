using appCursosP.Datos;
using appCursosP.Modelo;
using System.Web;

namespace AppPruebaGit.Logica
{
    public class ClDatoUsuarioL
    {

        public bool MtLogin(string usuario, string contraseña)
        {
            ClUsuarioD oUsuarioD = new ClUsuarioD();
            ClDatoUsuario oDatos = oUsuarioD.MtLogin(usuario, contraseña);

            bool ingreso = false;

            if (oDatos != null)
            {
                ingreso = true;
                HttpContext.Current.Session["email"] = oDatos.email;
                HttpContext.Current.Session["contraseña"] = oDatos.contraseña;
                HttpContext.Current.Session["idUsuario"] = oDatos.idUsuario;
                HttpContext.Current.Session["nombre"] = oDatos.nombre;
            }

            return ingreso;
        }
    }
}