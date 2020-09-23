using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FinalPropietaria.Models;

namespace FinalPropietaria.Interfaces
{
    public class CandidatoRepos : ICandidato
    {
        private readonly RRHH_PropietariaEntities _dbContext;
        public CandidatoRepos(RRHH_PropietariaEntities dbContext)
        {
            _dbContext = dbContext;
        }
        public int AddCandidato(Candidatos model)
        {
            try
            {
                _dbContext.Candidatos.Add(model);
                _dbContext.SaveChanges();
                return 200;
            }
            catch (Exception)
            {
                return 500;
            }
        }

        public int AddCapacitaciones(List<Capacitaciones> model)
        {
            try
            {
                _dbContext.Capacitaciones.AddRange(model);
                _dbContext.SaveChanges();
                return 200;
            }
            catch (Exception)
            {
                return 500;
            }
        }

        public int AddExperiencia(List<Experiencia> model)
        {
            try
            {
                _dbContext.Experiencia.AddRange(model);
                _dbContext.SaveChanges();
                return 200;
            }
            catch (Exception)
            {
                return 500;
            }
        }

        public Candidatos GetCandidatoById(int id)
        {
            return _dbContext.Candidatos
                .SingleOrDefault(r => r.Id == id);
        }

        public IEnumerable<Candidatos> GetCandidatos()
        {
            return _dbContext.Candidatos
                .ToList();
        }

        public IEnumerable<Experiencia> GetExperienciasByCandidato(int id)
        {
            return _dbContext.Experiencia
                .Where(r => r.IdCandidato == id)
                .ToList();
        }
    }
}
