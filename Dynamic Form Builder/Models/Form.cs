using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Dynamic_Form_Builder.Models
{
    public class Form
    {
        public int FormId { get; set; }

        [Required]
        public string Title { get; set; }

        public List<DropdownField> Fields { get; set; } = new List<DropdownField>();
    }
}
