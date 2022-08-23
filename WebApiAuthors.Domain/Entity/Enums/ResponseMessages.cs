using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebApiAuthors.Domain.Entity.Enums
{
    public static class ResponseMessages
    {
        public static string SUCCESFUL_CREATE = "Datos creados con éxito";
        public static string SUCCESFUL_EDIT = "Datos editados con éxito";
        public static string SUCCESFUL_DELETE = "Datos eliminados con éxito";
        public static string INTERNAL_SERVER_ERROR = "Error en el servidor";
        public static string SUCCESFUL_GET = "Datos recuperados con éxito";
    }
}
