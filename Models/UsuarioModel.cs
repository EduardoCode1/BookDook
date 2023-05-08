namespace BookDook.Models
{
    public class UsuarioModel
    {
        public DateTime Fecha_de_publicación { get; set; }
        public DateTime Fecha_de_creación { get; set; }
        public string Título_del_libro { get; set; }
        public string Autor { get; set; }
        public string Categoría { get; set; }
        public int NumPaginas { get; set; }
        public string País { get; set; }
        public string Idioma_original { get; set; }
    }
}
