using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Dynamic_Form_Builder.Models
{
    public class DropdownField
    {
        [Key] 
        public int FieldId { get; set; }

        public string Label { get; set; }

        public bool IsRequired { get; set; }

        public string SelectedOption { get; set; }

       
        public int FormId { get; set; }

       
        public Form Form { get; set; }
    }
}
