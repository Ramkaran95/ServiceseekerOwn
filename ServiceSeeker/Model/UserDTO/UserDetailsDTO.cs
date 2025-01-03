namespace ServiceSeeker.Model
{ // this can be use after successful login of user 
    public class UserDetailsDTO
    {
      
        public required int UserId { get; set; }
        public required string UserName { get; set; }
      
        public required string FirstName { get; set; }
        public string? MiddleName { get; set; }
        public string? LastName { get; set; }
       
        public required int PhoneNumber { get; set; }
       
        public required string Email { get; set; }
        
    


        

    }
}
