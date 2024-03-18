using Microsoft.AspNetCore.Mvc;
using _00014714.Models;
using _00014714.Repositories;

namespace _00014714.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SurveysController : ControllerBase
    {
        private readonly IRepository<Survey> _surveyRepository;
        public SurveysController(IRepository<Survey> surveyRepository)
        {
            _surveyRepository = surveyRepository;
        }

        // GET: api/Surveys
        [HttpGet]
        public async Task<IEnumerable<Survey>> GetSurveys() => await _surveyRepository.GetAllAsync();


        // GET: api/Surveys/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Survey>> GetSurvey(int id)
        {
            var survey = await _surveyRepository.GetByIDAsync(id);

            if (survey == null)
            {
                return NotFound();
            }

            return Ok(survey);
        }

        // PUT: api/Surveys/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutSurvey(int id, Survey survey)
        {
            if (id != survey.Id)
            {
                return BadRequest();
            }
            await _surveyRepository.UpdateAsync(survey);
            return NoContent();
        }

        // POST: api/Surveys
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Survey>> PostSurvey(Survey survey)
        {
            await _surveyRepository.AddAsync(survey);
            return CreatedAtAction("GetSurvey", new { id = survey.Id }, survey);
        }

        // DELETE: api/Surveys/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteSurvey(int id)
        {
            await _surveyRepository.DeleteAsync(id);
            return NoContent();
        }
    }
}
