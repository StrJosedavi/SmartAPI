using System.ComponentModel.DataAnnotations;

namespace SmartAPI.Application.Models.Request {
    public class GetUserByIdRequest {
        [Required(ErrorMessage = "Necessário UserId")]
        [Range(1, long.MaxValue)]
        public long UserId { get; set; }
    }
}
