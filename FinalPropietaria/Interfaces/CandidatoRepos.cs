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
        public Candidatos AddCandidato(Candidatos model)
        {
            try
            {
                var cand = _dbContext.Candidatos.Add(model);
                _dbContext.SaveChanges();
                return cand;
            }
            catch (Exception)
            {
                return new Candidatos();
            }
        }

        public int AddCapacitaciones(int id, List<Capacitaciones> model, 
            string competencias)
        {
            try
            {
                _dbContext.Capacitaciones.AddRange(model);
                var cand = _dbContext.Candidatos
                    .SingleOrDefault(r => r.Id == id);
                cand.Competencias = competencias;
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

        public int DeleteCandidato(int id)
        {
            try
            {
                var cand = _dbContext.Candidatos
                    .SingleOrDefault(r => r.Id == id);
                if (cand != null)
                {
                    var cap = _dbContext.Capacitaciones
                        .Where(r => r.IdCandidato == id);
                    _dbContext.Capacitaciones.RemoveRange(cap);
                    var exp = _dbContext.Experiencia.
                        Where(r => r.IdCandidato == id);
                    _dbContext.Experiencia.RemoveRange(exp);
                    _dbContext.SaveChanges();
                    return 200;
                }
                else
                {
                    return 500;
                }
            }
            catch (Exception)
            {
                return 500;
            }
        }

        public int EditCandidato(int id, Candidatos model)
        {
            try
            {
                var cand = _dbContext.Candidatos
                    .SingleOrDefault(r => r.Id == id);
                cand.Nombre = model.Nombre;
                cand.IdPuesto = model.IdPuesto;
                cand.IdDepartamento = model.IdDepartamento;
                cand.Recomendado_p = model.Recomendado_p;
                cand.Salario_Asp = model.Salario_Asp;
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

        public IEnumerable<CandidatoViewModel> GetCandidatos()
        {
            var data = _dbContext.Candidatos
                .ToList();
            List<CandidatoViewModel> list = new List<CandidatoViewModel>();
            foreach (var item in data)
            {
                list.Add(
                    new CandidatoViewModel
                    {
                        Codigo = item.Id,
                        Nombre = item.Nombre,
                        Cedula = item.Cedula,
                        Departamento = item.Departamento.Descripcion,
                        Competencias = item.Competencias,
                        Puesto = item.Puestos.Nombre,
                        Salario_Asp = item.Salario_Asp.Value,
                        Recomendado_p = item.Recomendado_p
                    }
                 );
            }
            return list;
        }

        public IEnumerable<Experiencia> GetExperienciasByCandidato(int id)
        {
            return _dbContext.Experiencia
                .Where(r => r.IdCandidato == id)
                .ToList();
        }

        public IEnumerable<Candidatos> Search(string nombre, int puesto, string comp, 
            decimal salarioD, decimal salarioH)
        {
           var data = _dbContext.Candidatos
                .Where(r => r.Nombre == nombre || r.IdPuesto == puesto
                || r.Competencias.Contains(comp) || r.Salario_Asp > salarioD && r.Salario_Asp < salarioH)
                .ToList();
            return data;
        }
    }
}
