using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FinalPropietaria.Models;

namespace FinalPropietaria.Interfaces
{
    public class EmpleadoRepos:IEmpleado
    {
        private readonly RRHH_PropietariaEntities _dbContext;
        public EmpleadoRepos(RRHH_PropietariaEntities dbContext)
        {
            _dbContext = dbContext;
        }

        public int AddEmpleado(Empleado model)
        {
            try
            {
                _dbContext.Empleado.Add(model);
                _dbContext.SaveChanges();
                return 200;
            }
            catch (Exception)
            {
                return 500;
            }
        }

        public int EditEmpleado(int idEmpleado, Empleado model)
        {
            try
            {
                var empleado = _dbContext.Empleado
                    .SingleOrDefault(r => r.Id == idEmpleado);
                empleado.Nombre = model.Nombre;
                empleado.Cedula = model.Cedula;
                empleado.Puesto = model.Puesto;
                empleado.IdDepartamento = model.IdDepartamento;
                empleado.Salario_M = model.Salario_M;
                empleado.Estado = model.Estado;
                _dbContext.SaveChanges();
                return 200;
            }
            catch (Exception)
            {
                return 500;
            }
        }

        public Empleado GetEmpleadoById(int idEmpleado)
        {
            return _dbContext.Empleado
                .SingleOrDefault(r => r.Id == idEmpleado);
        }

        public IEnumerable<Empleado> GetEmpleados()
        {
            return _dbContext.Empleado
                .ToList();
        }
    }
}
