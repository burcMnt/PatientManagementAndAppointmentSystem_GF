namespace PatientManagementAndAppointmentSystem_GF.Dtos.History
{
    public class HistoryAddDto
    {
        public string PatientHistory { get; set; }
        public DateTime CreatedTime { get; set; }

        public long? PatientId { get; set; }
    }
}
