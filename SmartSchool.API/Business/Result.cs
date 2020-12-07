using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SmartSchool.API.Business
{
    public class Result<T>
    {
        public Result(bool success, string message, T resource)
        {
            Success = success;
            Message = message;
            Resource = resource;
        }

        public Result() { }

        public T Resource { get; set; }
        public bool Success { get; set; }
        public string Message { get; set; }
    }
}
