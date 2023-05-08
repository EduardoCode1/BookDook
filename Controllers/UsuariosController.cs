using BookDook.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing.Constraints;
using System.Data;
using System.Data.SqlClient;

namespace BookDook.Controllers
{
    public class UsuariosController : Controller
    {
        public IActionResult Registros_libros()
        {
            using (SqlConnection con = new SqlConnection(Configuration["ConnectionStrings:conexion"]))

            {
                using (SqlCommand cmd = new SqlCommand("sp_libros_registrados", con))
                {
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    con.Open();
                    SqlDataAdapter da = new(cmd);
                    DataTable dt = new();
                    da.Fill(dt); da.Dispose();
                    List<UsuarioModel> lista = new();

                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        lista.Add(new UsuarioModel()
                        {
                            Fecha_de_publicación = Convert.ToDateTime(dt.Rows[i][0]),
                            Fecha_de_creación = Convert.ToDateTime(dt.Rows[i][1]),
                            Título_del_libro = dt.Rows[i][2].ToString(),
                            Autor = dt.Rows[i][3].ToString(),
                            Categoría = dt.Rows[i][4].ToString(),
                            NumPaginas = Convert.ToInt32(dt.Rows[i][5]),
                            País = dt.Rows[i][6].ToString(),
                            Idioma_original = dt.Rows[i][7].ToString()



                        });
                    }
                    ViewBag.libros = lista;
                    con.Close();
                }
                return View();
            }
        }

        public IConfiguration Configuration { get; }

        public UsuariosController(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IActionResult Registrar()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Registrar(UsuarioModel libros)
        {
            using (SqlConnection con = new SqlConnection(Configuration["ConnectionStrings:conexion"]))
            {
                using (SqlCommand cmd = new SqlCommand("sp_registrar", con))
                {
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.Parameters.Add("@Fecha_de_publicación", System.Data.SqlDbType.Date).Value = libros.Fecha_de_publicación.Date;
                    cmd.Parameters.Add("@Fecha_de_creación", System.Data.SqlDbType.Date).Value = libros.Fecha_de_creación.Date;
                    cmd.Parameters.Add("@Título_del_libro", System.Data.SqlDbType.VarChar).Value = libros.Título_del_libro;
                    cmd.Parameters.Add("@Autor", System.Data.SqlDbType.VarChar).Value = libros.Autor;
                    cmd.Parameters.Add("@Categoría", System.Data.SqlDbType.VarChar).Value = libros.Categoría;
                    cmd.Parameters.Add("@NumPaginas", System.Data.SqlDbType.Int).Value = libros.NumPaginas;
                    cmd.Parameters.Add("@País", System.Data.SqlDbType.VarChar).Value = libros.País;
                    cmd.Parameters.Add("@Idioma_original", System.Data.SqlDbType.VarChar).Value = libros.Idioma_original;
                    con.Open();
                    cmd.ExecuteNonQuery();
                    con.Close();
                }
            }
            return Redirect("Registros_libros");
        }
    }
}
