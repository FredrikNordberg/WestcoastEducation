using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace westcoast_education.web.ViewModels.Persons
{
    public class PersonPostViewModel
    {
        
        
        
        public int PersonId {get; set;} 
        
        [Required(ErrorMessage = "Användarnamn är obligatoriskt")]
        [DisplayName("Användarnamn")]
        public string PersonUserName {get; set;} = "";

        [Required(ErrorMessage = "Titel är obligatoriskt")]
        [DisplayName("Titel")]
         public string PersonTitle {get; set;} = "";

        [Required(ErrorMessage = "Förnamn är obligatoriskt")]
        [DisplayName("Förnamn")]
        public string PersonName { get; set;} = "";

        [Required(ErrorMessage = "Efternamn är obligatoriskt")]
        [DisplayName("Efternamn")]
        public string PersonLastName { get; set; } = "";

        [Required(ErrorMessage = "Email är obligatoriskt")]
        [DisplayName("Email")]
        public string PersonEmail { get; set; } = "";

        [Required(ErrorMessage = "Mobilnummer är obligatoriskt")]
        [DisplayName("Mobil")]
        public string PersonPhone { get; set; } = "";

        [Required(ErrorMessage = "Ett standard lösenord är obligatoriskt")]
        [DisplayName("Temporärt lösenord")]
        public string Password { get; set; } = "";
    }
}