using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PatientManagementAndAppointmentSystem_GF.Dtos.Appointment;
using PatientManagementAndAppointmentSystem_GF.Dtos.Patient;
using PatientManagementAndAppointmentSystem_GF.Entities;
using PatientManagementAndAppointmentSystem_GF.Interfaces;
using PatientManagementAndAppointmentSystem_GF.Services;

namespace PatientManagementAndAppointmentSystem_GF.Controllers
{
    [Route("api/v1/appointment")]
    [ApiController]
    public class AppointmentController : ControllerBase
    {
        private readonly IAppointmentService _appointmentService;
        private readonly IMapper _mapper;

        public AppointmentController(IAppointmentService appointmentService, IMapper mapper)
        {
            _appointmentService = appointmentService;
            _mapper = mapper;
        }


        //You can use the HttpGet request to take all tlist
        [HttpGet("GetAllAppointment")]
        public async Task<IActionResult> GetAll()
        {
            var result = await _appointmentService.ListAll();
            return Ok(result);

        }

        //You can use this HttpGet request with id  to get just one object.
        //https://localhost
        [HttpGet("GetAppointmentById")]
        public async Task<IActionResult> Get([FromQuery]long appointmentId)
        {

            var result = await _appointmentService.GetById(appointmentId);
            if (result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }

        //You can use this HttpPost request to create new  object.
        //https://localhost:
        [HttpPost("CreateAppointment")]
        public IActionResult Add([FromBody] AppointmentAddDto appointmentDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest("Invalid data.");
            }
            var appointment = _mapper.Map<Appointment>(appointmentDto);

            var Result = _appointmentService.Add(appointment);
            return CreatedAtAction("Get", new { Id = Result.Id }, appointmentDto);

        }

        //You can use this HttpDelete request to delete object already have with using unique id.
        //https://localhost:
        [HttpDelete("DeleteAppointment")]
        public IActionResult Delete([FromQuery]long appointmentId)
        {
            _appointmentService.Delete(appointmentId);
            return NoContent();
        }

        //You can use this HttpPut request to update object already have with using unique id.
        //https://localhost:
        [HttpPut("UpdateAppointment")]
        public IActionResult Update([FromQuery] long appointmentId, [FromBody] AppointmentUpdateDto appointmentDto)
        {
            if (appointmentId != appointmentDto.Id)
            {
                return BadRequest("Id information is not confirmed");
            }
            var appointment = _mapper.Map<Appointment>(appointmentDto);

            _appointmentService.Update(appointment);
            return Ok();
        }
    }
}

