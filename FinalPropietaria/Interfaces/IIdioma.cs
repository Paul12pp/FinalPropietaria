using FinalPropietaria.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalPropietaria.Interfaces
{
    public interface IIdioma
    {
        IEnumerable<Idiomas> GetIdiomas();
        int AddIdioma(Idiomas model);
        int EditIdioma(int idIdioma, Idiomas model);
        Idiomas GetIdiomaById(int idIdioma);
    }
}
