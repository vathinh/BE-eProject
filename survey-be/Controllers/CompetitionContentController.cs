using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using AutoMapper;
using Azure.Core;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using survey_be.Data;
using survey_be.Dtos;
using survey_be.Models;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace survey_be.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CompetitionContentController : ControllerBase
    {
        private readonly SurveyDbContext _context;
        private readonly IMapper _mapper;

        public CompetitionContentController(SurveyDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        // GET: api/CompetitionContent
        [HttpGet]
        public async Task<ActionResult<IEnumerable<CompetitionContent>>> GetCompetitionContents()
        {
            if (_context.CompetitionContents == null)
            {
                return NotFound(new Models.HttpResponseError
                {
                    status = HttpStatusCode.NotFound,
                    title = "Data not found",
                    data = null
                });
            }
            var competitionContents = await _context.CompetitionContents
                .Include(_ => _.CompetitionResults)
                .ToListAsync();
            return Ok(new Models.HttpResponseSuccess
            {
                status = HttpStatusCode.OK,
                title = "Data get successfully",
                data = competitionContents
            });
        }

        // GET: api/CompetitionContent/1
        [HttpGet("{id}")]
        public async Task<ActionResult<CompetitionContent>> GetCompetitionContent(int id)
        {
            if (_context.CompetitionContents == null)
            {
                return NotFound();
            }
            var competitionContent = await _context.CompetitionContents
                               .Include(_ => _.CompetitionResults)
                .Where(_ => _.CompetitionContentId == id).ToListAsync();

            if (competitionContent.Count == 0)
            {
               return NotFound(new Models.HttpResponseError
               {
                   status = HttpStatusCode.NotFound,
                   title = "Data not found",
                   data = null
               });
            }

            return Ok(new Models.HttpResponseSuccess
            {
                status = HttpStatusCode.OK,
                title = "Data get successfully",
                data = competitionContent
            });
        }

        // POST: api/CompetitionContent
        [HttpPost]
        public async Task<ActionResult<CompetitionContentDTO>> PostCompetitionContent(CompetitionContentDTO payloadCompetitionContent)
        {
            if (_context.CompetitionContents == null)
            {
                return NotFound(new Models.HttpResponseError
                {
                    status = HttpStatusCode.NotFound,
                    title = "Create data fail",
                    data = null
                });
            }
            var newCompetitionContent = _mapper.Map<CompetitionContent>(payloadCompetitionContent);

            var surveyId = _context.Surveys.SingleOrDefault(_=> _.SurveyId == newCompetitionContent.SurveyId);

            if(surveyId != null)
            {
                _context.CompetitionContents.Add(newCompetitionContent);
                await _context.SaveChangesAsync();

                return Ok(new Models.HttpResponseSuccess
                {
                    status = HttpStatusCode.OK,
                    title = "Create data successfully",
                    data = null
                });
            }
            return NotFound(new Models.HttpResponseError
            {
                status = HttpStatusCode.BadRequest,
                title = "Invalid surveyId, create data fail",
                data = null
            });
        }
    }
}
