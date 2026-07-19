using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApplication2.Models
{
    public class Appointment
    {
        [Key]
        public int Id { get; set; }
        public string PatientName { get; set; } = null!;
        public string Date { get; set; } = null!;
        public string Time { get; set; } = null!;

        public string DoctorName { get; set; } = null!;

        // Navigation property
        public int DoctorId { get; set; }
        [ForeignKey("DoctorId")]
        public Doctor Doctor { get; set; } = null!;


    }
}
