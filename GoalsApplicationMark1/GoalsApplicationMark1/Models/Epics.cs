using GoalsApplicationMark1.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace GoalsApplicationMark1.Models
{
    public class Epics : BaseEntity
    {
        [Required]
        public long Id { get; set; }
        [Required]
        public string Epic { get; set; }
        [Required]
        public string Description { get; set; }

        public EnumCategory Category { get; set; }

        public EnumSubCategory Subcategory { get; set; }
    }
}
