using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FinalPropietaria.Models;

namespace FinalPropietaria.Interfaces
{
    public class IdiomaRepos:IIdioma
    {

        private readonly RRHH_PropietariaEntities _dbContext;
        public IdiomaRepos(RRHH_PropietariaEntities dbContext)
        {
            _dbContext = dbContext;
        }

        public int AddIdioma(Idiomas model)
        {
            try
            {
                _dbContext.Idiomas.Add(model);
                _dbContext.SaveChanges();
                return 200;
            }
            catch (Exception)
            {
                return 500;
            }
        }

        public int EditIdioma(int idIdioma, Idiomas model)
        {
            try
            {
                var idioma = _dbContext.Idiomas
                    .SingleOrDefault(r => r.Id == idIdioma);
                idioma.Nombre = model.Nombre;
                idioma.Estado = model.Estado;
                _dbContext.SaveChanges();
                return 200;
            }
            catch (Exception)
            {
                return 500;
            }
        }

        public Idiomas GetIdiomaById(int idIdioma)
        {
            return _dbContext.Idiomas
                .Single(r => r.Id == idIdioma);
        }

        public IEnumerable<IdiomaViewModel> GetIdiomas()
        {
            var data = _dbContext.Idiomas
                .ToList();
            List <IdiomaViewModel> list = new List<IdiomaViewModel>();
            foreach (var item in data)
            {
                list.Add(
                    new IdiomaViewModel
                    {
                        Codigo=item.Id,
                        Nombre=item.Nombre,
                        Estado= item.Estado.Value ? "Activo":"Inactivo"
                    }
                 );
            }
            return list;
        }
    }
}
