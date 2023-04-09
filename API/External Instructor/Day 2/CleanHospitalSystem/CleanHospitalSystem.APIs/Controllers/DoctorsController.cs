using CleanHospitalSystem.BL;
using CleanHospitalSystem.BL.Dtos;
using CleanHospitalSystem.DAL;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CleanHospitalSystem.APIs.Controllers;

[Route("api/[controller]")]
[ApiController]
public class DoctorsController : ControllerBase
{
    private readonly IDoctorsManager _doctorsManager;

    public DoctorsController(IDoctorsManager doctorsManager)
    {
        _doctorsManager = doctorsManager;
    }

    [HttpGet]
    public ActionResult<List<DoctorReadDto>> GetAll()
    {
        return _doctorsManager.GetAll().ToList();
    }

    [HttpGet]
    [Route("{id}")]
    public ActionResult<DoctorDetailsReadDto> GetAll(int id)
    {
        //I need a method to take ID and return possible doctorReadDto
        DoctorDetailsReadDto? doctor = _doctorsManager.GetDetailsById(id);

        if (doctor is null)
        {
            return NotFound();
        }
        return doctor;
    }


    [HttpPost]
    public ActionResult AssignPatientsToDoctor(AssignPatientsToDoctorDto assignPatientsDto)
    {
        _doctorsManager.AssignPatientsToDoctor(assignPatientsDto);
        return NoContent();
    }
}
