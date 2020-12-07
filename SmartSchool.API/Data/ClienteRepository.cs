using Microsoft.EntityFrameworkCore;
using SmartSchool.API.Models;
using System;
using System.Linq;

namespace SmartSchool.API.Data
{
    public class ClienteRepository : IClienteRepository
    {
        private readonly SmartContext _context;

        public ClienteRepository(SmartContext context)
        {
            _context = context;
        }

        public void Add(Cliente entity)
        {
            _context.Add(entity);
        }

        public void Update(Cliente entity)
        {
            _context.Update(entity);
        }

        public void Delete(Cliente entity)
        {
            _context.Remove(entity);
        }

        public bool SaveChanges()
        {
            return (_context.SaveChanges() > 0);
        }

        public Cliente GetClienteById(Guid id)
        {
            IQueryable<Cliente> query = _context.Clientes;

         
            query = query
                .AsNoTracking()
                .Where(cl => cl.Id == id);

            return query.FirstOrDefault();
        }

        public Cliente[] GetAllClientes()
        {
            IQueryable<Cliente> query = _context.Clientes;

            query = query
                .AsNoTracking()
                .OrderBy(cl => cl.Id);

            return query.ToArray();
        }
    }
}
