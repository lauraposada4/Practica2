using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScientificResearch.Shared.Entities
{
    public  class ResourceAllocation//Asignación de Recursos(Tabla intermedia)
    {
        public int Id { get; set; }

        [Display(Name = "Cantidad requerida")]
        [Required(ErrorMessage = "El campo {0} es obligatorio")]
        public int Quantity { get; set; }



        //Relacionamos con las tablas que le envían foráneas

        [ForeignKey("Investigacion Científica")]
        public int Id_ScientificInvestigations { get; set; }
        public ScientificInvestigation ScientificInvestigations { get; set; }

        [ForeignKey("Actividades de investigación")]
        public int Id_searchActivities { get; set; }
        public searchActivity searchActivities { get; set; }

        [ForeignKey("Recursos Especializados")]
        public int Id_specializedResources { get; set; }
        public specializedResource specializedResources { get; set; }    

    }
}
