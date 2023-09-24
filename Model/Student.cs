using System.ComponentModel.DataAnnotations;

namespace MySecondApi_With_SQL.Model
{
    public class Student
    {
        [Key]
        public int Id { get; set; }
        public required string Name { get; set; }
        public required string Class { get; set; }
        
        public required string PhoneNo { get; set; }

        public required string Address { get; set; }
    }
}
