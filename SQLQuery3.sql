Create database REGISTROS_LIBROS_MVC

use REGISTROS_LIBROS_MVC
create table Libros(
 Fecha_de_publicación DATE,
 Fecha_de_creación DATE,
    Título_del_libro VARCHAR(50),
    Autor VARCHAR(50),
    Categoría VARCHAR(50),
    NumPaginas INT,
    País VARCHAR(50),
    Idioma_original VARCHAR(50)
    )

    CREATE PROCEDURE sp_registrar
    @Fecha_de_publicación DATE,
    @Fecha_de_creación DATE,
    @Título_del_libro VARCHAR(50),
    @Autor VARCHAR(50),
    @Categoría VARCHAR(50),
    @NumPaginas INT,
    @País VARCHAR(50),
    @Idioma_original VARCHAR(50)
AS 
BEGIN
    INSERT INTO Libros 
    VALUES (@Fecha_de_publicación, @Fecha_de_creación, @Título_del_libro, @Autor, @Categoría, @NumPaginas, @País, @Idioma_original)
END

create procedure sp_libros_registrados
as begin
select * from Libros
end