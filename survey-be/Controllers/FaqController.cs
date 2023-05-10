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
    public class FaqController : ControllerBase
    {
        private readonly SurveyDbContext _context;
        private readonly IMapper _mapper;

        public FaqController(SurveyDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        // GET: api/Faq
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Faq>>> GetFaqs()
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
            var faqs = await _context.Faqs.ToListAsync();
            return Ok(new Models.HttpResponseSuccess
            {
                status = HttpStatusCode.OK,
                title = "Data get successfully",
                data = faqs
            });
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

            var newFaq= _mapper.Map<Faq>(payloadFaq);
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

                if(faq != null)
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
    }
}
