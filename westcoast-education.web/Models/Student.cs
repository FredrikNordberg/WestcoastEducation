namespace westcoast_education.web.Models
{
    public class Student
    {
        public int StudentId { get; set; }
        public string StudentFirstName { get; set; } = "";
        public string StudentLastName { get; set; } = "";
        public string StudentEmail { get; set; } = "";
        public int StudentPhone { get; set; }
    }
}