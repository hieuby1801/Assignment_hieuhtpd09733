using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebAPI.Models
{
    public class PersonalProfile
    {
        public int Id { get; set; }
        [Column(TypeName = "nvarchar(50)")]
        public string Name { get; set; }
        [Column(TypeName = "varchar(13)")]
        [RegularExpression(@"^\d{10,13}$")]
        public string Phone { get; set; }
        [Column(TypeName = "varchar(50)")]
        [RegularExpression(@"^[a-z0-9.]+@[a-z0-9.]+\.[a-z]{2,}$")]
        public string Email { get; set; }
        [Column(TypeName = "varchar(10)")]
        public string Gender { get; set; }
        [Column(TypeName = "nvarchar(200)")]
        public string Address { get; set; }
        public DateTime BirthDate { get; set; }        
        public string? PictureLink { get; set; }
        public Account Account { get; set; }
    }
}
