namespace appCursosP.Modelo
{
    public class ClEstadoCurso
    {
        public int idEstadoCurso { get; set; }
        public int idCurso { get; set; }
        public int idEstado { get; set; }
        public int idUsuario { get; set; }

        public ClCurso curso { get; set; }
        public ClEstado estado { get; set; }

    }
}