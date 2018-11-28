using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using GoalsApplicationMark1.Common;

namespace GoalsApplicationMark1.Models
{
    public class Tasks : BaseEntity
    {
        [Key]
        public long Id { get; set; }

        [Required]
        public string Task { get; set; }

        [Required]
        public string Description { get; set; }

        [Required]
        public int Rank { get; set; }

        [Required]
        public DateTime Deadline { get; set;}
        
        public EnumCategory Category { get; set; }//turn this into an Enum

        public EnumSubCategory Subcategory { get; set; }

        public long GoalsId { get; set; }


    }
}
