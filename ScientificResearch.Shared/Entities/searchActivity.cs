using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScientificResearch.Shared.Entities
{
    
    public class searchActivity
    {
        public int Id { get; set; }

        [Display(Name = "Nombre")]
        [MaxLength(20, ErrorMessage = "No se permiten mas de 20 dígitos")]
        [Required(ErrorMessage = "El campo {0} es obligatorio")]
        public string Name { get; set; }

        [Display(Name = "Descripción")]
        [MaxLength(100, ErrorMessage = "No se permiten mas de 100 digitos")]
        [Required(ErrorMessage = "El campo {0} es obligatorio")]
        public string Description { get; set; }

        //Fecha de inicio
        [DataType(DataType.DateTime)]
        [DisplayFormat(DataFormatString = "{0: yyyy/MM/dd }", ApplyFormatInEditMode = true)]
        [Required(ErrorMessage = "El campo {0} es obligatorio")]
        public DateTime StartDate { get; set; }

        //Fecha de finalización
        [DataType(DataType.DateTime)]
        [DisplayFormat(DataFormatString = "{0: yyyy/MM/dd }", ApplyFormatInEditMode = true)]
        [Required(ErrorMessage = "El campo {0} es obligatorio")]
        public DateTime EndDate { get; set; }

        //Se colocan las tablas con la que esta clase se relaciona
        public ScientificInvestigation ScientificInvestigations { get; set; }   

        //SearchActivity envía su clave foránea a specialicedResource

        public ICollection<specializedResource> SpecializedResources { get; set; }  
    }
}
