using fortes111.Models;
using System.Collections.Generic;
using System.Threading.Tasks;
using fortes111.Repository;
using System;
using Microsoft.EntityFrameworkCore;
using fortes111.Contexto;

namespace fortes111.Repository
{ 
public interface IFornecedor
    {
        Task<IEnumerable<Fornecedor>> GetFornecedor();
        Task<Fornecedor> GetFornecedorByID(int FornecedorCNPJ);
        Task<Fornecedor> InsertFornecedor(Fornecedor objFornecedor);
        Task<Fornecedor> UpdateFornecedor(Fornecedor objFornecedor);
        bool DeleteFornecedor(int FornecedorCNPJ);
    }
    public class FornecedorRepository : IFornecedor
    {
        private readonly apiContexto _appDBContext;
        public FornecedorRepository(apiContexto context)
        {
            _appDBContext = context ??
                throw new ArgumentNullException(nameof(context));
        }
        public async Task<IEnumerable<Fornecedor>> GetFornecedor()
        {
            return await _appDBContext.Fornecedor.ToListAsync();
        }
        public async Task<Fornecedor> GetFornecedorByID(int fornecedorCNPJ)
        {
            return await _appDBContext.Fornecedor.FindAsync(fornecedorCNPJ);
        }
        public async Task<Fornecedor> InsertFornecedor(Fornecedor objFornecedor)
        {
            _appDBContext.Fornecedor.Add(objFornecedor);
            await _appDBContext.SaveChangesAsync();
            return objFornecedor;
        }
        public async Task<Fornecedor> UpdateFornecedor(Fornecedor objFornecedor)
        {
            _appDBContext.Entry(objFornecedor).State = EntityState.Modified;
            await _appDBContext.SaveChangesAsync();
            return objFornecedor;
        }
        public bool DeleteFornecedor(int ID)
        {
            bool result = false;
            var fornecedor = _appDBContext.Fornecedor.Find(ID);
            if (fornecedor != null)
            {
                _appDBContext.Entry(fornecedor).State = EntityState.Deleted;
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
