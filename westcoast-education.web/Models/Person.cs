namespace westcoast_education.web.Models
{
    public class Person
    {
        
        public int PersonId {get; set;} 
        public string PersonUserName {get; set;} = "";
        public string PersonTitle {get; set;} = "";
        public string PersonName { get; set;} = "";
        public string PersonLastName { get; set; } = "";
        public string PersonEmail { get; set; } = "";
        public string PersonPhone { get; set; } = "";
        public string Password {get; set;} = "";
        
    }
}