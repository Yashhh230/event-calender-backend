using System.ComponentModel.DataAnnotations;

namespace EventCalender.Features.User.DTOs
{
    public class AddUserDTO
    {
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? PhoneNumber { get; set; }

        [EmailAddress]
        public string  Email { get; set; }
        public string? Address { get; set; }
    }
}
