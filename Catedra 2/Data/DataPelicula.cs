using Catedra_2.Models;
using System.Data.SqlClient;
using System.Data;
using NuGet.Protocol.Plugins;

namespace Catedra_2.Data
{
    public class DataPelicula
    {
        public List<ModeloPelicula> Shown()
        {
            // En este objeto hacemos una instancia a la lista creada
            var ObjList = new List<ModeloPelicula>();

            // Instanciamos un objeto para la  cadena de conexión con la base de datos:
            var cn = new Conexion();
            // Mandamos a llamar el método que contiene el fragmento tomado del appseting con la información de la conexión
            using (var connect = new SqlConnection(cn.getConnectSQL()))
            {
                // Abrimos la conexión
                connect.Open();

                // TODO: Estruncturas de los comandos de SQL =>
                SqlCommand GetMovies = new SqlCommand("ListarPeliculas", connect);
                GetMovies.CommandType = CommandType.StoredProcedure;

                // Vamos a leer los datos que provienen de
                using (var rd = GetMovies.ExecuteReader())
                {
                    // Con el método Read vamos a recolectar cada uno de los datos que están en la consulta
                    while (rd.Read())
                    {
                        // Los datos se agregan a la lista creada como un objeto en la línea 17
                        ObjList.Add(new ModeloPelicula()
                        {
                            /*
                             * Accedemos a los atributos del modelo,
                             * el objeto rd necesita del nombre del campo en la base
                             * dado que estamos llamando una vista, será el nombre de los ALIAS
                             */
                            ID_Pelicula = Convert.ToInt32(rd["ID_Pelicula"]),
                            Poster = rd["Poster"].ToString(),
                            Titulo = rd["Titulo"].ToString(),
                            Sinopsis = rd["Descripcion"].ToString(),
                            Director = rd["Director"].ToString(),
                            Genero = rd["Genero"].ToString(),
                            Fecha_Estreno = rd["Fecha Estreno"].ToString()
                        });
                    }
                }
            }
            return ObjList;
        }

        // Metodo para traer por ID
        public ModeloPelicula GetDataInfo(int IdPelicula)
        {
            // Creamos un objeto para acceder a la clase del Modelo de datos
            var ObjList = new ModeloPelicula();

            // Instancimos un objeto para la  cadena de conexión con la base de datos:
            var cn = new Conexion();
            // Mandamos a llamar el método que contiene el fragmento tomado del appseting con la información de la conexión
            using (var connect = new SqlConnection(cn.getConnectSQL()))
            {
                // Abrimos la conexión
                connect.Open();

                // TODO: Estruncturas de los comandos de SQL =>
                SqlCommand GetEmployeeById = new SqlCommand("GetPeliByID", connect);
                // Enviamos el parámetro que recibimos en la función al parámetro del Procedimiento
                GetEmployeeById.Parameters.AddWithValue("@ID_Pelicula", IdPelicula);
                GetEmployeeById.CommandType = CommandType.StoredProcedure;

                // Vamos a leer los datos que provienen de
                using (var rd = GetEmployeeById.ExecuteReader())
                {
                    // Con el método Read vamos a recolectar cada uno de los datos que están en la consulta
                    while (rd.Read())
                    {
                        ObjList.ID_Pelicula = Convert.ToInt32(rd["ID_Pelicula"]);
                        ObjList.Poster = rd["Poster"].ToString();
                        ObjList.Titulo = rd["Titulo"].ToString();
                        ObjList.Titulo = rd["Titulo"].ToString();
                        ObjList.Sinopsis = rd["fecha_nacimiento"].ToString();
                        ObjList.Director = rd["id_Puesto"].ToString();
                        ObjList.Genero = rd["id_Puesto"].ToString();
                        ObjList.Fecha_Estreno = rd["id_Puesto"].ToString();
                    }
                }
            }
            return ObjList;
        }

        // Metodo para guardar datos
        public bool SaveData(ModeloPelicula PeliReq)
        {
            bool response;
            try
            {
                // Instancimos un objeto para la  cadena de conexión con la base de datos:
                var cn = new Conexion();
                // Mandamos a llamar el método que contiene el fragmento tomado del appseting con la información de la conexión
                using (var connect = new SqlConnection(cn.getConnectSQL()))
                {
                    // Abrimos la conexión
                    connect.Open();

                    // TODO: Estruncturas de los comandos de SQL =>
                    SqlCommand InsertData = new SqlCommand("InsertaMovie", connect);
                    // Enviamos el parámetro que recibimos en la función al parámetro del Procedimiento
                    InsertData.Parameters.AddWithValue("@poster", PeliReq.Poster);
                    InsertData.Parameters.AddWithValue("@@titulo", PeliReq.Titulo);
                    InsertData.Parameters.AddWithValue("@@sinopsis", PeliReq.Sinopsis);
                    InsertData.Parameters.AddWithValue("@@director", PeliReq.Director);
                    InsertData.Parameters.AddWithValue("@@genero", PeliReq.Genero);
                    InsertData.Parameters.AddWithValue("@@fecha_estreno", PeliReq.Fecha_Estreno);
                    InsertData.CommandType = CommandType.StoredProcedure;
                    // Realizamos la ejecución de la consulta con los parámetros
                    InsertData.ExecuteNonQuery();
                }
                response = true;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error at: " + ex);
                response = false;
            }
            return response;
        }

        // Metodo para actualizar datos:
        public bool UpdateData(ModeloPelicula empReq)
        {
            bool response;
            try
            {
                // Instancimos un objeto para la  cadena de conexión con la base de datos:
                var cn = new Conexion();
                // Mandamos a llamar el método que contiene el fragmento tomado del appseting con la información de la conexión
                using (var connect = new SqlConnection(cn.getConnectSQL()))
                {
                    // Abrimos la conexión
                    connect.Open();

                    // TODO: Estruncturas de los comandos de SQL =>
                    SqlCommand UpdateData = new SqlCommand("spUpdateData", connect);
                    // Enviamos el parámetro que recibimos en la función al parámetro del Procedimiento
                    UpdateData.Parameters.AddWithValue("@ID_Empleado", empReq.ID_empleado);
                    UpdateData.Parameters.AddWithValue("@primer_nombre", empReq.FirstName);
                    UpdateData.Parameters.AddWithValue("@segundo_nombre", empReq.LastName);
                    UpdateData.Parameters.AddWithValue("@fecha_nacimiento", empReq.DateBirth);
                    UpdateData.Parameters.AddWithValue("@id_Puesto", empReq.Position);
                    UpdateData.Parameters.AddWithValue("@salario", empReq.Amount);
                    UpdateData.CommandType = CommandType.StoredProcedure;
                    // Realizamos la ejecución de la consulta con los parámetros
                    UpdateData.ExecuteNonQuery();
                }
                response = true;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error at: " + ex);
                response = false;
            }
            return response;
        }
    }
}
