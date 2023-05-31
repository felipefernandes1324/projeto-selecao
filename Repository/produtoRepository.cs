using fortes111.Contexto;
using fortes111.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace fortes111.Repository
{
    public interface IProduto
    {
        Task<IEnumerable<Produto>> GetProduto();
        Task<Produto> GetProdutoByID(int produtoId);
        Task<Produto> InsertProduto(Produto objProduto);
        Task<Produto> UpdateProduto(Produto objProduto);
        bool DeleteProduto(int produtoId);
    }
    public class ProdutoRepository : IProduto
    {
        private readonly apiContexto _appDBContext;
        public ProdutoRepository(apiContexto context)
        {
            _appDBContext = context ??
                throw new ArgumentNullException(nameof(context));
        }
        public async Task<IEnumerable<Produto>> GetProduto()
        {
            return await _appDBContext.Produto.ToListAsync();
        }
        public async Task<Produto> GetProdutoByID(int produtoId)
        {
            return await _appDBContext.Produto.FindAsync(produtoId);
        }
        public async Task<Produto> InsertProduto(Produto objProduto)
        {
            _appDBContext.Produto.Add(objProduto);
            await _appDBContext.SaveChangesAsync();
            return objProduto;
        }
        public async Task<Produto> UpdateProduto(Produto objProduto)
        {
            _appDBContext.Entry(objProduto).State = EntityState.Modified;
            await _appDBContext.SaveChangesAsync();
            return objProduto;
        }
        public bool DeleteProduto(int produtoId)
        {
            bool result = false;
            var produto = _appDBContext.Produto.Find(produtoId);
            if (produto != null)
            {
                _appDBContext.Entry(produto).State = EntityState.Deleted;
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
}
