using System;
using System.Collections.Generic;
using System.Globalization;
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
    public class FaqController : ControllerBase
    {
        private readonly SurveyDbContext _context;
        private readonly IMapper _mapper;
        private readonly IUriService _uriService;

        public FaqController(SurveyDbContext context, IMapper mapper, IUriService uriService)
        {
            _context = context;
            _mapper = mapper;
            _uriService = uriService;

        }

        // GET: api/Faq?PageNumber=1&PageSize=5&OrderBy=answer_desc&Search=order
        [HttpGet]
        public async Task<ActionResult<IEnumerable<FaqDTO>>> GetFaqs([FromQuery] PaginationFilter filter)
        {
            if (_context.Faqs == null)
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
            var faqs = await _context.Faqs.ToListAsync();

            var faqDTOs = _mapper.Map<List<FaqDTO>>(faqs);
            var totalRecords = faqDTOs.Count;

            var pagedData = faqDTOs
               .Skip((validFilter.PageNumber - 1) * validFilter.PageSize)
               .Take(validFilter.PageSize)
               .OrderBy(_ => _.FaqQuestion)
               .ToList();

            if (validFilter.Search != null)
            {
                pagedData = pagedData.Where(_ => _.FaqQuestion.Contains(validFilter.Search)).ToList();
            }

            if (validFilter.OrderBy != null)
            {
                switch (validFilter.OrderBy)
                {
                    case "question_desc": pagedData = pagedData.OrderByDescending(_ => _.FaqQuestion).ToList(); break;
                    case "answer_asc": pagedData = pagedData.OrderBy(_ => _.FaqContent).ToList(); break;
                    case "answer_desc": pagedData = pagedData.OrderByDescending(_ => _.FaqContent).ToList(); break;
                }
            }

            var pagedResponse = PaginationHelper.CreatePagedReponse<FaqDTO>(pagedData, validFilter, totalRecords, _uriService, route);

            return Ok(pagedResponse);
        }

        // POST: api/Faq
        [HttpPost]
        public async Task<ActionResult<FaqDTO>> PostFaq(FaqDTO payloadFaq)
        {
            if (_context.Faqs == null)
            {
                return NotFound(new Models.HttpResponseError
                {
                    status = HttpStatusCode.NotFound,
                    title = "Create data fail",
                    data = null
                });
            }

            var newFaq = _mapper.Map<Faq>(payloadFaq);
            _context.Faqs.Add(newFaq);
            await _context.SaveChangesAsync();

            return Ok(new Models.HttpResponseSuccess
            {
                status = HttpStatusCode.OK,
                title = "Create data successfully",
                data = null
            });
        }

        // PUT: api/Faq/1
        [HttpPut("{id}")]
        public async Task<IActionResult> PutFaq(int id, FaqDTO payloadFaq)
        {

            try
            {
                var faq = await _context.Faqs.FindAsync(id);

                if (faq != null)
                {

                    faq.FaqQuestion = payloadFaq.FaqQuestion;
                    faq.FaqContent = payloadFaq.FaqContent;

                    await _context.SaveChangesAsync();
                    return Ok(new Models.HttpResponseSuccess
                    {
                        status = HttpStatusCode.OK,
                        title = "Update data successfully",
                        data = null
                    });
                }

                return NotFound(new Models.HttpResponseError
                {
                    status = HttpStatusCode.BadRequest,
                    title = "Update data fail",
                    data = null
                });

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }

        // DELETE: api/Faq/1
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteFaq(int id)
        {
            if (_context.Faqs == null)
            {
                return NotFound(new Models.HttpResponseError
                {
                    status = HttpStatusCode.NotFound,
                    title = "Delete data fail",
                    data = null
                });
            }

            var faqToDelete = await _context
                .Faqs
                .Where(_ => _.FaqId == id)
                .FirstOrDefaultAsync();

            if (faqToDelete == null)
            {
                return NotFound(new Models.HttpResponseError
                {
                    status = HttpStatusCode.NotFound,
                    title = "Delete data fail",
                    data = null
                });
            }
            _context.Faqs.Remove(faqToDelete);
            await _context.SaveChangesAsync();
            return Ok(new Models.HttpResponseSuccess
            {
                status = HttpStatusCode.OK,
                title = "Delete data successfully",
                data = null
            });
        }
    }
}
