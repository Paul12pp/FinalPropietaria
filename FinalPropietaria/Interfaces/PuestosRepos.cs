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

        public IEnumerable<Puestos> GetPuestos()
        {
            return _dbContext.Puestos
                .ToList();
        }

        public Puestos GetPuestosById(int idPuesto)
        {
            return _dbContext.Puestos
                .SingleOrDefault(r => r.Id == idPuesto);
        }
    }
}
