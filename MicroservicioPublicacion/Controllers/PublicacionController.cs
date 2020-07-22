﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using APLICACION.SERVICIOS;
using DOMINIO.DTOS;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace MicroservicioPublicacion.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PublicacionController : ControllerBase
    {
        private readonly IPublicacionServicio service;

        public PublicacionController(IPublicacionServicio service)
        {
            this.service = service;
        }
        [Route("InsertarPublicacion")]
        [HttpPost]
        public IActionResult Post(int productoID)
        {
            try
            {
                return new JsonResult(service.CrearPublicacion(productoID)) { StatusCode = 201 };

            }
            catch (System.Exception e)
            {
                return BadRequest(e.Message);

            }
        }


        [Route("TraerPublicaciones")]
        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                return new JsonResult(service.GetPublicaciones()) { StatusCode = 201 };

            }
            catch (System.Exception e)
            {
                return BadRequest(e.Message);

            }
        }



        [Route("TraerPublicacionesID")]
        [HttpGet]
        public IActionResult Get(int publicacionID)
        {
            try
            {
                return new JsonResult(service.GetPublicacionesID(publicacionID)) { StatusCode = 201 };

            }
            catch (System.Exception e)
            {
                return BadRequest(e.Message);

            }
        }



        [Route("TraerProductoID")]
        [HttpGet]
        public IActionResult Gett(int publicacionID)
        {

            //string url = "https://localhost:44370/api/Producto/TraerProductosID?productoID=" + productoID;


            //using (var http = new HttpClient())
            //{


            //    string request = await http.GetStringAsync(url);
            //    ProductoDTO posts = JsonConvert.DeserializeObject<ProductoDTO>(request);

            //    //producto.ImagenID = posts.ImagenID;
            //    //producto.PrecioID = posts.PrecioID;
            //    //producto.Nombre = posts.Nombre;
            //    //producto.Stock = posts.Stock;
            //    //producto.MarcaID = posts.MarcaID;
            //    //producto.CategoriaID = posts.CategoriaID;



            //    return posts;

            //}       
            
                return new JsonResult(service.GetProductoID(publicacionID).Result);

            
            
        }



        [Route("TraerProductosPublicaciones")]
        [HttpGet]
        public IActionResult GetPublicaciones(int CANTIDAD)
        {

            return new JsonResult(service.getProductosPublicacioens(CANTIDAD).Result);

            
           
        }


        [Route("PaginacionComentarios")]
        [HttpGet]
        public IActionResult PaginacionComentarios(PaginacionComentarioDto json)
        {
            try
            {
                return new JsonResult(service.PaginacionComentarios(json)) { StatusCode = 201 };

            }
            catch (System.Exception e)
            {
                return BadRequest(e.Message);

            }
        }



        [Route("ProductosPublicacionFiltro")]
        [HttpGet]
        public IActionResult ProductosPublicacionFiltro(string filtro)
        {

            return new JsonResult(service.ProductosPublicacionFiltro(filtro).Result);

            
          
        }






    }
}