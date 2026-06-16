using System;
using System.Collections.Generic;
using System.Text;

namespace AccesoDatos.Models
{
    public class AlumnoProfesor
    {
        public int Id { get; set; }

        public string Curp { get; set; }

        public string Nombre { get; set; } 

        public string Direccion { get; set; }

        public int Edad { get; set; }

        public string Email { get; set; }

        public string Asignatura { get; set; }

        public int MatriculaId { get; set; }
    }
}
