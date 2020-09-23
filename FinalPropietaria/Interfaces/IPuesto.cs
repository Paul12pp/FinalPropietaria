using FinalPropietaria.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalPropietaria.Interfaces
{
    public interface IPuesto
    {
        IEnumerable<Puestos> GetPuestos();
        IEnumerable<Departamento> GetDepartamentos();
        int AddPuesto(Puestos model);
        int EditPuesto(int idPuesto, Puestos model);
        Puestos GetPuestosById(int idPuesto);
    }
}
