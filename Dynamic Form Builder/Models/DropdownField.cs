using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Dynamic_Form_Builder.Models
{
    public class DropdownField
    {
        [Key]
        public int FieldId { get; set; }

        [Required]
        public string Label { get; set; }

        public string SelectedOption { get; set; }

        public bool IsRequired { get; set; }

        [ForeignKey("Form")]
        public int FormId { get; set; }

        public Form Form { get; set; }
    }
}
