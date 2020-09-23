using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FinalPropietaria.Models;

namespace FinalPropietaria.Interfaces
{
    public interface IEmpleado
    {
        IEnumerable<Empleado> GetEmpleados();
        int AddEmpleado(Empleado model);
        int EditEmpleado(int idEmpleado, Empleado model);
        Empleado GetEmpleadoById(int idEmpleado);
    }
}
