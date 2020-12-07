using SmartSchool.API.Data;
using SmartSchool.API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SmartSchool.API.Business
{
    public interface IClienteBusiness
    {
        Result<ClienteModel> Add(ClienteModel cliente);
        Result<List<ClienteModel>> GetAllClientes();
        Result<ClienteModel> GetClienteById(Guid id);
        Result<object> Delete(Guid id);
        Result<object> Update(Cliente cliente);

    }
}
