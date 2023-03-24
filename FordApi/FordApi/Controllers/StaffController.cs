using FordApi.Data;
using FordApi.Data.UnitOfWork.Abstract;
using Microsoft.AspNetCore.Mvc;
namespace FordWebApi.Controllers;

[Route("ford/api/v1.0/[controller]")]
[ApiController]
public class StaffController : ControllerBase
{
    private readonly IUnitOfWork unitOfWork;
    public StaffController(IUnitOfWork unitOfWork)
    {
        this.unitOfWork = unitOfWork;
    }
    [HttpGet("GetFilter/{FirstName}/{City}")]
    public IActionResult GetFilter(string FirstName,string City) { 
        var staff1 = unitOfWork.StaffRepository.Where(p => p.FirstName == FirstName && City == City);
        return Ok(staff1);
    }
    [HttpGet]
    public List<Staff> GetAll()
    {
        List<Staff> list = unitOfWork.StaffRepository.GetAll();
        return list;
    }
    [HttpGet("GetById/{id}")]
    public Staff GetById(int id)
    {
        Staff staff1 = unitOfWork.StaffRepository.GetById(id);
        return staff1;
    }
    [HttpPost("Post")]
    public void Post([FromBody] Staff request)
    {
        unitOfWork.StaffRepository.Insert(request);
        unitOfWork.Complete();
    }
    //PUT FromBody'den alır
    [HttpPut("{id}")]
    public void Put(int id, [FromBody] Staff request)
    {
        request.Id = id;
        unitOfWork.StaffRepository.Update(request);
        unitOfWork.Complete();
    }
    [HttpDelete("{id}")]
    public void Delete(int id)
    {
        var staff = unitOfWork.StaffRepository.GetById(id);
        if(staff != null)
        {
            unitOfWork.StaffRepository.Remove(id);
            unitOfWork.Complete();
        }
    }  
}