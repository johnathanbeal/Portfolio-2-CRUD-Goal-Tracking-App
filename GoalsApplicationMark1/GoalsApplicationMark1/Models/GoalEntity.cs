using GoalsApplicationMark1.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using static GoalsApplicationMark1.Common.Category;

namespace GoalsApplicationMark1.Models
{
    public class GoalEntity : BaseEntity
    {
        [Key]
        [Display(Name = "No.")]
        public long Id { get; set; }

        public long EpicId { get; set; }

        public long GoalCandidateId { get; set; }

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

        [Required]
        public bool IsMeasureable { get; set; }

        [Required]
        public bool IsAchieveable { get; set; }

        [Required]
        public bool IsRelevant { get; set; }

        [Required]
        public bool IsTimebound { get; set; }

        public EnumCategory Category { get; set; }

        public string CategoryString { get; set; }

        public EnumSubCategory SubCategory { get; set; }

        public string SubCategoryString { get; set; }

        public NanoCategory NanoCategory { get; set; }

        public string NanoCategoryString { get; set; }

        //public IEnumerable<GoalTypes> GoalTypes { get; set; }    
        
        public GoalTypes GoalType { get; set; }

        public string GoalTypeString { get; set; }
    }
}
