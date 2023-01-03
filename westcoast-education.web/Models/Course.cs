namespace westcoast_education.web.Models
{
    public class Course
    {
        public int CourseId {get; set;} 
        public string CourseName { get; set;} = "";
        public string? CourseTitle { get; set; } = "";
        public string? CourseStartDate { get; set; } = "";
        public string? CourseEndDate { get; set; } = "";
        
    }
}