using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using PatientManagementAndAppointmentSystem_GF.Dtos.History;
using PatientManagementAndAppointmentSystem_GF.Dtos.Patient;
using PatientManagementAndAppointmentSystem_GF.Entities;
using PatientManagementAndAppointmentSystem_GF.Interfaces;

namespace PatientManagementAndAppointmentSystem_GF.Controllers
{
    [Route("api/v1/patient")]
    [ApiController]
    public class PatientController : ControllerBase
    {
        private readonly IPatientService _patientService;
        private readonly IMapper _mapper;
        private readonly IHistoryService _historyService;

        public PatientController(IPatientService patientService, IMapper mapper,IHistoryService historyService)
        {
            _patientService = patientService;
            _mapper = mapper;
            _historyService = historyService;
        }

        //You can use the HttpGet request to take all Patientlist
        [HttpGet("GetAllPatients")]
        public async Task<IActionResult> GetAll()
        {
            var result = await _patientService.ListAll();
            return Ok(result);

        }

        //You can use this HttpGet request with id  to get just one patient object.
        //https://localhost
        [HttpGet("GetPatientById/{id}")]
        public async Task<IActionResult> Get(long id)
        {

            var result = await _patientService.GetById(id);
            if (result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }

        //You can use this HttpPost request to create new patient's object.
        //https://localhost:7223/api/v1/patient
        [HttpPost("CreateNewPatient")]
        public IActionResult Add([FromBody] PatientAddDto patientDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest("Invalid data.");
            }
            var patient = _mapper.Map<Patient>(patientDto);

            var Result = _patientService.Add(patient);
            return CreatedAtAction("Get", new { Id = Result.Id }, patientDto);

        }

        //You can use this HttpDelete request to delete patient's object already have with using unique id.
        //https://localhost:
        [HttpDelete("DeletePatient/{id}")]
        public IActionResult Delete(long id)
        {
            _patientService.Delete(id);
            return NoContent();
        }

        //You can use this HttpPut request to update patient's object already have with using unique id.
        //https://localhost:
        [HttpPut("UpdatePatient/{id}")]
        public IActionResult Update([FromQuery] long id, [FromBody] PatientUpdateDto patientDto)
        {
            if (id != patientDto.Id)
            {
                return BadRequest("Id information is not confirmed");
            }
            var patient = _mapper.Map<Patient>(patientDto);

            _patientService.Update(patient);
            return Ok();
        }

        //You can use this HttpPost request to create new history object.
        //https://localhost:
        [HttpPost("AddPatientHistory")]
        public IActionResult AddPatientHistory([FromBody] HistoryAddDto historyDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest("Invalid data.");
            }
            var history = _mapper.Map<MedicalHistory>(historyDto);

            var Result = _historyService.Add(history);
            return CreatedAtAction("Get", new { Id = Result.Id }, historyDto);

        }

        //You can use this HttpDelete request to delete patient's object already have with using unique id.
        //https://localhost:

        [HttpDelete("DeletePatientHistory")]
        public IActionResult DeletePatientHistory(long id,long patientId)
        {
            _historyService.Delete(id,patientId);
            return NoContent();
        }

        //You can use this HttpPut request to update object already have with using unique id.
        //https://localhost:
        [HttpPut("UpdatePatientHistory")]
        public IActionResult UpdatePatientHistory([FromQuery] long id, [FromBody] HistoryUpdateDto historyDto)
        {
            if (id != historyDto.Id)
            {
                return BadRequest("Id information is not confirmed");
            }
            var history = _mapper.Map<MedicalHistory>(historyDto);

            _historyService.Update(history);
            return Ok();
        }

        //You can use the HttpGet request to take all list
        [HttpGet("GetAllPatientHistory")]
        public IActionResult GetAllPatientHistory(long patientId)
        {
            var result = _patientService.GetAllPatientsHistory(patientId);
            if (result == null)
            {
                return NotFound();
            }

            return Ok(result);

        }

        //You can use this HttpGet request with id  to get just one object.
        //https://localhost
        [HttpGet("GetPatientHistoryById")]
        public async Task<IActionResult> GetPatientHistory(long id)
        {

            var result = await _historyService.GetById(id);
            if (result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }

        //You can use the HttpGet request to take all list
        [HttpGet("GetAllPatientAppointment")]
        public IActionResult GetAllPatientAppointment(long patientId)
        {
            var result = _patientService.GetAllPatientAppointment(patientId);
            if (result == null)
            {
                return NotFound();
            }

            return Ok(result);

        }

    }
}
