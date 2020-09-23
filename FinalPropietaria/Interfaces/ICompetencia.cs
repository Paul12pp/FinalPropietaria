using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FinalPropietaria.Models;

namespace FinalPropietaria.Interfaces
{
    public interface ICompetencia
    {
        IEnumerable<Competencias> GetCompetencias();
        int AddCompetencia(Competencias model);
        int EditCompetencia(int idCompetencia, Competencias model);
        Competencias GetCompetenciaById(int idCompetencia);
    }
}
