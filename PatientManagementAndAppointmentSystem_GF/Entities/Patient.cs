using System.ComponentModel.DataAnnotations;

namespace PatientManagementAndAppointmentSystem_GF.Entities
{
    public class Patient : BaseEntity
    {

        [Required]
        [RegularExpression("^[1-9]{1}[0-9]{9}[02468]{1}$", ErrorMessage = "Lütfen 11 haneli Tc kimlik numarası giriniz.")]
        public string NationalId { get; set; }

        [Required(ErrorMessage = "This area is required"), MaxLength(30)]
        public string Name { get; set; }

        [Required(ErrorMessage = "This area is required"), MaxLength(30)]
        public string Surname { get; set; }

        [Required]
        [RegularExpression("(M|F|N)", ErrorMessage = "You can enter only one character that is  ' M ' (Male) or ' F '(Female) or ' N ' (Not defined).")]
        public string Gender { get; set; }

        [Required]
        [RegularExpression("^([1-9]|[12][0-9]|3[01])(|\\/|\\.|\\-|\\s)?(0[1-9]|1[12])\\2(19[0-9]{2}|200[0-9]|201[0-8])$")]
        public string Birthdate { get; set; }

        [RegularExpression("^(05)([0-9]{2})\\s?([0-9]{3})\\s?([0-9]{2})\\s?([0-9]{2})$")]
        public string PhoneNumber { get; set; }

        [RegularExpression("^([\\w\\.\\-]+)@([\\w\\-]+)((\\.(\\w){2,3})+)$")]
        public string Email { get; set; }


        //Nav prop

        public List<Appointment> Appointments { get; set; }
        public List<MedicalHistory> MedicalHistories { get; set; }

    }
}
