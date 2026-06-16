using System;
using System.Collections.Generic;

namespace AccesoDatos.Models;

public partial class Profesor
{
    public string Usuario { get; set; } = null!;

    public string Pass { get; set; } = null!;

    public string? Nombre { get; set; } = null!; //El cierre de interrogacion quiere decir que yo puedo crear objetos del tipo profesor sin ese elemento

    public string? Email { get; set; } = null!;

    public virtual ICollection<Asignatura> Asignaturas { get; set; } = new List<Asignatura>();
}
