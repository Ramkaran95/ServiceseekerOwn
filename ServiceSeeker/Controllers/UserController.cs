using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using ServiceSeeker.Data;
using ServiceSeeker.Model;

namespace ServiceSeeker.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        
        private readonly ServiceSeekerDB _dbcontext;

        public UserController(ServiceSeekerDB dbcontext)
        {
            this._dbcontext = dbcontext;
        }
        
        
        [HttpGet]
        public ActionResult GetUser()
        
        {
            var allUser =_dbcontext.Users.ToList();
            return Ok(allUser);
        }
        
        
        [HttpPost]
[Route("userRegistration")]
        public ActionResult UserReg(UsersDTO usersDTO) 
        {
            if (usersDTO==null){
                
                return BadRequest("Invalid data..!");
                
                
            }
            //ModelState.IsValid return false value when user send invalid data.
            //It ensure the data integrity of incoming requests in Web APIs.
            if (!ModelState.IsValid){
                return BadRequest(ModelState);
            }
            //FirstOrDefault Retrieves the first user that matches a condition or returns null if no match is found.
            var existingUser= _dbcontext.Users.FirstOrDefault(x => x.Email == usersDTO.Email);
            if (existingUser != null){
                
                return BadRequest("User already exists with same email address");
                
            }
            
            var data = new User() {
             
                UserName = usersDTO.UserName,
                Email = usersDTO.Email,
                FirstName = usersDTO.FirstName,
                LastName = usersDTO.LastName,
                MiddleName = usersDTO.MiddleName,
                Password = usersDTO.Password,
                PhoneNumber = usersDTO.PhoneNumber
            }; 


            _dbcontext.Users.Add(data);
            _dbcontext.SaveChanges();
            

         return Ok("Registration done successfully");
        }
        
        [HttpPost]
        [Route("userLogin")]
        public ActionResult UserLogin(UserLoginDTO loginDto){
            
            var userdata= _dbcontext.Users.FirstOrDefault(x => x.Email==loginDto.Email && x.password== loginDto.password);
            
            
            if (userdata== null){
                
                return BadRequest("Invalid email or password");
            }
            var details= new UserDetailsDTO(){
                UserName=userdata.UserName,
                UserId=userdata.UserId,
                FirstName = userdata.FirstName,
                MiddleName =userdata.MiddleName ,
                LastName = userdata.LastName,
                Email = userdata.Email,
                PhoneNumber=userdata.PhoneNumber
            };
           
            
            return Ok(message="Login Successful.",user=details);
            
            
           
            
            
            
        }

    }
}
