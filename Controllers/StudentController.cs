using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MySecondApi_With_SQL.Data;
using MySecondApi_With_SQL.Model;

namespace MySecondApi_With_SQL.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {

        private readonly ApplicationDbContext _context;

       

        public StudentController(ApplicationDbContext context)
        {
            _context = context;
        }
        [HttpGet]
        public ActionResult<IEnumerable<Student>> GetAllStudent()
        {
            List<Student> students = _context.Students.ToList();
            return Ok(students);
        }
        //[HttpGet]
        //public ActionResult GetStudent(int id)
        //{
            
        //    Student students = _context.Students.Where(sd=>sd.Id == id ).FirstOrDefault();
        //    return Ok(students);
        //}



        [HttpPost]
        public ActionResult Insert(Student student)
        {
            _context.Students.Add(student);
            _context.SaveChanges();
            return Ok();

        }

        [HttpPut]
        public ActionResult Update(Student student)
        {
            var std = _context.Students.Where(sd => sd.Id == student.Id).FirstOrDefault();
            if(std!=null)
            {
                std.Id = student.Id;
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
