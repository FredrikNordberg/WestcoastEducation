using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace westcoast_education.web.ViewModels
{
    public class CoursePostViewModel
    {
        [Required(ErrorMessage = "Kursnamn är obligatoriskt")]
        [DisplayName("Kursnamn")]
        public string CourseName { get; set;} = "";
        
        [Required(ErrorMessage = "Titel är obligatoriskt")]
        [DisplayName("Titel")]
        public string CourseTitle { get; set; } = "";
        
        [Required(ErrorMessage = "Startdatum är obligatoriskt")]
        [DisplayName("Startdatum")]
        public string CourseStartDate { get; set; } = "";
        
        [Required(ErrorMessage = "Slutdatum är obligatoriskt")]
        [DisplayName("Slutdatum")]
        public string CourseEndDate { get; set; } = "";
        
        [Required(ErrorMessage = "kursnummer är obligatoriskt")]
        [Range(1, int.MaxValue, ErrorMessage = "kursnummer måste vara större än 0.")]
        [DisplayName("Kursnummer")]
        public int CourseId { get;  set; }
    }
}