using System.ComponentModel.DataAnnotations;

namespace PatientManagementAndAppointmentSystem_GF.Entities
{
    public class Patient : BaseEntity
    {

        public string NationalId { get; set; }

        public string Name { get; set; }

        public string Surname { get; set; }

        public string Gender { get; set; }

        public string Birthdate { get; set; }

        public string PhoneNumber { get; set; }

        public string Email { get; set; }


        //Nav prop

        public List<Appointment> Appointments { get; set; }
        public List<MedicalHistory> MedicalHistories { get; set; }

    }
}
