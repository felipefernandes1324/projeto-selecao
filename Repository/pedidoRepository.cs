using fortes111.Contexto;
using fortes111.Models;
using fortes111.Repository;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace fortes111.Repository
{
        public interface IPedido
        {
            Task<IEnumerable<Pedido>> GetPedido();
            Task<Pedido> GetPedidoByID(int pedidoId);
            Task<Pedido> InsertPedido(Pedido objPedido);
            Task<Pedido> UpdatePedido(Pedido objPedido);
            bool DeletePedido(int pedidoId);
        }
    }
    public class PedidoRepository : IPedido
    {
        private readonly apiContexto _appDBContext;
        public PedidoRepository(apiContexto context)
        {
            _appDBContext = context ??
                throw new ArgumentNullException(nameof(context));
        }
        public async Task<IEnumerable<Pedido>> GetPedido()
        {
            return await _appDBContext.Pedido.ToListAsync();
        }
        public async Task<Pedido> GetPedidoByID(int pedidoId)
        {
            return await _appDBContext.Pedido.FindAsync(pedidoId);
        }
        public async Task<Pedido> InsertPedido(Pedido objPedido)
        {
            _appDBContext.Pedido.Add(objPedido);
            await _appDBContext.SaveChangesAsync();
            return objPedido;
        }
        public async Task<Pedido> UpdatePedido(Pedido objPedido)
        {
            _appDBContext.Entry(objPedido).State = EntityState.Modified;
            await _appDBContext.SaveChangesAsync();
            return objPedido;
        }
        public bool DeletePedido(int pedidoId)
        {
            bool result = false;
            var pedido = _appDBContext.Pedido.Find(pedidoId);
            if (pedido != null)
            {
                _appDBContext.Entry(pedido).State = EntityState.Deleted;
                _appDBContext.SaveChanges();
                result = true;
            }
            else
            {
                result = false;
            }
            return result;
        }
    }

