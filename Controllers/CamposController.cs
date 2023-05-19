using ApiEntidades.Models;
using ApiEntidades.Services;
using Microsoft.AspNetCore.Mvc;

namespace ApiEntidades.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CamposController : ControllerBase
    {
        private readonly CampoService _campoService;

        public CamposController(CampoService campoService)
        {
            _campoService = campoService;
        }

        [HttpGet]
        public ActionResult GetAll()
        {
            return Ok(_campoService.GetAll());
        }

        [HttpGet]
        [Route("{id}")]
        public ActionResult GetById(int id)
        {
            //return NotFound();

            return Ok(_campoService.GetById(id));
        }

        [HttpDelete]
        [Route("{id}")]
        public ActionResult Delete(int id)
        {
            try
            {
                _campoService.Delete(id);
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
            return Ok();

        }


        [HttpPost]
        public ActionResult Create(Campo campo)
        {
            _campoService.Create(campo);
            return Ok();
        }
        [HttpPut]
        public ActionResult Update(Campo campo)
        {
            _campoService.Update(campo);
            return Ok();
        }



    }
}
