using appCursosP.Modelo;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace appCursosP.Datos
{
    public class ClUsuarioD
    {
        public ClDatoUsuario MtLogin(string user, string pass)
        {
            ClConexion oConexion = new ClConexion();
            ClDatoUsuario oDatosUser = null;

            string consulta = $"select datoUsuario.*, estado.*, rol.*, curso.* from datoUsuario inner join rol on datoUsuario.idRol = rol.idRol left join estadoCurso on datoUsuario.idUsuario = estadoCurso.idUsuario left join estado on estadoCurso.idEstado = estado.idEstado left join curso on estadoCurso.idCurso = curso.idCurso where email = '{user}' and contraseña = '{pass}'";

            SqlDataAdapter adaptadorBD = new SqlDataAdapter(consulta, oConexion.MtAbrirConexion());

            DataTable tablaDatos = new DataTable();
            adaptadorBD.Fill(tablaDatos);

            if (tablaDatos.Rows.Count > 0)
            {
                oDatosUser = new ClDatoUsuario();
                oDatosUser.idUsuario = int.Parse(tablaDatos.Rows[0]["idUsuario"].ToString());
                oDatosUser.nombre = tablaDatos.Rows[0]["nombre"].ToString();
                oDatosUser.apellido = tablaDatos.Rows[0]["apellido"].ToString();
                oDatosUser.telefono = tablaDatos.Rows[0]["telefono"].ToString();
                oDatosUser.email = tablaDatos.Rows[0]["email"].ToString();
                oDatosUser.direccion = tablaDatos.Rows[0]["direccion"].ToString();
                oDatosUser.contraseña = tablaDatos.Rows[0]["contraseña"].ToString();
                oDatosUser.idRol = int.Parse(tablaDatos.Rows[0]["idRol"].ToString());
                oDatosUser.nombreRol = tablaDatos.Rows[0]["nombreRol"].ToString();

                oDatosUser.listaCursos = new List<ClEstadoCurso>();

                foreach (DataRow recorrerCurso in tablaDatos.Rows)
                {
                    if (recorrerCurso["idCurso"] == DBNull.Value)
                        continue;
                    ClCurso curso = new ClCurso();



                    curso.idCurso = int.Parse(recorrerCurso["idCurso"].ToString());
                    curso.nombreCurso = recorrerCurso["nombreCurso"].ToString();
                    curso.descripcion = recorrerCurso["descripcion"].ToString();
                    curso.precio = decimal.Parse(recorrerCurso["precio"].ToString());
                    curso.tiempo = recorrerCurso["tiempo"].ToString();


                    ClEstado estado = new ClEstado();

                    estado.idEstado = int.Parse(recorrerCurso["idEstado"].ToString());
                    estado.estado = recorrerCurso["estado"].ToString();


                    ClEstadoCurso estadoCurso = new ClEstadoCurso();
                    estadoCurso.idCurso = int.Parse(recorrerCurso["idCurso"].ToString());
                    estadoCurso.idEstado = int.Parse(recorrerCurso["idEstado"].ToString());
                    estadoCurso.idUsuario = int.Parse(recorrerCurso["idUsuario"].ToString());

                    oDatosUser.listaCursos.Add(estadoCurso);

                }


            }
            return oDatosUser;

        }
        public List<ClPublicidad> MtTraerImagenes()
        {
            ClConexion oConexion = new ClConexion();
            List<ClPublicidad> listaImagenes = new List<ClPublicidad>();

            string consulta = $"select * from publicidad";

            SqlDataAdapter adaptadorBD2 = new SqlDataAdapter(consulta, oConexion.MtAbrirConexion());

            DataTable tablaImagenes = new DataTable();
            adaptadorBD2.Fill(tablaImagenes);

            foreach (DataRow recorrer in tablaImagenes.Rows)
            {
                ClPublicidad oDatosUser = new ClPublicidad();
                oDatosUser.idPublicidad = int.Parse(recorrer["idPublicidad"].ToString());
                oDatosUser.imgPublicidad = recorrer["imgPublicidad"].ToString();

                listaImagenes.Add(oDatosUser);

            }
            return listaImagenes;
        }
        public List<ClCurso> MtCargarCursos()
        {
            ClConexion oConexion = new ClConexion();
            List<ClCurso> listaCursos = new List<ClCurso>();

            string consulta = $"select * from curso";

            SqlDataAdapter adaptadorBD3 = new SqlDataAdapter(consulta, oConexion.MtAbrirConexion());

            DataTable tablaCursos = new DataTable();
            adaptadorBD3.Fill(tablaCursos);

            foreach (DataRow recorrer in tablaCursos.Rows)
            {
                ClCurso oCursos = new ClCurso();
                oCursos.idCurso = int.Parse(recorrer["idCurso"].ToString());
                oCursos.nombreCurso = recorrer["nombreCurso"].ToString();
                oCursos.descripcion = recorrer["descripcion"].ToString();
                oCursos.precio = decimal.Parse(recorrer["precio"].ToString());
                oCursos.tiempo = recorrer["tiempo"].ToString();
                oCursos.imgCurso = recorrer["imgCurso"].ToString();

                listaCursos.Add(oCursos);

            }
            return listaCursos;

        }
        public List<ClCurso> MtCargarCursosInscrito(int idUsuario)
        {
            ClConexion oConexion = new ClConexion();
            List<ClCurso> listaCursos = new List<ClCurso>();

            string consulta = @"select curso.* from curso  inner join estadoCurso  on curso.idCurso = estadoCurso.idCurso where estadoCurso.idUsuario = @idUsuario";

            SqlDataAdapter adaptadorBD5 = new SqlDataAdapter(consulta, oConexion.MtAbrirConexion());
            adaptadorBD5.SelectCommand.Parameters.AddWithValue("idUsuario", idUsuario);

            DataTable tablaCursos = new DataTable();
            adaptadorBD5.Fill(tablaCursos);

            foreach (DataRow recorrer in tablaCursos.Rows)
            {
                ClCurso oCursos = new ClCurso();
                oCursos.idCurso = int.Parse(recorrer["idCurso"].ToString());
                oCursos.nombreCurso = recorrer["nombreCurso"].ToString();
                oCursos.descripcion = recorrer["descripcion"].ToString();
                oCursos.precio = decimal.Parse(recorrer["precio"].ToString());
                oCursos.tiempo = recorrer["tiempo"].ToString();
                oCursos.imgCurso = recorrer["imgCurso"].ToString();

                listaCursos.Add(oCursos);

            }
            return listaCursos;

        }

        public bool MtInscribirCurso(int idUsuario, int idCurso)
        {
            ClConexion oConexion = new ClConexion();
            SqlConnection conexion = oConexion.MtAbrirConexion();

            string verificadorCursos = $"select count(*) from estadoCurso where idUsuario = @idUsuario and idCurso=@idCurso";
            SqlCommand verificaCurso = new SqlCommand(verificadorCursos, conexion);
            verificaCurso.Parameters.AddWithValue("@idUsuario", idUsuario);
            verificaCurso.Parameters.AddWithValue("@idCurso", idCurso);
            int max = (int)verificaCurso.ExecuteScalar();
            if (max >0 )
            {
                return false;
            }


            string consulta2 = $"insert into estadoCurso (idCurso,idEstado,idUsuario) values ({idCurso},1,{idUsuario})";
            SqlCommand inscribir = new SqlCommand(consulta2, conexion);
            inscribir.Parameters.AddWithValue("@idUsuario", idUsuario);
            inscribir.Parameters.AddWithValue("@idCurso", idCurso);
            int inscribirDato = inscribir.ExecuteNonQuery();
             return inscribirDato > 0;


        }

        public ClCurso MtCargarCursoD (int idCurso)
        {
            ClConexion oConexion = new ClConexion ();
            ClCurso oCurso = null;

            string consulta = $"select curso.*, estado.*,datoUsuario.* from curso left join estadoCurso on curso.idCurso = estadoCurso.idCurso left join estado on estadoCurso.idEstado = estado.idEstado left join datoUsuario on estadoCurso.idUsuario = datoUsuario.idUsuario where curso.idCurso  = {idCurso} ";

            SqlDataAdapter adaptadorBD4 = new SqlDataAdapter(consulta, oConexion.MtAbrirConexion());

            DataTable tablaCursos = new DataTable();
            adaptadorBD4.Fill(tablaCursos);

            if (tablaCursos.Rows.Count > 0)
            {
                oCurso = new ClCurso();

                oCurso.idCurso = int.Parse(tablaCursos.Rows[0]["idCurso"].ToString());
                oCurso.nombreCurso = tablaCursos.Rows[0]["nombreCurso"].ToString();
                oCurso.descripcion = tablaCursos.Rows[0]["descripcion"].ToString();
                oCurso.precio = decimal.Parse(tablaCursos.Rows[0]["precio"].ToString());
                oCurso.tiempo = tablaCursos.Rows[0]["tiempo"].ToString();
                oCurso.imgCurso = tablaCursos.Rows[0]["imgCurso"].ToString();

                oCurso.listaCursos = new List<ClEstadoCurso>();

                foreach (DataRow listas  in tablaCursos.Rows)
                {
                    if (listas["idEstado"] == DBNull.Value || listas["idUsuario"] == DBNull.Value)
                        continue;

                    ClEstado estado = new ClEstado();
                    estado.idEstado = int.Parse(listas["idEstado"].ToString());
                    estado.estado = listas["estado"].ToString();

                    ClEstadoCurso estadoCurso = new ClEstadoCurso();
                    estadoCurso.idCurso = oCurso.idCurso;
                    estadoCurso.idEstado = estado.idEstado;
                    estadoCurso.idUsuario = int.Parse(listas["idUsuario"].ToString());

                    oCurso.listaCursos.Add(estadoCurso);
                }
            }
            return oCurso;
        }
        public bool MtRegistrarUsuario(ClDatoUsuario registrarUsuario)
        {
            ClConexion oConexion = new ClConexion();
            SqlConnection conexion = oConexion.MtAbrirConexion();

            string consulta = $"insert into datoUsuario (nombre,apellido,telefono,email,direccion,contraseña,idRol)  values (@nombre,@apellido,@telefono,@correo,@direccion,@contraseña,1)";

            SqlCommand insertarDato = new SqlCommand(consulta, conexion);
            insertarDato.Parameters.AddWithValue("@nombre", registrarUsuario.nombre);
            insertarDato.Parameters.AddWithValue("@apellido", registrarUsuario.apellido);
            insertarDato.Parameters.AddWithValue("@telefono", registrarUsuario.telefono);
            insertarDato.Parameters.AddWithValue("@correo", registrarUsuario.email);
            insertarDato.Parameters.AddWithValue("@direccion", registrarUsuario.direccion);
            insertarDato.Parameters.AddWithValue("@contraseña", registrarUsuario.contraseña);
            insertarDato.Parameters.AddWithValue("@idRol", registrarUsuario.idRol);

            int insertar = insertarDato.ExecuteNonQuery();

            return insertar > 0;


        }
    }
}