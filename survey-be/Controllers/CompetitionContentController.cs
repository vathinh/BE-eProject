using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using AutoMapper;
using Azure.Core;
using CodeFirstDemo.Filter;
using CodeFirstDemo.Helpers;
using CodeFirstDemo.Services;
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
        private readonly IUriService _uriService;

        public CompetitionContentController(SurveyDbContext context, IMapper mapper, IUriService uriService)
        {
            _context = context;
            _mapper = mapper;
            _uriService = uriService;

        }

        // GET: api/CompetitionContent?PageNumber=1&PageSize=5?OrderBy=survey_id_desc
        // GET: api/CompetitionContent?PageNumber=1&PageSize=5?Search=Competition 3 => search theo ten competition
        [HttpGet]
        public async Task<ActionResult<IEnumerable<CompetitionContent>>> GetCompetitionContents([FromQuery] PaginationFilter filter)
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

            var route = Request.Path.Value;
            var validFilter = new PaginationFilter(filter.PageNumber, filter.PageSize, filter.OrderBy, filter.Search);
            var competitionContents = await _context.CompetitionContents
                .Include(_ => _.CompetitionResults)
                .ToListAsync();

            var competitionContentDTOs = _mapper.Map<List<CompetitionContent>>(competitionContents);
            var totalRecords = competitionContentDTOs.Count;

            var pagedData = competitionContentDTOs
               .Skip((validFilter.PageNumber - 1) * validFilter.PageSize)
               .Take(validFilter.PageSize)
               .OrderBy(_ => _.SurveyId)
               .ToList();

            if (validFilter.Search != null)
            {
                pagedData = pagedData.Where(_ => _.Name.Contains(validFilter.Search)).ToList();
            }

            if (validFilter.OrderBy != null)
            {
                switch (validFilter.OrderBy)
                {
                    case "survey_id_desc": pagedData = pagedData.OrderByDescending(_ => _.SurveyId).ToList(); break;
                    case "competition_name_asc": pagedData = pagedData.OrderBy(_ => _.Name).ToList(); break;
                    case "competition_name_desc": pagedData = pagedData.OrderByDescending(_ => _.Name).ToList(); break;
                    case "competition_content_id_asc": pagedData = pagedData.OrderBy(_ => _.CompetitionContentId).ToList(); break;
                    case "competition_content_id_desc": pagedData = pagedData.OrderByDescending(_ => _.CompetitionContentId).ToList(); break;
                    case "time_start_competition_asc": pagedData = pagedData.OrderBy(_ => _.TimeStartCompetition).ToList(); break;
                    case "time_start_competition_desc": pagedData = pagedData.OrderByDescending(_ => _.TimeStartCompetition).ToList(); break;
                    case "time_end_competition_asc": pagedData = pagedData.OrderBy(_ => _.TimeEndCompetition).ToList(); break;
                    case "time_end_competition_desc": pagedData = pagedData.OrderByDescending(_ => _.TimeEndCompetition).ToList(); break;
                    case "location_asc": pagedData = pagedData.OrderBy(_ => _.Location).ToList(); break;
                    case "location_desc": pagedData = pagedData.OrderByDescending(_ => _.Location).ToList(); break;

                }
            }

            var pagedResponse = PaginationHelper.CreatePagedReponse<CompetitionContent>(pagedData, validFilter, totalRecords, _uriService, route);

            return Ok(pagedResponse);
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

            var surveyId = _context.Surveys.SingleOrDefault(_ => _.SurveyId == newCompetitionContent.SurveyId);

            if (surveyId != null)
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
