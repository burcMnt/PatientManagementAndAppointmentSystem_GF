using AutoMapper;
using PatientManagementAndAppointmentSystem_GF.Dtos.Patient;
using PatientManagementAndAppointmentSystem_GF.Entities;

namespace PatientManagementAndAppointmentSystem_GF
{
    public class AutoMapping :Profile
    {
        public AutoMapping()
        {
            CreateMap<Patient, PatientAddDto>();
            CreateMap<PatientAddDto,Patient>();
        }
    }
}
