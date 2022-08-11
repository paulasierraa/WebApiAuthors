using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using WebApiAuthors.Entity.Base;
using WebApiAuthors.Validators;

namespace WebApiAuthors.Entity
{
    public class Author:IValidatableObject
    {
        public int Id { get; set; }
        [Required(ErrorMessage ="El campo {0} es requerido")]
        [StringLength(100,MinimumLength = 3,ErrorMessage ="El campo {0} debe ser de mínimo {2} carácteres")]
        [FirstUpper]
        public string Name { get; set; }

        public List<AuthorBooks> AuthorsBooks { get; set; }
        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            if (string.IsNullOrEmpty(Name))
            {
                var firstLetter = Name.ToString()[0].ToString();
                if (firstLetter != firstLetter.ToUpper())
                {
                    yield return new ValidationResult("La primera letra debe ser mayúscula", new string[] { nameof(Name)});
                }
            }
        }
    }
}
