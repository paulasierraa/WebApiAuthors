using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApiAuthors.Domain.Entity.Enums;

namespace WebApiAuthors.Domain.Entity.Response
{
    public class GenericResponse<T> 
    {
        public StatusCode Status { get; set; }
        public string Message { get; set; }
        public T Content { get; set; }
    }
}
