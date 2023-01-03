namespace westcoast_education.web.Models
{
    public class Course
    {
        public int CourseId {get; set;} 
        public string CourseName { get; set;} = "";
        public string CourseLocation { get; set; } = "";
        public string CourseLanguage { get; set; } = "";
        
    }
}