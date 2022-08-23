using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebApiAuthors.Domain.Entity.Enums
{
    public enum StatusCode
    {
        Ok = 200,
        InternalServerError = 500,
        Unauthorized = 401
    }
}
