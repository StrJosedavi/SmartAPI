using System.ComponentModel.DataAnnotations;

namespace SmartAPI.Application.Models.Request {
    public class GetUserByIdRequest {
        [Required(ErrorMessage = "Necessário UserId")]
        public string UserId { get; set; }
    }
}
