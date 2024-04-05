using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScientificResearch.Shared.Entities
{
    public  class ResourceAllocation
    {
        public int Id { get; set; }

        [Display(Name = "Cantidad requerida")]
        [Required(ErrorMessage = "El campo {0} es obligatorio")]
        public int Quantity { get; set; }



        //Relacionamos con las tablas que le envían foráneas
        public ScientificInvestigation ScientificInvestigations { get; set; }

        public searchActivity searchActivities { get; set; }

        public Investigator Investigators { get; set; }

        public specializedResource specializedResources { get; set; }    

    }
}
