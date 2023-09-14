using AutoMapper;
using Microsoft.AspNetCore.Mvc;
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

        public PatientController(IPatientService patientService, IMapper mapper)
        {
            _patientService = patientService;
            _mapper = mapper;
        }

        //You can use the HttpGet request to take all Patientlist
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var result = await _patientService.ListAll();
            return Ok(result);

        }

        //You can use this HttpGet request with id  to get just one patient object.
        //https://localhost
        [HttpGet("{id}")]
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
        [HttpPost]
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
        [HttpDelete("{id}")]
        public IActionResult Delete(long id)
        {
            _patientService.Delete(id);
            return NoContent();
        }

        //You can use this HttpPut request to update patient's object already have with using unique id.
        //https://localhost:
        [HttpPut("{id}")]
        public IActionResult Update([FromRoute] long id, [FromBody] PatientUpdateDto patientDto)
        {
            if (id != patientDto.Id)
            {
                return BadRequest("Id information is not confirmed");
            }
            var patient = _mapper.Map<Patient>(patientDto);

            _patientService.Update(patient);
            return Ok();
        }
    }
}
