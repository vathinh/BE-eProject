using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
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
    public class ResponsesController : ControllerBase
    {
        private readonly SurveyDbContext _context;
        private readonly IMapper _mapper;
        private readonly IUriService _uriService;



        public ResponsesController(SurveyDbContext context, IMapper mapper, IUriService uriService)
        {
            _context = context;
            _mapper = mapper;
            _uriService = uriService;


        }

        // GET: api/Responses
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ResponseDTO>>> GetResponses([FromQuery] PaginationFilter filter)
        {
            if (_context.Responses == null)
            {
                return NotFound();
            }
            var route = Request.Path.Value;
            var validFilter = new PaginationFilter(filter.PageNumber, filter.PageSize);

            var responses = await _context.Responses
                .Include(_ => _.CompetitionResults)
                .ToListAsync();

            var responseDTOs = _mapper.Map<List<ResponseDTO>>(responses);
            var totalRecords = responseDTOs.Count;

            var pagedData = responseDTOs
                .Skip((validFilter.PageNumber - 1) * validFilter.PageSize)
                .Take(validFilter.PageSize)
                .ToList();

            var pagedResponse = PaginationHelper.CreatePagedReponse<ResponseDTO>(pagedData, validFilter, totalRecords, _uriService, route);

            return Ok(pagedResponse);
        }

        // GET: api/Responses/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ResponseDTO>> GetResponse(int id)
        {
          if (_context.Responses == null)
          {
              return NotFound();
          }
            var response = await _context.Responses.Where(_=>_.ResponseId == id).ToListAsync();

            if (response == null)
            {
                return NotFound();
            }
            var responseDTO = _mapper.Map<List<ResponseDTO>>(response);


            return Ok(responseDTO);
        }

        // GET: api/Responses/5
        [HttpGet("/surveyParticipate/{id}")]
        public async Task<ActionResult<ParticipatesDTO>> GetParticipates(int id, [FromQuery] PaginationFilter filter)
        {
            if (_context.Responses == null)
            {
                return NotFound(new Models.HttpResponseError
                {
                    status = HttpStatusCode.NotFound,
                    title = "Get data fail",
                    data = null
                });
            }
            var response = await _context.Responses
                .Include(_=>_.Survey)
                .Include(_=>_.UserInfo)
                .Where(_=>_.SurveyId == id).ToListAsync();

            if (response == null)
            {
                return NotFound(new Models.HttpResponseError
                {
                    status = HttpStatusCode.NotFound,
                    title = "Get data fail",
                    data = null
                });
            }
            var dtoList = _mapper.Map<List<Models.Response>, List<ParticipatesDTO>>(response);
            var route = Request.Path.Value;
            var validFilter = new PaginationFilter(filter.PageNumber, filter.PageSize);

            var totalRecords = dtoList.Count;

            var pagedData = dtoList
                .Skip((validFilter.PageNumber - 1) * validFilter.PageSize)
                .Take(validFilter.PageSize)
                .ToList();

            var pagedResponse = PaginationHelper.CreatePagedReponse<ParticipatesDTO>(pagedData, validFilter, totalRecords, _uriService, route);

            return Ok(pagedResponse);
        }

        // PUT: api/Responses/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutResponse(int id, ResponseDTO payloadResponse)
        {


            try
            {
                var updateResponse = _mapper.Map<Survey>(payloadResponse);
                _context.Surveys.Update(updateResponse);
                await _context.SaveChangesAsync();
                return Ok(updateResponse);
            }
            catch (Exception ex)
            {
                return NotFound(new Models.HttpResponseError
                {
                    status = HttpStatusCode.NotFound,
                    title = "Update data fail " + ex.Message,
                    data = null
                });
            }
        }

        // POST: api/Responses
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<ResponseDTO>> PostResponse(ResponseDTO payloadResponse)
        {
          if (_context.Responses == null)
          {
                return NotFound(new Models.HttpResponseError
                {
                    status = HttpStatusCode.NotFound,
                    title = "Create data fail",
                    data = null
                });
          }
          var newResponse = _mapper.Map<Models.Response>(payloadResponse);
            _context.Responses.Add(newResponse);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetResponse", new { id = payloadResponse.ResponseId }, payloadResponse);
        }

        // DELETE: api/Responses/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteResponse(int id)
        {
            if (_context.Responses == null)
            {
                return NotFound(new Models.HttpResponseError
                {
                    status = HttpStatusCode.NotFound,
                    title = "Delete data fail",
                    data = null
                });
            }
            var response = await _context.Responses.FindAsync(id);
            if (response == null)
            {
                return NotFound();
            }

            _context.Responses.Remove(response);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ResponseExists(int id)
        {
            return (_context.Responses?.Any(e => e.ResponseId == id)).GetValueOrDefault();
        }

        [HttpPost("SendResponses")]
        public async Task<ActionResult> SendResponse(SendResponseDTO responseDTO)
        {
            var survey = await _context.Surveys
                .Include(s => s.Questions)
                .ThenInclude(q => q.Answers)
                .FirstOrDefaultAsync(s => s.SurveyId == responseDTO.SurveyId);

            var user = await _context.UserInfos.FindAsync(responseDTO.UserId);
            if (survey == null || user == null)
            {
                return NotFound(new Models.HttpResponseError
                {
                    status = HttpStatusCode.NotFound,
                    title = "Create response fail",
                    data = null
                });
            }

            int totalMark = responseDTO.Questions
                .SelectMany(q => q.SelectedAnswerIds)
                .Join(survey.Questions.SelectMany(q => q.Answers), selectedId => selectedId, answer => answer.AnswerId, (_, answer) => answer)
                .Count(answer => answer.CorrectAnswer);

            var response = new Models.Response
            {
                Survey = survey,
                UserInfo = user,
                TotalMark = totalMark
            };

            _context.Responses.Add(response);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetResponse", new { id = responseDTO.ResponseId }, responseDTO);
        }
    }
}
