using System.Collections.Generic;

namespace appCursosP.Modelo
{
    public class ClDatoUsuario
    {
        public int idUsuario { get; set; }
        public string nombre { get; set; }
        public string apellido { get; set; }
        public string telefono { get; set; }
        public string email { get; set; }
        public string direccion { get; set; }
        public string contraseña { get; set; }
        public int idRol { get; set; }
        public string nombreRol { get; set; }
        public List<ClEstadoCurso> listaCursos { get; set; } = new List<ClEstadoCurso>();

    }
}