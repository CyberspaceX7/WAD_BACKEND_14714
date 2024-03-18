using _00014714.Data;
using _00014714.Models;
using Microsoft.EntityFrameworkCore;

namespace _00014714.Repositories
{
    public class CategoryRepository : IRepository<Category>
    {
        private readonly SurveyFormDbContext _dbContext;

        public CategoryRepository(SurveyFormDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task AddAsync(Category categories)
        {
            await _dbContext.Categories.AddAsync(categories);
            await _dbContext.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var entity = await _dbContext.Categories.FindAsync(id);
            if (entity != null)
            {
                _dbContext.Categories.Remove(entity);
                await _dbContext.SaveChangesAsync();
            }
        }

        public async Task<IEnumerable<Category>> GetAllAsync() => await _dbContext.Categories.ToArrayAsync();

        public async Task<Category> GetByIDAsync(int id)
        {
            return await _dbContext.Categories.FirstOrDefaultAsync(c => c.Id == id);
        }

        public async Task UpdateAsync(Category categories)
        {
            _dbContext.Entry(categories).State = EntityState.Modified;
            await _dbContext.SaveChangesAsync();
        }
    }
}
