using AutoMapper;
using PatientManagementAndAppointmentSystem_GF.Dtos.Appointment;
using PatientManagementAndAppointmentSystem_GF.Dtos.History;
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
            CreateMap<Patient, PatientUpdateDto>();
            CreateMap<PatientUpdateDto, Patient>();

            CreateMap<MedicalHistory, HistoryAddDto>();
            CreateMap<HistoryAddDto , MedicalHistory>();
            CreateMap<MedicalHistory, HistoryUpdateDto>();
            CreateMap<HistoryUpdateDto,MedicalHistory>();

            CreateMap<Appointment, AppointmentAddDto>();
            CreateMap<AppointmentAddDto, Appointment>();
            CreateMap<Appointment, AppointmentUpdateDto>();
            CreateMap<AppointmentUpdateDto, Appointment>();




        }
    }
}
