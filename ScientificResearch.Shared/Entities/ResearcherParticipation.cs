using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScientificResearch.Shared.Entities
{
    public class ResearcherParticipation//Participación de Investigadores(Tabla intermedia)
    {
        public int Id { get; set; }

        [ForeignKey("Investigacion Científica")]
        public int Id_ScientificInvestigations { get; set; }
        public ScientificInvestigation ScientificInvestigations { get; set; }

        [ForeignKey("Investigadores")]
        public int Id_Investigators { get; set; }
        public Investigator Investigators { get; set; }

    }
}
