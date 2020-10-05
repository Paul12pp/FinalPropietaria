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
        IEnumerable<CandidatoViewModel> GetCandidatos();
        IEnumerable<CandidatoViewModel> GetCandidatosByPuestos(int idPuesto);
        Candidatos GetCandidatoById(int id);
        Candidatos AddCandidato(Candidatos model);
        int EditCandidato(int id, Candidatos model);
        int AddExperiencia(List<Experiencia> model);
        IEnumerable<ExperienciaViewModel> GetExperienciasByCandidato(int id);
        IEnumerable<CapacitacionViewModel> GetCapacitacionByCandidato(int id);
        int AddCapacitaciones(int id, List<Capacitaciones> model,
            string competencias);
        int DeleteCandidato(int id);
        IEnumerable<Candidatos> Search(string nombre, int puesto, string comp,
            decimal salarioD, decimal salarioH);
        int AprobarCandidato(int idcandidato);
        int RechazarCandidato(int idcandidato);
    }
}
