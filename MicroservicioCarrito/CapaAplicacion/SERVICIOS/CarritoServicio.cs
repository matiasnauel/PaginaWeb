using CapaDominio.COMANDOS;
using CapaDominio.ENTIDADES;
using CapaDominio.QUERYS;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CapaAplicacion.SERVICIOS
{
    public interface ICarritoServicio
    {
        Carrito InsertarCarritoCliente(int clienteID);
        Task<decimal> ValorCarritoCliente(int clienteID);
    }


    public class CarritoServicio :ICarritoServicio
    {
        private readonly IGenericsRepository repository;
        private readonly IQueryCarrito query;






        public CarritoServicio(IGenericsRepository repository, IQueryCarrito query)
        {
            this.repository = repository;
            this.query = query;
        }

        public Carrito InsertarCarritoCliente(int clienteID)
        {
            Carrito objeto = new Carrito()
            {
                ClienteID = clienteID
            };


            return repository.Agregar<Carrito>(objeto);
        }

        public Task<decimal> ValorCarritoCliente(int clienteID)
        {
            return query.ValorCarritoCliente(clienteID);
        }
    }
}
