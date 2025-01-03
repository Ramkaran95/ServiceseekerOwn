
namespace ServiceSeeker.Model
{
    // use when user wanted to reset password 
public class ResetPasswordDto
{
    public string Email { get; set; }
    public string Otp { get; set; }
    public string NewPassword { get; set; }
}
}