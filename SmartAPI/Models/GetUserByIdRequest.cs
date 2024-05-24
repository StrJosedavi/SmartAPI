using System.ComponentModel.DataAnnotations;

namespace SmartAPI.Models
{
    public class GetUserByIdRequest
    {
        [Required(ErrorMessage = "Necessário UserId")]
        [Range(1, long.MaxValue)]
        public long UserId { get; set; }
    }
}
