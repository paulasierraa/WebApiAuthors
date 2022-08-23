using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using WebApiAuthors.Validators;

namespace WebApiAuthors.DTOS
{
    public class AuthorRequest
    {
        [Required(ErrorMessage = "El campo {0} es requerido")]
        [StringLength(100, MinimumLength = 3, ErrorMessage = "El campo {0} debe ser de mínimo {2} carácteres")]
        [FirstUpper]
        public string Name { get; set; }
    }
}
