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
[Route("Registration")]
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
        [Route("Login")]
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
        
        [HttpPut]
        [Route("Update")]
        public ActionResult UserUpdate(int id, UsersDTO userdto){
            
            if (!ModelState.IsValid){
                return BadRequest(ModelState);
            }
            var user= _dbcontext.Users.FirstOrDefault(x => x.UserId== id);
            // Update only the provided properties
    if (!string.IsNullOrEmpty(userdto.UserName))
    {
        if (user.userName==userdto.userName){
            user.UserName = userdto.UserName;
            
           
        }
        var existingUser= _dbcontext.Users.FirstOrDefault(x => x.UserName == usersDTO.UserName);
            if (existingUser != null){
                
                return BadRequest("username not available..");
                
            }
        user.UserName = userdto.UserName;
    }

    if (!string.IsNullOrEmpty(userdto.FirstName))
    {
        user.FirstName = userdto.FirstName;
    }

    if (!string.IsNullOrEmpty(userdto.LastName))
    {
      user.LastName = userdto.LastName;
    }

    if (!string.IsNullOrEmpty(userdto.MiddleName))
    {
      user.MiddleName = userdto.MiddleName;
    }

    if (userdto.PhoneNumber != 0)
    {
        user.PhoneNumber = userdto.PhoneNumber;
    }

    if (!string.IsNullOrEmpty(userdto.Email))
    {
        if (user.userEmail==userdto.userEmail){
            user.Email = userdto.Email;
            
           
        }
        var existingUser= _dbcontext.Users.FirstOrDefault(x => x.Email == usersDTO.Email);
            if (existingUser != null){
                
                return BadRequest("email already registered..");
                
            }
        
        user.Email = userdto.Email;
    }

    // Save the changes to the database
    _dbcontext.SaveChanges();

    return Ok(new { Message = "User updated successfully." });
}
            
            
            
        }

    }
}
