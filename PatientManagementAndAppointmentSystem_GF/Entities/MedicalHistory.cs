using System.ComponentModel.DataAnnotations.Schema;

namespace PatientManagementAndAppointmentSystem_GF.Entities
{
    public class MedicalHistory :BaseEntity
    {
        public string PatientHistory { get; set; }
        public DateTime CreatedTime { get; set; }

        //Nav prop

        [ForeignKey("Patient")]
        public long? PatientId { get; set; }
        public Patient Patient { get; set; }

    }
}
