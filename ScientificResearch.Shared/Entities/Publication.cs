using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScientificResearch.Shared.Entities
{
    
    public class Publication
    {

        //Primary key
        public int id { get; set; }

        //Campos de la clase
        [Display(Name ="Titulo")]
        [MaxLength(20, ErrorMessage ="No se permiten mas de 20 dígitos")]
        [Required(ErrorMessage ="El campo {0} es obligatorio")]
        public string Title { get; set; }


        [Display(Name = "Autor(es)")]
        [MaxLength(100, ErrorMessage = "No se permiten mas de 100 dígitos")]
        [Required(ErrorMessage = "El campo {0} es obligatorio")]
        public string Autor { get; set; }

        [DataType(DataType.DateTime)]
        [DisplayFormat(DataFormatString = "{0:yyyy/MM/dd HH:mm}",ApplyFormatInEditMode = true)]
        [Required(ErrorMessage ="El campo {0} es obligatorio")]
        public DateTime Date { get; set; }

        //Se colocan las tablas con las que se relacionan Publication
        public ScientificInvestigation ScientificInvestigations { get; set; }    


    }
}
