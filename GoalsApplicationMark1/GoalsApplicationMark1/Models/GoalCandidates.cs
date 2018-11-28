using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace GoalsApplicationMark1.Models
{
    public class GoalCandidates : BaseEntity
    {
        [Required]
        public long Id { get; set; }

        [Required]
        public string Candidate { get; set; }

        [Required]
        public string Description { get; set; }

        public long GoalId { get; set; }

        public long EpicId { get; set; }

        public long TaskId { get; set; }
    }
}
