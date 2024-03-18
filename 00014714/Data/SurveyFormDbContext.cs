using _00014714.Models;
using Microsoft.EntityFrameworkCore;

namespace _00014714.Data
{
    public class SurveyFormDbContext : DbContext
    {
        // Constructor to initialize the context with provided SurveyFormDbContext.
        public SurveyFormDbContext(DbContextOptions<SurveyFormDbContext> options) : base(options) { }

        // Storing Survey entities in the database.
        public DbSet<Survey> Surveys { get; set; }

        // Storing Category entities in the database.
        public DbSet<Category> Categories { get; set; }
    }
}
