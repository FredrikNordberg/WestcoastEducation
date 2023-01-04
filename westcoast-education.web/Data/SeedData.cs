using System.Text.Json;
using westcoast_education.web.Models;

namespace westcoast_education.web.Data
{
    public static class SeedData
    {
        public static async Task LoadCourseData(WestcoastEducationContext context)
        {
            var options = new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            };

            // Vill endast ladda data om databasens tabell är tom...
            if (context.Courses.Any()) return;

            if (context.Persons.Any()) return;

            // Läsa in jason datat...
            var json = System.IO.File.ReadAllText("Data/json/courses.json");
            var jsonPersons = System.IO.File.ReadAllText("Data/json/persons.json");
            // Konvertera json objekten till en lista av Course objekt...
            var courses = JsonSerializer.Deserialize<List<Course>>(json, options);
            var persons = JsonSerializer.Deserialize<List<Person>>(jsonPersons, options);

            if (courses is not null && courses.Count > 0)
            {
                await context.Courses.AddRangeAsync(courses);
                await context.SaveChangesAsync();
            }

             if (persons is not null && persons.Count > 0)
            {
                await context.Persons.AddRangeAsync(persons);
                await context.SaveChangesAsync();
            }
        }
    }
}