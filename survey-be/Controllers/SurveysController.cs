using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Reflection.Metadata;
using System.Threading.Tasks;
using AutoMapper;
using Azure;
using CodeFirstDemo.Filter;
using CodeFirstDemo.Helpers;
using CodeFirstDemo.Services;
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
        private readonly IUriService _uriService;


        public SurveysController(SurveyDbContext context, IMapper mapper, IUriService uriService)
        {
            _context = context;
            _mapper = mapper;
            _uriService = uriService;

        }

        // GET: api/Surveys
        [HttpGet]
        public async Task<ActionResult<IEnumerable<SurveyDTO>>> GetSurveys([FromQuery] PaginationFilter filter)
        {
            if (_context.Surveys == null)
          {
                return NotFound(new Models.HttpResponseError
                {
                    status = HttpStatusCode.NotFound,
                    title = "Get data fail",
                    data = null
                });
            }
            var route = Request.Path.Value;
            var validFilter = new PaginationFilter(filter.PageNumber, filter.PageSize);

            var surveys = await _context.Surveys
                .Include(_ => _.Questions)
                .ThenInclude(_ => _.Answers)
                .ToListAsync();

            var surveyDTOs = _mapper.Map<List<SurveyDTO>>(surveys);
            var totalRecords = surveyDTOs.Count;

            var pagedData = surveyDTOs
                .Skip((validFilter.PageNumber - 1) * validFilter.PageSize)
                .Take(validFilter.PageSize)
                .ToList();

            var pagedResponse = PaginationHelper.CreatePagedReponse<SurveyDTO>(pagedData, validFilter, totalRecords, _uriService, route);

            return Ok(pagedResponse);
        }

        // GET: api/Surveys/ for roles
        [HttpGet("role/{id}")]
        public async Task<ActionResult<SurveyDTO>> GetSurveyByRole(int id, [FromQuery] PaginationFilter filter)
        {
          if (_context.Surveys == null)
          {
                return NotFound(new Models.HttpResponseError
                {
                    status = HttpStatusCode.NotFound,
                    title = "Get data fail",
                    data = null
                });
            }
            var survey = await _context.Surveys
                .Include(_=>_.Questions)
                .ThenInclude(_=>_.Answers)
                .Where(_=>_.UserRoleId == id).ToListAsync();
            var surveyDTO = _mapper.Map<List<SurveyDTO>>(survey);

            if (survey == null)
            {
                return NotFound(new Models.HttpResponseError
                {
                    status = HttpStatusCode.NotFound,
                    title = "Create data fail",
                    data = null
                });
            }

            var route = Request.Path.Value;
            var validFilter = new PaginationFilter(filter.PageNumber, filter.PageSize);

            var totalRecords = surveyDTO.Count;

            var pagedData = surveyDTO
                .Skip((validFilter.PageNumber - 1) * validFilter.PageSize)
                .Take(validFilter.PageSize)
                .ToList();

            var pagedResponse = PaginationHelper.CreatePagedReponse<SurveyDTO>(pagedData, validFilter, totalRecords, _uriService, route);


            return Ok(pagedResponse);
        }

        // GET: api/Surveys/ by surveyId
        [HttpGet("{id}")]
        public async Task<ActionResult<SurveyDTO>> GetSurveyById(int id)
        {
            if (_context.Surveys == null)
            {
                return NotFound(new Models.HttpResponseError
                {
                    status = HttpStatusCode.NotFound,
                    title = "Get data fail",
                    data = null
                });
            }
            var survey = await _context.Surveys
                .Include(_ => _.Questions)
                .ThenInclude(_ => _.Answers)
                .Where(_ => _.SurveyId == id).ToListAsync();
            var surveyDTO = _mapper.Map<List<SurveyDTO>>(survey);

            if (survey == null)
            {
                return NotFound(new Models.HttpResponseError
                {
                    status = HttpStatusCode.NotFound,
                    title = "Get data fail",
                    data = null
                });
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
                return NotFound(new Models.HttpResponseError
                {
                    status = HttpStatusCode.NotFound,
                    title = "Update data fail "+ ex.Message,
                    data = null
                });
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
                    return NotFound(new Models.HttpResponseError
                    {
                        status = HttpStatusCode.NotFound,
                        title = "Create data fail",
                        data = null
                    });
                }
                var newSurvey = _mapper.Map<Survey>(payloadSurvey);
                _context.Surveys.Add(newSurvey);
                await _context.SaveChangesAsync();

                return CreatedAtAction("GetSurveyById", new { id = payloadSurvey.SurveyId }, payloadSurvey);

            } catch (Exception ex)
            {
                return NotFound(new Models.HttpResponseError
                {
                    status = HttpStatusCode.NotFound,
                    title = "Create data fail" + ex.Message,
                    data = null
                });
            }
     
        }

        // DELETE: api/Surveys/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteSurvey(int id)
        {
            if (_context.Surveys == null)
            {
                return NotFound(new Models.HttpResponseError
                {
                    status = HttpStatusCode.NotFound,
                    title = "Delete data fail",
                    data = null
                });
            }

            var surveyToDelete = await _context
                .Surveys.Include(_ => _.Questions)
                .ThenInclude(_=>_.Answers)
                .Where(_ => _.SurveyId == id)
                .FirstOrDefaultAsync();

            if (surveyToDelete == null)
            {
                return NotFound(new Models.HttpResponseError
                {
                    status = HttpStatusCode.NotFound,
                    title = "Delete data fail",
                    data = null
                });
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
