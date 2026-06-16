using AccesoDatos.Context;
using AccesoDatos.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace AccesoDatos.Operaciones
{
    public class CalificacionDAO
    {
        public ProyectoContext context = new ProyectoContext();

        public List<Calificacion> buscarCalificacion(int id)
        {
            var calificaicones = context.Calificacions.Where(c => c.MatriculaId == id).ToList();

            return calificaicones;
        }

        public bool agregarCalificacion(Calificacion calif) 
        {
            try
            {
                context.Calificacions.Add(calif);
                context.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public bool eliminarCalificaion(int id)
        {
            try
            {
                var calificacion = context.Calificacions.Where(c => c.Id == id).FirstOrDefault();

                if (calificacion != null)
                {
                    context.Calificacions.Remove(calificacion);
                    context.SaveChanges();
                    return true;
                }
                else 
                {
                    return false;
                }
            }
            catch (Exception e)
            {
                return false;
            }

        }
    }
}
