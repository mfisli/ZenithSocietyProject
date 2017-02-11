using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZenithDataLib.Models
{
    public class Event
    {
        public int EventId { get; set; }

        [Required]
        [Display(Name = "Start Time")]
        [StartEndDateValidator]
        public DateTime Start { get; set; }

        [Required]
        [Display(Name = "End Time")]
        public DateTime End { get; set; }

        [Required]
        [Display(Name = "Created By")]
        public string CreatedBy { get; set; }

        [Required]
        [Display(Name = "Activity ID")]
        public int ActivityId { get; set; }

        public virtual Activity Activity { get; set; }

        [Required]
        [Display(Name = "Creation Date")]
        public DateTime CreationDate { get; set; }

        [Display(Name = "Is Active")]
        public bool IsActive { get; set; }
    }

    public class StartEndDateValidator : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var model = (Models.Event)validationContext.ObjectInstance;
            DateTime EndDate = Convert.ToDateTime(model.End);
            DateTime StartDate = Convert.ToDateTime(value);

            if (StartDate > EndDate)
            {
                return new ValidationResult("The start date must be anterior to the end date");
            }
            else if (StartDate == EndDate)
            {
                return new ValidationResult("The start date and end date cannot be the same");
            }
            else
            {
                return ValidationResult.Success;
            }
        }
    }
}
