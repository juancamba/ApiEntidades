using ApiEntidades.Models;
using ApiEntidades.Models.DTO;
using Microsoft.AspNetCore.Mvc;

namespace ApiEntidades.Repositories
{
    public interface IMuestraRepository
    {
        public string AltaConjuntoMuestra(ConjuntoMuestra conjuntoMuestra);
    }
}
