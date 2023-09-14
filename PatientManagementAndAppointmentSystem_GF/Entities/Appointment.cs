using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PatientManagementAndAppointmentSystem_GF.Entities
{
    public class Appointment : BaseEntity
    { 
        public DateTime AppointmentTime { get; set; }

        public string Location { get; set; }

        //Nav prop

        [ForeignKey("Patient")]
        public long? PatientId { get; set; }
        public Patient Patient { get; set; }
    }
}
