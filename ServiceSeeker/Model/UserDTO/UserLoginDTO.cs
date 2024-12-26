

namespace ServiceSeeker.Model
{
    public class UserLoginDTO(){
        
        [EmailAddress]
        public required string Email { get; set; }
       
        [MinLength(8)]
        public required int Password { get; set; }
        
        
    }
    
    
}