using AutoMapper;
using CodeFirstDemo.Filter;
using CodeFirstDemo.Helpers;
using CodeFirstDemo.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using survey_be.Data;
using survey_be.Dtos;
using survey_be.Models;
using System.Net;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace survey_be.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CompetitionResultController : ControllerBase
    {
        private readonly SurveyDbContext _context;
        private readonly IUriService _uriService;

        public CompetitionResultController(SurveyDbContext context, IMapper mapper, IUriService uriService)
        {
            _context = context;
            _uriService = uriService;

        }

        [HttpGet("{id}")]
        public async Task<ActionResult<CompetitionResult>> GetCompetitionResult(int id)
        {
            

            var modelCompetitionContent = await _context.CompetitionContents.Where(_ => _.CompetitionContentId == id).ToListAsync();
            var modelSurvey = await _context.Surveys.ToListAsync();
            var modelResponse= await _context.Responses.ToListAsync();
            var modelResulse= await _context.CompetitionResults.ToListAsync();

            var numberUserJoin = from content in modelCompetitionContent
                                 join result in modelResulse on content.CompetitionContentId equals result.CompetitionContentId into cJoin
                                 from cj in cJoin.DefaultIfEmpty()
                                 select new
                                 {
                                     cj.NumberUserJoined
                                 };

            var modelView =  (from content in modelCompetitionContent
                            join survey in modelSurvey on content.SurveyId equals survey.SurveyId
                            join res in modelResponse.OrderByDescending(p => p.TotalMark) on survey.SurveyId equals res.SurveyId
                            join result in modelResulse on res.ResponseId equals result.ResponseId into cJoin
                             from cj in cJoin.DefaultIfEmpty()
                             select new
                            {
                                 res.UserId,
                               res.TotalMark,
                               content.Name,
                               content.CompetitionContentId,
                               numberUserJoin
                             }).ToList();

            if (modelView == null)
            {
                return NotFound();
            }

            return Ok(modelView);
        }
    }
}
