using FinalPropietaria.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalPropietaria.Interfaces
{
    public interface ICandidato
    {
        IEnumerable<Candidatos> GetCandidatos();
        Candidatos GetCandidatoById(int id);
        int AddCandidato(Candidatos model);
        int AddExperiencia(List<Experiencia> model);
        IEnumerable<Experiencia> GetExperienciasByCandidato(int id);
        int AddCapacitaciones(List<Capacitaciones> model);
    }
}
