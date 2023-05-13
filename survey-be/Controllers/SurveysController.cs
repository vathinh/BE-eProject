using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Azure;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using survey_be.Data;
using survey_be.Dtos;
using survey_be.Models;

namespace survey_be.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SurveysController : ControllerBase
    {
        private readonly SurveyDbContext _context;
        private readonly IMapper _mapper;

        public SurveysController(SurveyDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        // GET: api/Surveys
        [HttpGet]
        public async Task<ActionResult<IEnumerable<SurveyDTO>>> GetSurveys()
        {
          if (_context.Surveys == null)
          {
              return NotFound();
          }
          var surveys = await _context.Surveys
                .Include(_=>_.Questions)
                .ThenInclude(_=>_.Answers)
                .ToListAsync();
            var surveyDTOs = _mapper.Map<List<SurveyDTO>>(surveys);
            return Ok(surveyDTOs);
        }

        // GET: api/Surveys/ for roles
        [HttpGet("/role/{id}")]
        public async Task<ActionResult<SurveyDTO>> GetSurveyByRole(int id)
        {
          if (_context.Surveys == null)
          {
              return NotFound();
          }
            var survey = await _context.Surveys
                .Include(_=>_.Questions)
                .ThenInclude(_=>_.Answers)
                .Where(_=>_.UserRoleId == id).ToListAsync();
            var surveyDTO = _mapper.Map<List<SurveyDTO>>(survey);

            if (survey == null)
            {
                return NotFound();
            }

            return Ok(surveyDTO);
        }

        // GET: api/Surveys/ by surveyId
        [HttpGet("{id}")]
        public async Task<ActionResult<SurveyDTO>> GetSurveyById(int id)
        {
            if (_context.Surveys == null)
            {
                return NotFound();
            }
            var survey = await _context.Surveys
                .Include(_ => _.Questions)
                .ThenInclude(_ => _.Answers)
                .Where(_ => _.SurveyId == id).ToListAsync();
            var surveyDTO = _mapper.Map<List<SurveyDTO>>(survey);

            if (survey == null)
            {
                return NotFound();
            }

            return Ok(surveyDTO);
        }



        // PUT: api/Surveys/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut]
        public async Task<IActionResult> PutSurvey(SurveyDTO payloadSurvey)
        {

            try
            {
                var updateSurvey = _mapper.Map<Survey>(payloadSurvey);
                _context.Surveys.Update(updateSurvey);
                await _context.SaveChangesAsync();
                return Ok(updateSurvey);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }

        // POST: api/Surveys
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<SurveyDTO>> PostSurvey(SurveyDTO payloadSurvey)
        {
            try
            {
                if (_context.Surveys == null)
                {
                    return Problem("Entity set 'SurveyDbContext.Surveys'  is null.");
                }
                var newSurvey = _mapper.Map<Survey>(payloadSurvey);
                _context.Surveys.Add(newSurvey);
                await _context.SaveChangesAsync();

                return CreatedAtAction("GetSurveyById", new { id = payloadSurvey.SurveyId }, payloadSurvey);

            } catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
     
        }

        // DELETE: api/Surveys/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteSurvey(int id)
        {
            if (_context.Surveys == null)
            {
                return NotFound();
            }

            var surveyToDelete = await _context
                .Surveys.Include(_ => _.Questions)
                .ThenInclude(_=>_.Answers)
                .Where(_ => _.SurveyId == id)
                .FirstOrDefaultAsync();

            if (surveyToDelete == null)
            {
                return NotFound();
            }
            _context.Surveys.Remove(surveyToDelete);
            await _context.SaveChangesAsync();
            return NoContent();
        }

        private bool SurveyExists(int id)
        {
            return (_context.Surveys?.Any(e => e.SurveyId == id)).GetValueOrDefault();
        }
    }
}
