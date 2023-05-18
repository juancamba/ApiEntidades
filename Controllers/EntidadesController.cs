using ApiEntidades.Models;
using ApiEntidades.Models.DTO;
using LinqLib.Sequence;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ApiEntidades.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EntidadesController : ControllerBase
    {
        private readonly AppDbContext _entidadesContext;
        public EntidadesController(AppDbContext entidadesContext)
        {
            _entidadesContext = entidadesContext;

        }
        [HttpGet]
        public ActionResult<List<DatosEntidades>> GetTodoItems()
        {


            var entidadJoinValores = from e in _entidadesContext.Entidades
                                     join v in _entidadesContext.ValoresDatosEstaticos on e.Id equals v.IdEntidad
                                     select new
                                     {
                                         eId = e.Id,
                                         valor = v.Valor,
                                         IdNombreDatoEstatico = v.IdNombreDatoEstatico


                                     };
            var query = from item in entidadJoinValores
                        join n in _entidadesContext.NombresDatosEstaticos on item.IdNombreDatoEstatico equals n.Id
                        select new DatosEntidades
                        {
                            Nombre = n.Nombre,
                            Valor = item.valor,
                            Id = item.eId
                        }

                                    ;

            List<DatosEntidades> datosEntidades = new List<DatosEntidades>();
            datosEntidades.AddRange(query.DefaultIfEmpty().ToList());

            // filas a columnas
            // 
            /*
                        var agrupado2 = query
                            .Pivot(k => k.Nombre, 
                            v1 => v1.Max(c=>c.Valor), new
                            {
                                e.Nombre,
                                e.Valor,
                                e.Id
                            });

                        try
                        {
                            var agrupado = query.GroupBy(p => p.Id)
                        .Select(g => new
                        {
                            GroupName = g.key,
                            Properties = g.ToDictionary(item => item.Nombre, item => item.Valor)
                        });
                        }
                        catch(Exception ex)
                        {

                            Console.WriteLine(ex.ToString());
                        }

                        */





            return Ok(datosEntidades);

        }
    }
}
