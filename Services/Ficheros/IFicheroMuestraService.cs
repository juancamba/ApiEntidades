using ApiEntidades.Models.DTO;

namespace ApiEntidades.Services.Ficheros
{
     public interface IFicheroMuestraService
    {

        public ConjuntoMuestra Cargar(IFormFileCollection file);
        

    }
}
