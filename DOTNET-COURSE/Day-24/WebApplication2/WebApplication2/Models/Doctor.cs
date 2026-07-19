using System.ComponentModel.DataAnnotations;

namespace WebApplication2.Models
{
    public class Doctor
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public string Details { get; set; } = null!;
        public string Specialization { get; set; } = null!;
        public string Image { get; set; } = null!;
        public string? Address { get; set; }
        public string? Phone { get; set; }
        public string? Email { get; set; }


        // Navigation
        public ICollection<Appointment> Appointments { get; set; } = null!;
    }
}
