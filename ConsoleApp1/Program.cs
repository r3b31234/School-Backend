
using AccesoDatos.Models;
using AccesoDatos.Operaciones;

AlumnoDAO opAlumno = new AlumnoDAO();

Console.WriteLine("################");
//opAlumno.insertar("EIHL9108", "Luis Angel", "10715 L'archeveque", 34, "r3b3123@gmail.com");
opAlumno.eliminar(11);
var alumnos = opAlumno.seleccionarTodos();
foreach (var alumno in alumnos)
{
    Console.WriteLine(alumno.Nombre);
}

Console.WriteLine("################");
var alumnoId = opAlumno.seleccionar(1);
if (alumnoId != null)
{
    Console.WriteLine("El alumno con id 1 es: " + alumnoId.Nombre);
}
else
{
    Console.WriteLine("El alumno no existe");
}
Console.WriteLine("################");

var alumnoMateria = opAlumno.seleccionaralumnosMaterias();
if (alumnoMateria != null)
{
    foreach (AlumnosMateria almat in alumnoMateria)
    { 
        Console.WriteLine(almat.NombreAlumno + "-" + almat.NombreMateria);
    }
}

//opAlumno.actualizar(11, "EIHL9108", "Luis Angel Espina Hernandez", "10715 L'archeveque", 34, "r3b3123@gmail.com");
//var alumnoActualizado = opAlumno.seleccionar(11);
//if (alumnoActualizado != null)
//{
//  Console.WriteLine("El alumno : " + alumnoActualizado.Nombre + " Se actualizo correctamente");
//}
//else
//{
//  Console.WriteLine("El alumno no existe");
//}
