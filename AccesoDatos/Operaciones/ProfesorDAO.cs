using AccesoDatos.Context;
using AccesoDatos.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace AccesoDatos.Operaciones
{
    public class ProfesorDAO
    {
        public ProyectoContext context = new ProyectoContext();
        public Profesor login(string usuario, string pass)
        {
            var prof = context.Profesors.Where(p => p.Usuario == usuario && p.Pass == pass).FirstOrDefault();
            
            return prof;
        }
       
    }
}
