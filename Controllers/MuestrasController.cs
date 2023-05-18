using ApiEntidades.Models.DTO;
using ApiEntidades.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using CsvHelper;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.Extensions.Configuration;
using System.Globalization;
using System;
using System.Text.Json;
using CsvHelper.Configuration;
using Newtonsoft.Json;
using ApiEntidades.Services.Ficheros;
using ApiEntidades.Repositories;

namespace ApiEntidades.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MuestrasController : ControllerBase
    {

        private readonly AppDbContext _entidadesContext;
        private readonly IFicheroMuestraService _ficheroMuestraService;
        private readonly IMuestraRepository _muestraRepository;
        public MuestrasController(AppDbContext entidadesContext, IFicheroMuestraService ficheroMuestraService,IMuestraRepository muestraRepository)
        {
            _entidadesContext = entidadesContext;
            _ficheroMuestraService = ficheroMuestraService;
            _muestraRepository = muestraRepository;
            

        }
        [HttpPost]
        public ActionResult<ConjuntoMuestra> CargarMuestras([FromForm] IFormFileCollection file)
        {
            ConjuntoMuestra conjuntoMuestra = _ficheroMuestraService.Cargar(file);
            _muestraRepository.AltaConjuntoMuestra(conjuntoMuestra);

            /*
            var filePath = Path.GetTempFileName();
            
            using (var stream = System.IO.File.Create(filePath))
            {
                file[0].CopyToAsync(stream);
            }
            // ver con memory stream https://learn.microsoft.com/en-us/aspnet/core/mvc/models/file-uploads?view=aspnetcore-7.0
            var config = new CsvConfiguration(CultureInfo.InvariantCulture)
            {
                HasHeaderRecord = false,
                Delimiter =";"   
                
            };

            using (var stream = new StreamReader(filePath))
            using (var reader = new CsvReader(stream, config))
            {
           


                var records = reader.GetRecords<dynamic>().ToList();

                var json = JsonConvert.SerializeObject(records);
                var dictionary = JsonConvert.DeserializeObject<List<Dictionary<string, string>>>(json);
            }
            */

            //JsonConvert.SerializeObject(conjuntoMuestra)

            return Ok(conjuntoMuestra);
        }
    }
}
