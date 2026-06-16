using AccesoDatos.Models;
using AccesoDatos.Operaciones;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [Route("api")]
    [ApiController]
    public class AlumnoController : ControllerBase
    {
        private AlumnoDAO alumnoDAO = new AlumnoDAO();

        [HttpGet("alumnosProfesor")]
        public List<AlumnoProfesor> alumnosProfesor(string usuario)
        {
            return alumnoDAO.seleccionarAlumnoProfesor(usuario);
        }

        [HttpGet("alumno")]
        public Alumno getAlumno(int id)
        {
            return alumnoDAO.seleccionar(id);
        }

        [HttpPut("alumno")] //puede tener el mismo nombre porque el tipo es put y el otro es get
        public bool actualizarAlumno([FromBody] Alumno alumno) //El fromBody es para que los datos vayan encapsulados en el body
        {
            return alumnoDAO.actualizar(alumno.Id, alumno.Curp, alumno.Nombre, alumno.Direccion, alumno.Edad, alumno.Email);
        }

        [HttpPost("alumno")]
        public bool insertarMatricula([FromBody] Alumno alumno, int idAsig)
        {
            return alumnoDAO.insertarYMatricular(alumno.Curp, alumno.Nombre, alumno.Direccion, alumno.Edad, alumno.Email, idAsig);
        }

        [HttpDelete("alumno")]
        public bool eliminarAlumno(int id)
        {
            return alumnoDAO.eliminarAlumno(id);
        }
    }
}
