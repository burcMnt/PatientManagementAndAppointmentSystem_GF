﻿using PatientManagementAndAppointmentSystem_GF.Entities;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace PatientManagementAndAppointmentSystem_GF.Dtos.Appointment
{
    public class AppointmentAddDto
    {
        [Required(ErrorMessage ="Plese enter appointment date and time")]
        public DateTime AppointmentTime { get; set; }

        [Required(ErrorMessage = "This area is required"), MaxLength(50)]
        public string Location { get; set; }

        public long? PatientId { get; set; }
    }
}
