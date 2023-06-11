using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp1.Models
{
    public class DoctorReport
    {
        [Key]
        [ForeignKey("Patient")]
        public int Id { get; set; }
        [Required]
        public string PatientName { get; set; }
        [Required]
        public string ChiefComplaint { get; set; }
        [Required]
        public string DateOfBirth { get; set; }
        [Required]
        public string Date { get; set; }
        [Required]
        public bool IsSurgeryRequired { get; set; }
        public string DateOfSurgery { get; set; }
        [Required]
        public string MedicalString { get; set; }
        [Required]
        public bool AnyPastSurgeries { get; set; }
        public string Hospitals { get; set; }
        public string Years { get; set; }
        public string Complications { get; set; }
        [Required]
        public string Diagnosis { get; set; }
        [Required]
        public bool AnyMedication { get; set; }
        public string Medications { get; set; } 
        public string AdditionalNotes { get; set; } 
        
        public virtual Patient Patient { get; set; }

    }

}
