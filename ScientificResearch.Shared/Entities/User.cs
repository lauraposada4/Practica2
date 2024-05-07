using Microsoft.AspNetCore.Identity;
using ScientificResearch.Shared.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScientificResearch.Shared.Entities
{
    public class User : IdentityUser
    {
        [Display(Name = "Nombre")]
        [MaxLength(20, ErrorMessage = "No se permiten mas de 20 dígitos")]
        [Required(ErrorMessage = "El campo {0} es obligatorio")]
        public string Name { get; set; }

        [Display(Name = "Especialidad")]
        [MaxLength(20, ErrorMessage = "No se permiten mas de 20 dígitos")]
        [Required(ErrorMessage = "El campo {0} es obligatorio")]
        public string Specialty { get; set; }



        [Display(Name = "Afiliación")]
        [MaxLength(20, ErrorMessage = "No se permiten mas de 20 dígitos")]
        [Required(ErrorMessage = "El campo {0} es obligatorio")]
        public string Membership { get; set; }

    
        
        public UserType UserType { get; set; }
    }
}
