namespace PatientManagementAndAppointmentSystem_GF.Dtos.History
{
    public class HistoryUpdateDto
    {
        public long Id { get; set; }
        public string PatientHistory { get; set; }
        public DateTime CreatedTime { get; set; }

        public long? PatientId { get; set; }
    }
}
