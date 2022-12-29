namespace westcoast_education.web.Models
{
    public class Teacher
    {
        public int TeacherId { get; set; }
        public string TeacherFirstName { get; set; } = "";
        public string TeacherLastName { get; set; } = "";
        public string TeacherEmail { get; set; } = "";
        public int TeacherPhone { get; set; }
    }
}