using SmartSchool.API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SmartSchool.API.Data
{
    public interface IClienteRepository 
    {
        Cliente[] GetAllClientes();
        Cliente GetClienteById(Guid id);

        void Add(Cliente entity);
        void Delete(Cliente entity);
        void Update(Cliente entity);
        bool SaveChanges();
    }
}
