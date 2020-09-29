using FinalPropietaria.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalPropietaria.Interfaces
{
    public class CompetenciaRepos: ICompetencia
    {
        private readonly RRHH_PropietariaEntities _dbContext;
        public CompetenciaRepos(RRHH_PropietariaEntities dbContext)
        {
            _dbContext = dbContext;
        }

        public int AddCompetencia(Competencias model)
        {
            try
            {
                _dbContext.Competencias.Add(model);
                _dbContext.SaveChanges();
                return 200;
            }
            catch (Exception)
            {
                return 500;
            }
        }

        public int EditCompetencia(int idCompetencia, Competencias model)
        {
            try
            {
                var comp = _dbContext.Competencias
                    .SingleOrDefault(r => r.Id == idCompetencia);
                comp.Descripcion = model.Descripcion;
                comp.Estado = model.Estado;
                _dbContext.SaveChanges();
                return 200;
            }
            catch (Exception)
            {
                return 500;
            }
        }

        public Competencias GetCompetenciaById(int idCompetencia)
        {
            return _dbContext.Competencias
               .Single(r => r.Id == idCompetencia);
        }

        public IEnumerable<CompetenciaViewModel> GetCompetencias()
        {

            var data = _dbContext.Competencias
                .ToList();
            List<CompetenciaViewModel> list = new List<CompetenciaViewModel>();
            foreach (var item in data)
            {
                list.Add(
                    new CompetenciaViewModel
                    {
                        Codigo = item.Id,
                        Descripcion = item.Descripcion,
                        Estado = item.Estado.Value ? "Activo" : "Inactivo"
                    }
                 );
            }
            return list;
        }
    }
}
