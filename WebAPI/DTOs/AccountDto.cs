using System.ComponentModel.DataAnnotations.Schema;

namespace WebAPI.DTOs
{
    public class AccountDto
    {
        public int Id { get; set; }
        [Column(TypeName = "varchar(15)")]
        public string UserName { get; set; }
        [Column(TypeName = "varchar(15)")]
        public string Password { get; set; }
        public int StatusCode { get; set; }
        public int ProfileId { get; set; }
    }
}
