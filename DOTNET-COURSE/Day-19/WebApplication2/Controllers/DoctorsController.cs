using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApplication2.Data;
using WebApplication2.Models;

namespace WebApplication2.Controllers
{
    public class DoctorsController : Controller
    {
        ApplicationDbContext context = new ApplicationDbContext();
        public IActionResult Index()
        {
            var doctors = context.Doctors.ToList();
            return View(doctors);
        }

        public IActionResult Details(int id)
        {
            var doctor = context.Doctors.Find(id);
            return View(doctor);
        }

        public IActionResult CreateNewDoctor()
        {
            return View();
        }

        [HttpPost]
        public IActionResult CreateNewDoctor(Doctor doctor)
        {
            var Doctor = new Doctor();
            Doctor.Name = doctor.Name;
            Doctor.Details = doctor.Details;
            Doctor.Specialization = doctor.Specialization;
            Doctor.Phone = doctor.Phone;
            Doctor.Email = doctor.Email;
            Doctor.Address = doctor.Address;
            doctor.Image = "blabla";

            if (Doctor != null)
            {
                context.Doctors.Add(doctor);
                context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(doctor);
        }


        public IActionResult DeleteDoctor(int id)
        {
            var doctor = context.Doctors.Find(id);
            if (doctor != null)
            {
                context.Doctors.Remove(doctor);
                context.SaveChanges();
                return RedirectToAction("Index");
            }
            return NotFound();
        }

        public IActionResult EditDoctor()
        {
            return View();
        }

        [HttpPost]
        public IActionResult EditDoctor(int id, Doctor doctor)
        {
            var Doctor = context.Doctors.Find(id);
            Doctor.Name = doctor.Name;
            Doctor.Details = doctor.Details;
            Doctor.Specialization = doctor.Specialization;
            Doctor.Phone = doctor.Phone;
            Doctor.Email = doctor.Email;
            Doctor.Address = doctor.Address;
            Doctor.Image = "blabla";

            if (Doctor != null)
            {
                context.Doctors.Update(Doctor);
                context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(doctor);
        }



        [HttpGet]
        public IActionResult MakeAppointment()
        {
            return View();
        }

        [HttpPost]
        public IActionResult MakeAppointment(int id, Appointment appointment)
        {
            //var doctor  = context.Doctors.Find(id);


            Appointment newAppointment = new Appointment();

            newAppointment.PatientName = appointment.PatientName;
            newAppointment.Date = appointment.Date;
            newAppointment.Time = appointment.Time;
            newAppointment.DoctorId = id;
            newAppointment.DoctorName = context.Doctors.Find(id).Name;


            //if (doctor == null)
            //{
            //    return NotFound();
            //}


            if (newAppointment != null)
            {
                context.Appointments.Add(newAppointment);
                context.SaveChanges();
                return RedirectToAction("Index", "Appointment");
            }
            return View(appointment);
        }



    }
}
