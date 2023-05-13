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
    public class ResponsesController : ControllerBase
    {
        private readonly SurveyDbContext _context;
        private readonly IMapper _mapper;


        public ResponsesController(SurveyDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;

        }

        // GET: api/Responses
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ResponseDTO>>> GetResponses()
        {
          if (_context.Responses == null)
          {
              return NotFound();
          }
          var responses = await _context.Responses
                .Include(_ => _.CompetitionResults)
                .ToListAsync();
          var responseDTOs = _mapper.Map<List<ResponseDTO>>(responses);
            return Ok(responseDTOs);
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
        public async Task<ActionResult<ParticipatesDTO>> GetParticipates(int id)
        {
            if (_context.Responses == null)
            {
                return NotFound();
            }
            var response = await _context.Responses
                .Include(_=>_.Survey)
                .Include(_=>_.UserInfo)
                .Where(_=>_.SurveyId == id).ToListAsync();

            if (response == null)
            {
                return NotFound();
            }
            var responseDTO = _mapper.Map<List<ParticipatesDTO>>(response);
            var dtoList = _mapper.Map<List<Models.Response>, List<ParticipatesDTO>>(response);


            return Ok(dtoList);
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
                return BadRequest(ex.Message);
            }
        }

        // POST: api/Responses
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<ResponseDTO>> PostResponse(ResponseDTO payloadResponse)
        {
          if (_context.Responses == null)
          {
              return Problem("Entity set 'SurveyDbContext.Responses'  is null.");
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
                return NotFound();
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
    }
}
