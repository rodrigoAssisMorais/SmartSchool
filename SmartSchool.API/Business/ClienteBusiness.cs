using SmartSchool.API.Data;
using SmartSchool.API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SmartSchool.API.Business
{
    public class ClienteBusiness : IClienteBusiness
    {
        private readonly IClienteRepository _repo;

        public ClienteBusiness(IClienteRepository repo)
        {
            _repo = repo;
        }

        public Result<ClienteModel> Add(ClienteModel cliente)
        {

            Cliente cl =
                new Cliente
                {
                    Id = Guid.NewGuid(),
                    Nome = cliente.Nome,
                    Idade = cliente.Idade
                };

            try
            {
                _repo.Add(cl);
                if (_repo.SaveChanges())
                    return new Result<ClienteModel>
                    {
                        Success = true,
                        Message = "Cliente incluído.",
                        Resource = new ClienteModel
                        {
                            Id = cl.Id.ToString(),
                            Idade = cl.Idade,
                            Nome = cl.Nome
                        }
                    };

                return new Result<ClienteModel>
                {
                    Success = true,
                    Message = "Aluno não cadastrado"
                };
            }
            catch (Exception e)
            {
                return new Result<ClienteModel>
                {
                    Success = false,
                    Message = $"Ocorreu o seguinte erro: {e.Message}"
                };
            }
            
        }

        public Result<List<ClienteModel>> GetAllClientes()
        {
            try
            {


                var clientes = _repo.GetAllClientes();
                if (clientes == null || !clientes.Any())
                    return new Result<List<ClienteModel>>
                    {
                        Message = "Não há alunos cadastrados.",
                        Success = true
                    };

                List<ClienteModel> clientesModel = new List<ClienteModel>();
                foreach (Cliente cl in clientes)
                {
                    clientesModel.Add(
                        new ClienteModel
                        {
                            Id = cl.Id.ToString(),
                            Nome = cl.Nome,
                            Idade = cl.Idade
                        });
                }

                Result<List<ClienteModel>> cls = new Result<List<ClienteModel>>();
                cls.Success = true;
                cls.Resource = clientesModel;

                return cls;
            }
            catch(Exception e)
            {
                return new Result<List<ClienteModel>>
                {
                    Success = false,
                    Message = $"Ocorreu o seguinte erro: {e.Message}"
                };
            }
        }

        public Result<ClienteModel> GetClienteById(Guid id)
        {
            try
            {


                var cl = _repo.GetClienteById(id);

                if (cl == null)
                {
                    return new Result<ClienteModel>
                    {
                        Success = true,
                        Message = "Cliente não encontrado."
                    };
                }

                Result<ClienteModel> cliente = new Result<ClienteModel>();
                cliente.Resource = new ClienteModel
                {
                    Id = cl.Id.ToString(),
                    Idade = cl.Idade,
                    Nome = cl.Nome
                };
                cliente.Success = true;
                return cliente;
            }
            catch(Exception e)
            {
                return new Result<ClienteModel>
                {
                    Success = false,
                    Message = $"Ocorreu o seguinte erro: {e.Message}"
                };
            }
        }

        public Result<object> Delete(Guid id)
        {
            try
            {


                Cliente cliente = _repo.GetClienteById(id);
                if (cliente == null)
                    return new Result<object>
                    {
                        Message = "Cliente não encontrado.",
                        Success = true
                    };

                _repo.Delete(cliente);
                if (_repo.SaveChanges())
                {
                    return new Result<object>
                    {
                        Message = "Cliente excluído",
                        Success = true
                    };
                }

                return new Result<object>
                {
                    Message = "Cliente não exluído",
                    Success = true
                };
            }
            catch (Exception e)
            {
                return new Result<object>
                {
                    Success = false,
                    Message = $"Ocorreu o seguinte erro: {e.Message}"
                };
            }
        }

        public Result<object> Update(Cliente cliente)
        {
            try
            {


                Cliente cl = _repo.GetClienteById(cliente.Id);

                if (cl == null)
                    return new Result<object>
                    {
                        Message = "Cliente não encontrado!",
                        Success = true
                    };

                _repo.Update(cliente);
                if (_repo.SaveChanges())
                {
                    return new Result<object>
                    {
                        Success = true,
                        Message = "Cliente atualizado."
                    };
                }

                return new Result<object>
                {
                    Message = "Cliente não atualizado.",
                    Success = true
                };
            }
            catch(Exception e)
            {
                return new Result<object>
                {
                    Success = false,
                    Message = $"Ocorreu o seguinte erro: {e.Message}"
                };
            }
        }
    }
}
