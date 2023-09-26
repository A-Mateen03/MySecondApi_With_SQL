using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MySecondApi_With_SQL.Data;
using MySecondApi_With_SQL.Model;
using NuGet.Protocol;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace MySecondApi_With_SQL.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {

        private readonly ApplicationDbContext _context;
        private readonly JsonSerializerOptions _jsonSerializerOptions;




        public StudentController(ApplicationDbContext context)
        {
            _context = context;

            _jsonSerializerOptions = new  JsonSerializerOptions {     ReferenceHandler = ReferenceHandler.Preserve,};


        }
        [HttpGet]

        public ActionResult<IEnumerable<Student>> GetAllStudent()
        {
            List<Student> students = _context.Students.Include(s => s.Subjects).ToList();

            string  jsonResult = JsonSerializer.Serialize(students, _jsonSerializerOptions);


            return Content(jsonResult,"application/json");


            //return Ok(students);
        }

        [HttpGet("{id}")]
        public ActionResult GetStudent(int id)
        {

            Student students = _context.Students.Where(sd => sd.Id == id).Include(s=> s.Subjects).FirstOrDefault();
            string jsonResult = JsonSerializer.Serialize(students, _jsonSerializerOptions);


            return Content(jsonResult, "application/json");

            //return Ok(students);
        }



        [HttpPost]
        public ActionResult Insert(Student student)
        {
            _context.Students.Add(student);
            _context.SaveChanges();
            return Ok();

        }

        [HttpPut("{id}")]
        public ActionResult Update(int id,Student student)
        {
            var std = _context.Students.Where(sd => sd.Id == id).FirstOrDefault();
            if(std!=null)
            {
                //std.Id = student.Id;
                std.Name = student.Name;
                std.Address = student.Address;
                std.PhoneNo = student.PhoneNo;
                std.Class = student.Class;
            _context.SaveChanges();
                return Ok();
            }
            else
            {
                return NotFound();
            }
       
        }
        
        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            var std = _context.Students.Where(sd => sd.Id == id).FirstOrDefault();
            if(std!=null)
            {
            _context.Students.Remove(std);
            _context.SaveChanges(); 
                return Ok();

            }
            else
            {
                return BadRequest();
            }
                
           

        }




    }
}
