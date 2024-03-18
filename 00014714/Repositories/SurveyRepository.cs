using _00014714.Data;
using _00014714.Models;
using Microsoft.EntityFrameworkCore;

namespace _00014714.Repositories
{
    // Repository class for handling CRUD operations for survey entities.
    public class SurveyRepository : IRepository<Survey>
    {
        // Constructor for SurveyRepository class.
        private readonly SurveyFormDbContext _dbContext;

        public SurveyRepository(SurveyFormDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        // Adds a new survey entity to the database.
        public async Task AddAsync(Survey entity)
        {
            entity.Category = await _dbContext.Categories.FindAsync(entity.CategoryId.Value);

            await _dbContext.Surveys.AddAsync(entity);
            await _dbContext.SaveChangesAsync();
        }

        // Deletes a survey entity from the database by its id.
        public async Task DeleteAsync(int id)
        {
            var entity = await _dbContext.Surveys.FindAsync(id);
            if (entity != null)
            {
                _dbContext.Surveys.Remove(entity);
                await _dbContext.SaveChangesAsync();
            }
        }

        // Retrieves all survey entities from the database.
        public async Task<IEnumerable<Survey>> GetAllAsync()
        {
            return await _dbContext.Surveys.Include(s => s.Category).ToArrayAsync();
        }

        // Retrieves a survey entity from the database by its id.
        public async Task<Survey> GetByIDAsync(int id)
        {
            return await _dbContext.Surveys.Include(s => s.Category).FirstOrDefaultAsync(s => s.Id == id);
        }

        // Updates an existing survey entity in the database.
        public async Task UpdateAsync(Survey entity)
        {
            _dbContext.Entry(entity).State = EntityState.Modified;
            await _dbContext.SaveChangesAsync();
        }
    }
}
