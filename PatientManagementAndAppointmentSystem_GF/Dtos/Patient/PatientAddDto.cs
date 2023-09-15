using System.ComponentModel.DataAnnotations;

namespace PatientManagementAndAppointmentSystem_GF.Dtos.Patient
{
    public class PatientAddDto
    {
        
        [Required]
        [RegularExpression("^[1-9]{1}[0-9]{9}[02468]{1}$", ErrorMessage = "Please enter your 11-digit national Id number. ")]
        public string NationalId { get; set; }

        [Required(ErrorMessage = "This area is required"), MaxLength(30)]
        public string Name { get; set; }

        [Required(ErrorMessage = "This area is required"), MaxLength(30)]
        public string Surname { get; set; }

        [Required]
        [RegularExpression("(M|F|N)", ErrorMessage = "This field accept only one character that might be ' M ' (Male) or ' F '(Female) or ' N ' (Not defined).")]
        public string Gender { get; set; }

        [Required]
        [RegularExpression("^([012]\\d|30|31)/(0\\d|10|11|12)/\\d{4}$", ErrorMessage ="Please enter your birthdate in this format DD/MM/YYYY ")]
        public string Birthdate { get; set; }

        [RegularExpression("^(05)([0-9]{2})\\s?([0-9]{3})\\s?([0-9]{2})\\s?([0-9]{2})$",ErrorMessage ="Please enter your phone number in this format 05xxXXXxxXX")]
        public string PhoneNumber { get; set; }

        [RegularExpression("^([\\w\\.\\-]+)@([\\w\\-]+)((\\.(\\w){2,3})+)$", ErrorMessage = "Please enter your email in this format example@examle.com .")]
        public string Email { get; set; }
    }
}
