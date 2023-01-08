namespace westcoast_education.web.ViewModels
{
    public class CourseListViewModel
    {
        public int CourseId {get; set;} 
        public string CourseNumber { get; set; } = "";
        public string CourseName { get; set;} = "";
        public string CourseTitle { get; set; } = "";
        public string CourseStartDate { get; set; } = "";
        public string CourseEndDate { get; set; } = "";
    }
}