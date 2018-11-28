using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace GoalsApplicationMark1.Models
{
    public class Goals : BaseEntity
    {
        [Key]
        public long Id { get; set; }

        [Required]
        public string Goal { get; set; }

        [Required]
        public string Description { get; set; }

        [Required]
        public int Ranking { get; set; }

        [Required]
        public DateTime DeliverableDate { get; set; }

        [Required]
        public bool IsSpecific { get; set; }

        public string IsSpecificDescription { get; set; }

        [Required]
        public bool IsMeasureable { get; set; }

        public string IsMeasureableDescription { get; set; }

        [Required]
        public bool IsAchieveable { get; set; }

        public string IsAchieveableDescription { get; set; }

        [Required]
        public bool IsRelevant { get; set; }

        public string IsRelevantDescription { get; set; }

        [Required]
        public bool IsTimebound { get; set; }

        public string IsTimeboundDescription { get; set; }

        public long EpicId { get; set; }
    }
}
