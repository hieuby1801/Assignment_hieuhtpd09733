using System.ComponentModel.DataAnnotations.Schema;

namespace WebAPI.Models
{
    public class LoginRequest
    {
        public int? Id { get; set; }
        [Column(TypeName = "varchar(15)")]
        public string UserName { get; set; }
        [Column(TypeName = "varchar(15)")]
        public string Password { get; set; }
    }
}
