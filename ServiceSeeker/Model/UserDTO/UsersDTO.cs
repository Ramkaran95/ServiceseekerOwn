



namespace ServiceSeeker.Model
{
    public class UsersDTO
    {
       [MaxLength(10)]
        public required string UserName { get; set; }
        [MaxLength(15)]
        public required string FirstName { get; set; }
        public string? MiddleName { get; set; }=null;
        public string? LastName { get; set; }=null;
        [Phone]
        public required int PhoneNumber { get; set; }
        [EmailAddress]
        public required string Email { get; set; }
    
[MinLength(8)]
        public required int Password { get; set; }

        

    }
}
