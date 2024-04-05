using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScientificResearch.Shared.Entities
{
    public class ResearcherParticipation
    {
        public int Id { get; set; }

        public ScientificInvestigation ScientificInvestigations { get; set; }

        public Investigator Investigators { get; set; }

    }
}
