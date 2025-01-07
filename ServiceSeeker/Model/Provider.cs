using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ServiceSeeker.Model
{
    public class Provider
    {
        [Key]
        public int ProviderId { get; set; }

        [Required, MaxLength(100)]
        [Index(IsUnique = true)] // Makes UserName unique
        public string UserName { get; set; }

        [Required, MaxLength(100)]
        public string Password { get; set; }

        [Required, MaxLength(100)]
        public string FirstName { get; set; }

        [MaxLength(100)]
        public string? MiddleName { get; set; }

        [MaxLength(100)]
        public string? LastName { get; set; }

        [MaxLength(255)]
        public string? ProfilePhoto { get; set; } = "default.jpg";

        [Required, MaxLength(15)]
        public string PhoneNumber { get; set; }

        [Required, MaxLength(255)]
        [Index(IsUnique = true)] // Makes Email unique
        public string Email { get; set; }

        [Required]
        public DateTime CreateAt { get; set; } = DateTime.UtcNow;

        [Required, MaxLength(100)]
        public string ProfessionType { get; set; }

        public int? YearOfEx { get; set; }

        [Required, MaxLength(1000)]
        public string Bio { get; set; }

        [MaxLength(255)]
        public string? LanguageSpoke { get; set; }

        [MaxLength(255)]
        public string? SocialLink1 { get; set; }

        [MaxLength(255)]
        public string? SocialLink2 { get; set; }

        [MaxLength(100)]
        public string? TimeOfService { get; set; }

        [MaxLength(255)]
        public string? AreaServe { get; set; }

        [Required]
        public bool Availability { get; set; }

        [MaxLength(255)]
        public string? Skill1 { get; set; }

        [MaxLength(255)]
        public string? Skill2 { get; set; }

        [MaxLength(255)]
        public string? Skill3 { get; set; }

        [MaxLength(255)]
        public string? ServiceName1 { get; set; }

        public decimal? ServicePrice1 { get; set; }

        [MaxLength(255)]
        public string? ServiceImage1 { get; set; }

        [MaxLength(255)]
        public string? ServiceName2 { get; set; }

        public decimal? ServicePrice2 { get; set; }

        [MaxLength(255)]
        public string? ServiceImage2 { get; set; }

        [MaxLength(255)]
        public string? ServiceName3 { get; set; }

        public decimal? ServicePrice3 { get; set; }

        [MaxLength(255)]
        public string? ServiceImage3 { get; set; }

        [Required, MaxLength(100)]
        public string State { get; set; }

        [Required, MaxLength(100)]
        public string District { get; set; }

        [Required, MaxLength(6)]
        public int PinCode { get; set; }

        [Required, MaxLength(100)]
        public string City { get; set; }

        [Required, MaxLength(20)]
        public string Longitude { get; set; }

        [Required, MaxLength(20)]
        public string Latitude { get; set; }
        
        public string? Otp { get; set; }=null;

        public DateTime? OtpExpiry { get; set; }=null;
    }
}
