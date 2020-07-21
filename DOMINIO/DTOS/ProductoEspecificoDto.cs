﻿using System;
using System.Collections.Generic;
using System.Text;

namespace DOMINIO.DTOS
{
    public class ProductoEspecificoDto
    {
        private string nombre;
        private string descripcion;
        private decimal precio;
        private string imagen;
        private string categoria;
        private string marca;
        private int stock;
        private int publicacionID;


        public string Nombre { get => nombre; set => nombre = value; }
        public string Descripcion { get => descripcion; set => descripcion = value; }
        public decimal Precio { get => precio; set => precio = value; }
        public string Imagen { get => imagen; set => imagen = value; }
        public string Categoria { get => categoria; set => categoria = value; }
        public string Marca { get => marca; set => marca = value; }
        public int Stock { get => stock; set => stock = value; }
        public int PublicacionID { get => publicacionID; set => publicacionID = value; }
    }
}
