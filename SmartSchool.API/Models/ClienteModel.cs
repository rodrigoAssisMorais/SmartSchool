using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SmartSchool.API.Models
{
    public class ClienteModel
    {
        public ClienteModel() { }

        public ClienteModel(string id, string nome, int idade)
        {
            Id = id;
            Nome = nome;
            Idade = idade;
        }

        public string Id { get; set; }
        public string Nome { get; set; }
        public int Idade { get; set; }
    }
}
