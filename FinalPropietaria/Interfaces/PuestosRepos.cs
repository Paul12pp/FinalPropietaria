using FinalPropietaria.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalPropietaria.Interfaces
{
    public class PuestosRepos:IPuesto
    {
        private readonly RRHH_PropietariaEntities _dbContext;
        public PuestosRepos(RRHH_PropietariaEntities dbContext)
        {
            _dbContext = dbContext;
        }

        public int AddPuesto(Puestos model)
        {
            try
            {
                _dbContext.Puestos.Add(model);
                _dbContext.SaveChanges();
                return 200;
            }
            catch (Exception e)
            {
                return 500;
            }
        }

        public int EditPuesto(int idPuesto, Puestos model)
        {
            try
            {
                var puesto = _dbContext.Puestos
                    .SingleOrDefault(r => r.Id == idPuesto);
                puesto.Nombre = model.Nombre;
                puesto.Nivel_Riesgo = model.Nivel_Riesgo;
                puesto.Nivel_Ma_Salarial = model.Nivel_Ma_Salarial;
                puesto.Nivel_Mi_Salarial = model.Nivel_Mi_Salarial;
                puesto.Estado = model.Estado;
                _dbContext.SaveChanges();
                return 200;
            }
            catch (Exception)
            {
                return 500;
            }
        }

        public IEnumerable<Departamento> GetDepartamentos()
        {
            return _dbContext.Departamento
                .ToList();
        }

        public IEnumerable<PuestoViewModel> GetPuestos()
        {
            var data = _dbContext.Puestos
                .ToList();
            List<PuestoViewModel> list = new List<PuestoViewModel>();
            foreach (var item in data)
            {
                list.Add(
                    new PuestoViewModel
                    {
                        Codigo = item.Id,
                        Nombre = item.Nombre,
                        Nivel_Ma_Salarial = item.Nivel_Ma_Salarial.Value,
                        Nivel_Mi_Salarial = item.Nivel_Mi_Salarial.Value,
                        Nivel_Riesgo = item.Nivel_Riesgo,
                        Estado = item.Estado.Value ? "Activo" : "Inactivo"
                    }
                 );
            }
            return list;
        }

        public Puestos GetPuestosById(int idPuesto)
        {
            return _dbContext.Puestos
                .SingleOrDefault(r => r.Id == idPuesto);
        }
    }
}
