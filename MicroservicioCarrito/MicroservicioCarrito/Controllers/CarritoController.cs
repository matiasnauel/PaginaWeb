using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CapaAplicacion.SERVICIOS;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MicroservicioCarrito.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarritoController : ControllerBase
    {
        private readonly ICarritoServicio servicio;


        [Route("InsertarCarritoCliente")]
        [HttpPost]
        public IActionResult InsertarCarritoCliente(int clienteID)
        {
            try
            {
                return new JsonResult(servicio.InsertarCarritoCliente(clienteID)) { StatusCode = 200 };

            }
            catch (System.Exception e)
            {
                return BadRequest(e.Message);

            }
        }




        [Route("ValorCarritoCliente")]
        [HttpGet]
        public IActionResult ValorCarritoCliente(int clienteID)
        {

            return new JsonResult(servicio.ValorCarritoCliente(clienteID).Result);




        }






        public CarritoController(ICarritoServicio servicio)
        {
            this.servicio = servicio;

        }
    }
}
