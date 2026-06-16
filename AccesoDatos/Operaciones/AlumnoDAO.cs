using AccesoDatos.Context;
using AccesoDatos.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace AccesoDatos.Operaciones
{
    public class AlumnoDAO
    {
        public ProyectoContext context = new ProyectoContext();

        //se va a crear un metodo para obtener todos los alumons
        public List<Alumno> seleccionarTodos()
        {
            var alumnos = context.Alumnos.ToList();
            return alumnos;
        }
        public Alumno seleccionar(int id)
        {
            var alumno = context.Alumnos.Where(a => a.Id == id).FirstOrDefault();

            return alumno;
        }

        public Alumno seleccionarPorCurp(string curp)
        {
            var alumno = context.Alumnos.Where(a => a.Curp.Equals(curp)).FirstOrDefault();

            return alumno;
        }

        public bool insertar(string curp, string nombre, string direccion, int edad, string email)
        {
            try
            {
                Alumno alumno = new Alumno();
                alumno.Curp = curp;
                alumno.Nombre = nombre;
                alumno.Direccion = direccion;
                alumno.Edad = edad;
                alumno.Email = email;

                context.Alumnos.Add(alumno);
                context.SaveChanges();
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }

        public bool actualizar(int id, string curp, string nombre, string direccion, int edad, string email)
        {

            try
            {
                Alumno alumno = seleccionar(id);
                if (alumno == null)
                {
                    return false;
                }
                else
                {
                    alumno.Curp = curp;
                    alumno.Nombre = nombre;
                    alumno.Direccion = direccion;
                    alumno.Edad = edad;
                    alumno.Email = email;

                    context.SaveChanges();

                }

                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }

        public bool eliminar(int id)
        {
            try
            {
                var alumno = seleccionar(id);
                if (alumno == null)
                {
                    return false;
                }
                else
                {
                    context.Alumnos.Remove(alumno);
                    context.SaveChanges();
                    return true;
                }

            }
            catch (Exception e)
            {
                return false;
            }
        }

        public List<AlumnosMateria> seleccionaralumnosMaterias()
        {
            var query = from a in context.Alumnos
                        join m in context.Matriculas on a.Id equals m.AlumnoId
                        join asig in context.Asignaturas on m.AsignaturaId equals asig.Id
                        select new AlumnosMateria
                        {
                            NombreAlumno = a.Nombre,
                            NombreMateria = asig.Nombre
                        };
            return query.ToList();
        }

        public List<AlumnoProfesor> seleccionarAlumnoProfesor(string usuario)
        {
            var query = from a in context.Alumnos
                        join m in context.Matriculas on a.Id equals m.AlumnoId
                        join asig in context.Asignaturas on m.AsignaturaId equals asig.Id
                        where asig.Profesor == usuario
                        select new AlumnoProfesor
                        {
                            Id = a.Id,
                            Curp = a.Curp,
                            Nombre = a.Nombre,
                            Direccion = a.Direccion,
                            Edad = a.Edad,
                            Email = a.Email,
                            Asignatura = asig.Nombre,
                            MatriculaId = m.Id
                        };
            return query.ToList();
        }

        public bool insertarYMatricular(string curp, string nombre, string direccion, int edad, string email, int idAsig)
        {
            try
            {
                var existe = seleccionarPorCurp(curp);
                if (existe == null)
                {
                    insertar(curp, nombre, direccion, edad, email);
                    var insertado = seleccionarPorCurp(curp);
                    Matricula matricula = new Matricula();
                    matricula.AlumnoId = insertado.Id;
                    matricula.AsignaturaId = idAsig;

                    context.Matriculas.Add(matricula);
                    context.SaveChanges();
                }
                else
                {
                    Matricula matricula = new Matricula();
                    matricula.AlumnoId = existe.Id;
                    matricula.AsignaturaId = idAsig;

                    context.Matriculas.Add(matricula);
                    context.SaveChanges();
                }

                return true;

            }
            catch (Exception e)
            {
                return false;
            }
        }

        public bool eliminarAlumno(int id)
        {
            try
            {
                var alumno = context.Alumnos.Where(a => a.Id == id).FirstOrDefault();

                if (alumno != null)
                {
                    var matriculas = context.Matriculas.Where(m => m.AlumnoId == id);

                    foreach(Matricula m in matriculas)
                    {
                        var calificaciones = context.Calificacions.Where(c => c.MatriculaId == m.Id);
                        context.Calificacions.RemoveRange(calificaciones); // el removeRange borra todas la calificaiones
                    }
                    //Ya puedo borrar matriculas por que ya no tengo calificaciones
                    context.Matriculas.RemoveRange(matriculas);
                    context.Alumnos.Remove(alumno);
                    context.SaveChanges();
                    return true;

                }
                else
                {
                    return false;
                }
            }
            catch(Exception e)
            { 
                return false;
            }
        }

        
    }
}

   
