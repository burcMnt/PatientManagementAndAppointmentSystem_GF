using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PatientManagementAndAppointmentSystem_GF.Entities
{
    public class Appointment : BaseEntity
    { 
        [Required]
        public DateTime AppointmentTime { get; set; }

        [Required(ErrorMessage = "This area is required"), MaxLength(50)]
        public string Location { get; set; }

        //Nav prop

        [ForeignKey("MedicalHistory")]
        public int? MedicalHistoryId { get; set; }
        public MedicalHistory MedicalHistory { get; set; }

        [ForeignKey("Patient")]
        public int? PatientId { get; set; }
        public Patient Patient { get; set; }
    }
}
