using System.Collections.Generic;

namespace appCursosP.Modelo
{
    public class ClCurso
    {
        public int idCurso { get; set; }
        public string nombreCurso { get; set; }
        public string descripcion { get; set; }
        public decimal precio { get; set; }
        public string tiempo { get; set; }
        public string imgCurso {  get; set; }

        public List<ClEstadoCurso> listaCursos { get; set; }

    }
}