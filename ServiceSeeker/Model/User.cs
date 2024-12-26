

using System.ComponentModel.DataAnnotations;

namespace ServiceSeeker.Model
{
    public class User
    {
        public required int UserId { get; set; }
        public required string UserName { get; set; }
        public required string FirstName { get; set; };
        public string? MiddleName { get; set; }=null;
        public  string? LastName { get; set; }=null;
        [Phone]
        [MinLength(10)]
        public required int PhoneNumber { get; set; }

        [EmailAddress]
        public required string Email { get; set; }
        [MinLength(8)]
        public required int Password { get; set; }
        //public String? ProfilePhoto { get; set; } ="Default.jpg";

        public required DateTime CreatAt { get; set; }=DateTime.Now; 

    }
}
