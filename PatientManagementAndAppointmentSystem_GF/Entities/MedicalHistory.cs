using System.ComponentModel.DataAnnotations.Schema;

namespace PatientManagementAndAppointmentSystem_GF.Entities
{
    public class MedicalHistory :BaseEntity
    {
        public string PatientHistory { get; set; }

        //Nav prop
        public Appointment Appointment { get; set; }



        [ForeignKey("Patient")]
        public long? PatientId { get; set; }
        public Patient Patient { get; set; }

    }
}
